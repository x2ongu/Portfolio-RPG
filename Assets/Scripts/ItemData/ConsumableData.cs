using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HealthPotion", menuName = "Items/Consumable/HealthPotion")]
public class HealthPotion : ConsumableData
{
    public override void WhenTheItemDrops()
    {
        Debug.Log(m_itemName + "�� ȹ���ϼ̽��ϴ�!");
    }
}

[CreateAssetMenu(fileName = "ManaPotion", menuName = "Items/Consumable/ManaPotion")]
public class ManaPotion : ConsumableData
{
    public override void WhenTheItemDrops()
    {
        Debug.Log(m_itemName + "�� ȹ���ϼ̽��ϴ�!");
    }
}

[CreateAssetMenu(fileName = "Buff", menuName = "Items/Consumable/ManaPotion")]
public class Buff : ConsumableData
{
    public float m_duration;

    public override void WhenTheItemDrops()
    {
        Debug.Log(m_itemName + "�� ȹ���ϼ̽��ϴ�!");
    }
}