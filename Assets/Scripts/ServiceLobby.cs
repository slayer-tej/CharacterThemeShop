using System;
using UnityEngine;
using UnityEngine.UI;

public enum Tab
{
    None,
    Character,
    BubbleBird
}

public class ServiceLobby : MonoBehaviour
{
    public static ServiceLobby current;
    public event Action<string> OnCharChange;
    public event Action<Tab> OnSelectionChanged;
    [SerializeField] private Text Tabname;
    private Tab selectedTab = Tab.Character;

    [SerializeField]
    private Button themeStoreButton;
    [SerializeField]
    private Button themeStoreCloseButton;
    [SerializeField]
    private GameObject themeStore;
    private bool isThemeStoreActive;

    private void Awake()
    {
        current = this;
    }

    void Start()
    {
        themeStoreButton.onClick.AddListener(OnClick);
        themeStoreCloseButton.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        isThemeStoreActive = isThemeStoreActive ? false : true;
        themeStore.SetActive(isThemeStoreActive);
        Tabname.text = selectedTab.ToString();
    }

    public void ChangeTab(Tab tab)
    {
        if (tab != selectedTab)
        {
            Debug.Log("Changing Tab from " + selectedTab + " to " + tab);
            selectedTab = tab;
            Tabname.text = tab.ToString();
            OnSelectionChanged?.Invoke(selectedTab);
        }
    }

    public void ChangeName(string name)
    {
        if(OnCharChange != null)
        {
            OnCharChange(name);
        }
    }
}
