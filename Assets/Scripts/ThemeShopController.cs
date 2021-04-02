using UnityEngine.UI;
using UnityEngine;
using System;

public class ThemeShopController : MonoBehaviour
{
    [SerializeField]
    private Button themeStoreButton;
    [SerializeField]
    private Button themeStoreCloseButton;
    [SerializeField]
    private GameObject themeStore;
    private bool isThemeStoreActive;
    // Start is called before the first frame update
    void Start()
    {
        themeStoreButton.onClick.AddListener(OnClick);
        themeStoreCloseButton.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        isThemeStoreActive =  isThemeStoreActive ? false : true;
        themeStore.SetActive(isThemeStoreActive);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
