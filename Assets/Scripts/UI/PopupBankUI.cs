using System;
using TMPro;
using UnityEngine;

public class PopupBankUI : MonoBehaviour
{
    public TextMeshProUGUI userNameText;
    public TextMeshProUGUI userCashText;
    public TextMeshProUGUI balanceText;

    public GameObject ATMUI;
    public GameObject DepositUI;
    public GameObject WithdrawUI;

    public PopupBank bank;

    private void Awake()
    {
        bank.popupBankUI = this;
    }

    private void Start()
    {
        Refresh();
        bank.ChangeMoney += Refresh;
    }

    public void Refresh()
    {
        userNameText.text = GameManager.Instance.currentUserData.userName;
        userCashText.text = GameManager.Instance.currentUserData.userCash.ToString();
        balanceText.text = $"Balance\t{GameManager.Instance.currentUserData.balance}";
        DataManager.Instance.SaveAllUserData();
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
