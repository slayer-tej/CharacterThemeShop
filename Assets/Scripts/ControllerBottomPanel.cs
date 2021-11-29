using UnityEngine;

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
        SwitchTabs(tab == Tab.Character);
    }

    private void SwitchTabs(bool status)
    {
        characterContent.SetActive(status);
        bubbleBirdContent.SetActive(!status);
    }
}
