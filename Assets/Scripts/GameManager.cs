using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance{get{return _instance;}set{_instance=value;}}
    
    public UserData userData;
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        userData = new UserData("주영훈",100000,100000);
    }
    
}
