using UnityEngine;
using System.IO; 
public class DataManager : MonoBehaviour
{
    private static DataManager _instance;
    public static DataManager Instance{get{return _instance;}set{_instance=value;}}

    public string userID;
    public string userPW;

    private string path;
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
            LoadUserData();
        }
        SaveUserData();
    }

    public void SaveUserData()
    {
        string data = JsonUtility.ToJson(GameManager.Instance.userData);
        File.WriteAllText(path,data);
    }

    public void LoadUserData()
    {
        string data = File.ReadAllText(path);
        GameManager.Instance.userData = JsonUtility.FromJson<UserData>(data);
    }
}
