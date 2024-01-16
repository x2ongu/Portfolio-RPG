using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData : ScriptableObject
{
    public enum ItemType { Weapon, DefensiveGear, Consumable, Gold }
    public ItemType m_itemType;

    public string m_itemName;
    [TextArea]
    public string m_itemDesc;

    public virtual void WhenTheItemDrops()
    {

    }
}

[CreateAssetMenu(fileName = "Weapon", menuName = "Items/Weapon")]
public class WeaponData : ItemData
{
    public int m_damage;
    public float m_attackSpeed;

    public override void WhenTheItemDrops()
    {
        Debug.Log(m_itemName + "�� ȹ���ϼ̽��ϴ�!");
    }
}

public class DefensiveGearData : ItemData
{
    public enum DefensiveGearType { Helmet, Top, Pants, Shoe, Glove }
    public DefensiveGearType m_dgType;      // DG : DefensiveGear

    public int m_defenseForce;
}

public class ConsumableData : ItemData
{
    // ���� : ü��, ���� / ���� : ���ݷ�, ����, �̵��ӵ�
    public enum ConsumableType { Health, Mana, AttackRate, DefenseRate, MoveSpeedRate }
    public ConsumableType m_consumType;

    public int m_amount;
}

[CreateAssetMenu(fileName = "Gold", menuName = "Items/Gold")]
public class GoldData : ItemData
{
    public int m_minGold;
    public int m_maxGold;
    private int m_gold;

    public override void WhenTheItemDrops()
    {
        m_gold = Random.Range(m_minGold, m_maxGold);
        Debug.Log(m_itemName + " " + m_gold + "�� ȹ���ϼ̽��ϴ�!");
    }
}