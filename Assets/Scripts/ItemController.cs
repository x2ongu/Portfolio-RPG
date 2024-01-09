using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public ItemData m_item;

    private void Start()
    {
        switch(m_item.m_itemType)
        {
            case ItemData.ItemType.Weapon:

                break;
            case ItemData.ItemType.DefensiveGear:

                break;
            case ItemData.ItemType.Consumable:

                break;
        }
    }
}
