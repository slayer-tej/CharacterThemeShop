using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ControllerTabButton : MonoBehaviour
{
    [SerializeField]
    private Tab tab;
    private Button buttonTab;
    private bool isSelected = false;
    private RectTransform rectTransform;


    private void Awake()
    {
        buttonTab = GetComponent<Button>();
        rectTransform = GetComponent<RectTransform>();

        buttonTab.onClick.AddListener(OnClick);
        ServiceLobby.current.OnSelectionChanged += onSelectionChanged;
    }

    private void onSelectionChanged(Tab selectedTab)
    {
        if (tab != selectedTab && isSelected)
        {
            StartCoroutine(DisableSelection());
        }
        else if (!isSelected && selectedTab == tab)
        {
            StartCoroutine(EnableSelection());
        }
    }

    private IEnumerator EnableSelection()
    {
        yield return null;
        isSelected = true;
    }

    private IEnumerator DisableSelection()
    {
        yield return null;
        isSelected = false;
    }

    private void OnClick()
    {
        ServiceLobby.current.ChangeTab(tab);
    }
}
