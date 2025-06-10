using UnityEngine;

public class PlayerStat : MonoBehaviour
{


    public float Health{get;private set;}
    public float MaxHealth{get;private set;}
    public float Defense { get; private set; } = 2;
    public float AttackDamage { get; private set; } = 2;

    public void SetMaxHealth(float value)
    {
        MaxHealth = value;
        Health = MaxHealth;
    }

    
    #region 체력관련
    public void Damaged(int value)
    {
        ChangedHealth(-Mathf.Abs(value));
    }
    
    public void Healing(int value)
    {
        ChangedHealth(Mathf.Abs(value));
    }
    
    private void ChangedHealth(float value)
    {
        if (value > 0)
        {
            if (MaxHealth <= value + Health)
            {
                Health = MaxHealth;
            }
            else
            {
                Health += value;
            }
        }
        else
        {
            if (Health + value < 0)
            {
                Health = 0;
            }
            else
            {
                Health += value;
            }
        }
    }
    #endregion

    #region 공격력관련
    public void AttackDamageUp(int value)
    {
       AttackDamageChanged(Mathf.Abs(value)); 
    }
    public void AttackDamageDown(int value)
    {
        AttackDamageChanged(-Mathf.Abs(value)); 
    }
    public void AttackDamageChanged(int value)
    {
        AttackDamage += value;
    }
    #endregion
    
    
}
