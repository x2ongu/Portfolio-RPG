using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NPCType
{
    MainQuestNPC,
    RepaetQuestNPC,
    EquipmentMerchant,
    ItemMerchant
}

public class NPC : MonoBehaviour
{
    public NPCType m_npcType;
}
