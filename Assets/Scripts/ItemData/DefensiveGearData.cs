using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Helmet", menuName = "Items/DefensiveGear/Helmet")]
public class HelmetData : DefensiveGearData
{
    public int m_maxMana;
    public override void WhenTheItemDrops()
    {
        Debug.Log(m_itemName + "�� ȹ���ϼ̽��ϴ�!");
    }
}

[CreateAssetMenu(fileName = "Top", menuName = "Items/DefensiveGear/Top")] 
public class TopData : DefensiveGearData
{
    public int m_maxHealth;
    public override void WhenTheItemDrops()
    {
        Debug.Log(m_itemName + "�� ȹ���ϼ̽��ϴ�!");
    }
}

[CreateAssetMenu(fileName = "pants", menuName = "Items/DefensiveGear/pants")] 
public class PantsData : DefensiveGearData
{

    public override void WhenTheItemDrops()
    {
        Debug.Log(m_itemName + "�� ȹ���ϼ̽��ϴ�!");
    }
}

[CreateAssetMenu(fileName = "Shoe", menuName = "Items/DefensiveGear/Shoe")] 
public class ShoeData : DefensiveGearData
{
    public float m_moveSpeed;

    public override void WhenTheItemDrops()
    {
        Debug.Log(m_itemName + "�� ȹ���ϼ̽��ϴ�!");
    }
}

[CreateAssetMenu(fileName = "Glove", menuName = "Items/DefensiveGear/Glove")]
public class GloveData : DefensiveGearData
{
    public float m_criticalRate;

    public override void WhenTheItemDrops()
    {
        Debug.Log(m_itemName + "�� ȹ���ϼ̽��ϴ�!");
    }
}