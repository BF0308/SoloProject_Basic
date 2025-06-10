using System;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    private static UIManager _instance;
    public static UIManager Instance{get{return _instance;}}

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else if (_instance != this)
        {
            Destroy(this.gameObject);
        }
    }
    private UIMainMenu _uiMainMenu;

    public UIMainMenu UIMainMenu
    {
        get
        {
            if (_uiMainMenu == null)
            {
                _uiMainMenu = FindObjectOfType<UIMainMenu>();
            }
            
            return _uiMainMenu;
        }
    }

    private UIInventory _uiInventory;

    public UIInventory UIInventory
    {
        get
        {
            if (_uiInventory == null)
            {
                _uiInventory = FindObjectOfType<UIInventory>();
            }
                
            return _uiInventory;
        }
    }

    private UIStatus _uiStatus;

    public UIStatus UIStatus
    {
        get
        {
            if (_uiStatus == null)
            {
                _uiStatus = FindObjectOfType<UIStatus>();
            }
            return _uiStatus;
        }
    }

    public GameObject InventoryPanel;
    public GameObject StatusPanel;
    public GameObject MainMenuPanel;
    
    public Button UIInventoryButton;
    public Button UIStatusButton;
    public Button[] UIMainMenuButton;

    private void Start()
    {
        UIInventoryButton.onClick.AddListener(OnInventoryBtn);
        UIStatusButton.onClick.AddListener(OnStatusBtn);
        for (int i = 0; i < UIMainMenuButton.Length; i++)
        {
            UIMainMenuButton[i].onClick.AddListener(OnMainMenuBtn);
        }
        
    }

    public void OnMainMenuBtn()
    {
        InventoryPanel.SetActive(false);
        StatusPanel.SetActive(false);
        MainMenuPanel.SetActive(true);
    }

    public void OnInventoryBtn()
    {
        InventoryPanel.SetActive(true);
        StatusPanel.SetActive(false);
        MainMenuPanel.SetActive(false);
    }

    public void OnStatusBtn()
    {
        InventoryPanel.SetActive(false);
        StatusPanel.SetActive(true);
        MainMenuPanel.SetActive(false);
    }
    
}
