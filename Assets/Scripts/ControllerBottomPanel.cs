
using UnityEngine;
using UnityEngine.UI;

public class ControllerBottomPanel : MonoBehaviour
{
    [SerializeField] private ControllerTabButton tabs;
    [SerializeField] private GameObject characterContent;
    [SerializeField] private GameObject bubbleBirdContent;

    private void Awake()
    {
        ServiceLobby.current.OnSelectionChanged += onTabSelectionChanged;
    }
    private void Start()
    {
        bubbleBirdContent.SetActive(false);
    }

    private void onTabSelectionChanged(Tab tab)
    {
        if(tab == Tab.Character)
        {
            characterContent.SetActive(true);
            bubbleBirdContent.SetActive(false);

        }
        else if (tab == Tab.BubbleBird)
        {
            characterContent.SetActive(false);
            bubbleBirdContent.SetActive(true);
        }
    }
}
