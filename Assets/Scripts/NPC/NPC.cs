using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface INPC
{
    void DoInteraction();
}

public class NPC : MonoBehaviour, INPC
{
    public virtual void DoInteraction() { }
}
