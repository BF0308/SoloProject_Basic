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
    public TMP_InputField RemittanceTarget;
    public TMP_InputField RemittanceAmount;
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
        Calculation(-customText);
    }

    public void RemittanceBtn()
    {
        foreach (var user in GameManager.Instance.allUserData.users)
        {
            if (user.userName == RemittanceTarget.text)
            {
                user.balance += int.Parse(RemittanceAmount.text) ;
                GameManager.Instance.currentUserData.balance -= int.Parse(RemittanceAmount.text);
            }
        }
        ChangeMoney?.Invoke();
    }

    private void Calculation(int amount)//계산
    {
        if (amount > 0)//음수가 아니면(입금)
        {
            if (0 > GameManager.Instance.currentUserData.userCash - amount) //현금이 작성한값보다 적을때
            {
                return;
            }
                
            GameManager.Instance.currentUserData.balance += amount;
            GameManager.Instance.currentUserData.userCash -= amount;
        }
        else if (amount < 0) //음수면(출금)
        {
            if (0 > GameManager.Instance.currentUserData.balance - amount) //은행의 돈이 작성한값보다 적을때
            {
                return;
            }
                
            
            GameManager.Instance.currentUserData.balance += amount;
            GameManager.Instance.currentUserData.userCash -= amount;
        }

        ChangeMoney?.Invoke();
    }
}
