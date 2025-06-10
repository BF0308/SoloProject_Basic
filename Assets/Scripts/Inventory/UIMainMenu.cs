using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour
{
    public TextMeshProUGUI PlayerNameText;
    public TextMeshProUGUI LevelText;
    public TextMeshProUGUI MoneyText;
    public TextMeshProUGUI ExpText;
    
    public Image ExpBar;

    public void UpdateUI()
    {
        PlayerNameText.text = GameManager.Instance.Player.PlayerName;
        LevelText.text = GameManager.Instance.Player.PlayerLevel.ToString();
        MoneyText.text = GameManager.Instance.Player.PlayerMoney.ToString();
        ExpText.text = $"{GameManager.Instance.Player.PlayerCurEXP}/{GameManager.Instance.Player.PlayerMaxEXP}";
        
        ExpBar.fillAmount = GameManager.Instance.Player.PlayerCurEXP / GameManager.Instance.Player.PlayerMaxEXP;
    }
}
