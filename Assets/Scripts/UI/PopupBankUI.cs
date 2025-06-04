using System;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class PopupBankUI : MonoBehaviour
{
    public TextMeshProUGUI userNameText;
    public TextMeshProUGUI userCashText;
    public TextMeshProUGUI balanceText;

    public GameObject ATMUI;
    public GameObject DepositUI;
    public GameObject WithdrawUI;

    public PopupBank bank;
    
    private void Start()
    {
        Refresh();
        bank.ChangeMoney += Refresh;
    }

    public void Refresh()
    {
        userNameText.text = GameManager.Instance.userData.userName;
        userCashText.text = GameManager.Instance.userData.userCash.ToString();
        balanceText.text = $"Balance\t{GameManager.Instance.userData.balance}";
    }

    public void OnDepositUIBtnClick()
    {
        DepositUI.SetActive(true);
        ATMUI.SetActive(false);
        WithdrawUI.SetActive(false);
    }
    
    public void OnWithdrawUIBtnClick()
    {
        DepositUI.SetActive(false);
        ATMUI.SetActive(false);
        WithdrawUI.SetActive(true);
    }

    public void OnBackUIBtnClick()
    {
        DepositUI.SetActive(false);
        ATMUI.SetActive(true);
        WithdrawUI.SetActive(false);
    }

    
    
}
