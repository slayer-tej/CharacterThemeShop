using UnityEngine;
using UnityEngine.UI;


public class ControllerMiddlePanel : MonoBehaviour
{
    [SerializeField] private Text charNameField;
    [SerializeField] private Button prevButton;
    [SerializeField] private Button nextButton;
    [SerializeField] private Button select;
    [SerializeField] private Text charStatus;
    [SerializeField] private ControllerCharacterLock[] allChars;

    private string charName;
    private int currentCharacter;
    private int level;
    private int selectedCharacter;


    private void OnEnable()
    {
        level = ServiceLobby.current.level;
        UnlockChar();
        allChars[0].Select(true);
        ChangeChar(0);
    }

    private void Start()
    {
        ServiceLobby.current.OnCharChange += ChangeName;
        select.gameObject.SetActive(false);
        select.onClick.AddListener(MakeSelection);
    }

    private void MakeSelection()
    {
        allChars[currentCharacter].Select(true);
        allChars[selectedCharacter].Select(false);
        UpdateStatus(currentCharacter);
    }

    private void ChangeName(string name)
    {
        charNameField.text = name;
    }

    public void UnlockChar()
    {
        for (int i = 0; i < allChars.Length; i++)
        {
            if (allChars[i].unlockedAtLevel <= level)
            {
                allChars[i].Unlock();
                allChars[i].lockObject.SetActive(false);
            }
        }
    }

    private void SelectChar(int index)
    {
        prevButton.interactable = (index != 0);
        nextButton.interactable = (index != allChars.Length - 1);
        for (int i = 0; i < allChars.Length; i++)
        {
            allChars[i].gameObject.SetActive(i == index);
        }
    }

    public void ChangeChar(int change)
    {
        currentCharacter += change;
        SelectChar(currentCharacter);
        charName = allChars[currentCharacter].gameObject.name;
        ServiceLobby.current.ChangeName(charName);
        UpdateStatus(currentCharacter);
    }

    private void UpdateStatus(int currCharacter)
    {
        if (!(allChars[currCharacter].unlocked))
        {
            SwitchObejcts(true);
            charStatus.text = ("Level " + allChars[currCharacter].unlockedAtLevel);
        }
        else if (allChars[currCharacter].unlocked && !(allChars[currCharacter].isSelected))
        {
            SwitchObejcts(false);
        }
        else if (allChars[currCharacter].unlocked && allChars[currCharacter].isSelected)
        {
            SwitchObejcts(true);
            charStatus.text = "Selected";
            selectedCharacter = currentCharacter;
        }
    }

    private void SwitchObejcts(bool status)
    {
        charStatus.gameObject.SetActive(status);
        select.gameObject.SetActive(!status);
    }

    private void OnDisable()
    {
        for (int i = 0; i < allChars.Length; i++)
        {
            allChars[i].unlocked = false;
            allChars[i].lockObject.SetActive(true);
            allChars[i].isSelected = false;
        }
    }
}
