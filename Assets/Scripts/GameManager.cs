using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance{get{return _instance;}}
    
    public DataManager.UserDataList allUserData = new DataManager.UserDataList();
    public UserData currentUserData;
    
    public Character Player;
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetData()
    {
        Player = new Character("코딩", 100000);
        UIManager.Instance.UIMainMenu.UpdateUI();
        UIManager.Instance.UIInventory.UpdateUI();
        UIManager.Instance.UIStatus.UpdateUI();
    }
}
