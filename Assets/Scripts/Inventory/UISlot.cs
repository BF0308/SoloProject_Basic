using UnityEngine;
using UnityEngine.UI;

public class UISlot : MonoBehaviour
{
    public ItemData item;
    public GameObject icon;
    public GameObject equipment;
    public Image image;
    public Button slotButton;

    public int idx;
    public bool equipped;
    

    public void SetItem(ItemData _item)
    {
        item = _item;
        image = _item.Icon;
        icon.SetActive(true);
        equipment.SetActive(false);
    }

    public void RefreshUI()
    {
        
    }
}
