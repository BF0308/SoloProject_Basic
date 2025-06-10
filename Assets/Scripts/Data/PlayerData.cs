using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public string PlayerName;
    public int PlayerLevel;
    public int Exp;
    public int MaxExp;
    public int Money;
    public float MaxHealth;
    public float Health;
    public float Defence;

    public PlayerData(string playerName, int playerLevel, int exp, int maxExp, int maxHealth, float health, float defence)
    {
        PlayerName = playerName;
        PlayerLevel = playerLevel;
        Exp = exp;
        MaxExp = maxExp;
        Money = maxExp;
        MaxHealth = maxHealth;
        Health = health;
        Defence = defence;
    }
}
