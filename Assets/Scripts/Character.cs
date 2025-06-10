using System.Collections.Generic;
using UnityEngine;

public class Character
{
    public string PlayerName{get;private set;}
    public int PlayerLevel { get; private set; } = 1;
    public int PlayerCurEXP{get;private set;}
    public int PlayerMaxEXP { get; private set; } = 10;
    public int PlayerMoney{get;private set;}
    private PlayerStat _stat {get; set; }

    public PlayerStat Stat
    {
        get
        {
            if (_stat == null)
            {
                _stat = new PlayerStat();
            }
            return _stat;
        }
        set
        {
            _stat = value;
        }
    }
    
    List<ItemData> Inventory = new List<ItemData>();

    public Character(string playerName,int playerMoney)
    {
        PlayerName = playerName;
        PlayerMoney = playerMoney;
    }
    
    #region 경험치관리

    
    public void AddEXP(int value)
    {
        if (PlayerCurEXP + value >= PlayerMaxEXP)
        {
            PlayerCurEXP = PlayerCurEXP+value-PlayerMaxEXP;
            nextMaxEXP();
            PlayerLevel++;
        }
        else
        {
            PlayerCurEXP += value;
        }
    }
    
    private void nextMaxEXP()
    {
        if (PlayerLevel / 10 == 0)
        {
            PlayerMaxEXP = PlayerMaxEXP*2; 
        }
        PlayerMaxEXP = PlayerMaxEXP+5;
    }
    #endregion
    
    #region 돈관리
    
    public void BuyItem(int value)
    {
        ChangeMoney(-Mathf.Abs(value));
    }

    public void SellItem(int value)
    {
        ChangeMoney(Mathf.Abs(value));
    }
    
    private void ChangeMoney(int value)
    {
        PlayerMoney += value;
    }
    #endregion

    #region 아이템관리

    public void AddItem(ItemData item)
    {
        Inventory.Add(item);
    }

    public void EquipItem(ItemData item)
    {
        for (int i = 0; i < item.EquipmentType.Length; i++)
        {
            if (item.EquipmentType[i].type == EquipmentType.Weapon)
            {
                _stat.AttackDamageUp(item.EquipmentType[i].amount);
            }

            if (item.EquipmentType[i].type == EquipmentType.Helmet)
            {
                _stat.Healing(item.EquipmentType[i].amount);
            }
        }
        
        
    }

    public void UnequipItem(ItemData item)
    {
        
    }

    #endregion
    
}
