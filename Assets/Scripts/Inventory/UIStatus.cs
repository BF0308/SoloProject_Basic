using TMPro;
using UnityEngine;

public class UIStatus : MonoBehaviour
{
    public TextMeshProUGUI AttackDamage;
    public TextMeshProUGUI Health;
    public TextMeshProUGUI Defense;

    private void Start()
    {
        //나중에 구독문 넣을곳
    }

    public void UpdateUI()
    {
        Health.text = $"{GameManager.Instance.Player.Stat.Health}/{GameManager.Instance.Player.Stat.MaxHealth}";
        AttackDamage.text = $"{GameManager.Instance.Player.Stat.AttackDamage}";
        Defense.text = $"{GameManager.Instance.Player.Stat.Defense}";
    }
    
    
}
