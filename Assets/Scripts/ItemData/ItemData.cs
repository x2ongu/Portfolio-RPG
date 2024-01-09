using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData : ScriptableObject
{
    public enum ItemType { Weapon, DefensiveGear, Consumable }
    public ItemType m_itemType;

    public string m_itemName;
    [TextArea]
    public string m_itemDesc;
}

[CreateAssetMenu(fileName = "Weapon", menuName = "Items/Weapon")]
public class WeaponData : ItemData
{
    public int m_damage;
    public float m_attackSpeed;
}

public class DefensiveGearData : ItemData
{
    public enum DefensiveGearType { Helmet, Top, Pants, Shoe, Glove }
    public DefensiveGearType m_dgType;      // DG : DefensiveGear

    public int m_defenseForce;
}

public class ConsumableData : ItemData
{
    // 포션 : 체력, 마나 / 버프 : 공격력, 방어력, 이동속도
    public enum ConsumableType { Health, Mana, AttackRate, DefenseRate, MoveSpeedRate }
    public ConsumableType m_consumType;

    public int m_amount;
}