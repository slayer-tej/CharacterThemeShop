using UnityEngine.UI;
using UnityEngine;

public class CharacterSelection : MonoBehaviour
{
    [SerializeField] private Button prevButton;
    [SerializeField] private Button nextButton;

    private string charName;

    private int currentCharacter;

    void Awake()
    {
        SelectChar(0);
    }
   
    private void SelectChar(int index)
    {
        prevButton.interactable = (index != 0);
        nextButton.interactable = (index != transform.childCount-1);
        for(int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(i == index);
        }
    }

   public void ChangeChar(int change)
    {
        currentCharacter += change;
        SelectChar(currentCharacter);
        charName =  transform.GetChild(currentCharacter).gameObject.name;
        ServiceLobby.current.ChangeName(charName);
    }
}
