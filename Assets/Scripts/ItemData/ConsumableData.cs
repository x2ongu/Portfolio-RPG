using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HealthPotion", menuName = "Items/Consumable/HealthPotion")]
public class HealthPotion : ConsumableData
{
    
}

[CreateAssetMenu(fileName = "ManaPotion", menuName = "Items/Consumable/ManaPotion")]
public class ManaPotion : ConsumableData
{

}

[CreateAssetMenu(fileName = "Buff", menuName = "Items/Consumable/ManaPotion")]
public class Buff : ConsumableData
{
    public float m_duration;
}