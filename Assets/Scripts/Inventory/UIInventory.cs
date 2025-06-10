using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventory : MonoBehaviour
{
    public UISlot slot;
    public Transform slotsParent;
    List<UISlot> slots = new List<UISlot>();


    private void Start()
    {
        InitInventory();
    }

    private void InitInventory()
    {
        if (slotsParent.childCount > 12)
        {
            for (int i = 0; i < slotsParent.childCount; i++)
            {
                 Instantiate(slot, slotsParent.transform);
                slots.Add(slot);
                slot.idx = i;
            }
        }
        else
        {
            for (int i = 0; i < 12; i++)
            {
                Instantiate(slot);
                slots.Add(slot);
                slot.idx = i;
            }
        }
        
        
    }

    public void UpdateUI()
    {
        
    }
}
