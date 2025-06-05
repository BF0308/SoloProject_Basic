using System;
using System.Collections.Generic;
using UnityEngine;
using System.IO; 
public class DataManager : MonoBehaviour
{
    private static DataManager _instance;
    public static DataManager Instance{get{return _instance;}set{_instance=value;}}

    private string path;
    private Action FailLogin;
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        path = Application.persistentDataPath + "/Userdata.Json";
    }

    private void Start()
    {

        if (File.Exists(path))
        {
            LoadAllUserData();
            SaveAllUserData();
        }
        else
        {
            FailLogin?.Invoke();
        }
        
    }

    public void SaveAllUserData()
    {
        string json = JsonUtility.ToJson(GameManager.Instance.allUserData);
        File.WriteAllText(path, json);
    }

    public void LoadAllUserData()
    {
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            GameManager.Instance.allUserData = JsonUtility.FromJson<UserDataList>(json);
        }
    }

    public void SaveNewUserData(UserData newUserData)
    {
        GameManager.Instance.allUserData.users.Add(newUserData);
        GameManager.Instance.currentUserData = newUserData;
        SaveAllUserData();
    }
    
    [Serializable]
    public class UserDataList
    {
        public List<UserData> users = new List<UserData>();
    }
    
}
