using System;
using TMPro;
using UnityEngine;

public class PopupBank : MonoBehaviour
{
    private int _userCash;
    private int _balance;
    public PopupBankUI popupBankUI;
    public TMP_InputField CustomDepositInputField; 
    public TMP_InputField CustomBalanceInputField;
    public Action ChangeMoney;
 
    public void Deposit(int amount)//입금
    {
        Calculation(Mathf.Abs(amount));
    }
    public void CustomDeposit()//입금
    {
        int customText = int.Parse(CustomDepositInputField.text);
        Calculation(Mathf.Abs(customText));
    }

    public void Withdraw(int amount)//인풋필드출금
    {
        Calculation(-amount);
    }
    public void CustomWithdraw()//인풋필드출금
    {
        int customText = int.Parse(CustomBalanceInputField.text);
        Calculation(customText);
    }

    private void Calculation(int amount)//계산
    {
        if (amount > 0)//음수가 아니면(입금)
        {
            if (0 > GameManager.Instance.userData.userCash - amount) //현금이 작성한값보다 적을때
            {
                return;
            }
                
            GameManager.Instance.userData.balance += amount;
            GameManager.Instance.userData.userCash -= amount;
        }
        else if (amount < 0) //음수면(출금)
        {
            if (0 > GameManager.Instance.userData.balance - amount) //은행의 돈이 작성한값보다 적을때
            {
                return;
            }
                
            
            GameManager.Instance.userData.balance += amount;
            GameManager.Instance.userData.userCash -= amount;
        }

        ChangeMoney?.Invoke();
    }
}
