[System.Serializable]
public class UserData
{
    public string userName;
    public int userCash;
    public int balance;
    
    public string userID;
    public string userPW;
    
    public UserData(string _userName, int _userCash, int _balance)
    {
        userName = _userName;
        userCash = _userCash;
        balance = _balance;
    }
}
