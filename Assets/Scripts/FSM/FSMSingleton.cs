using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T m_inst;
    private static object m_lock = new object();

    public static T Instance
    {
        get
        {
            lock (m_lock)
            {
                if (m_inst == null)
                {
                    m_inst = (T)FindObjectOfType(typeof(T));

                    if (FindObjectsOfType(typeof(T)).Length > 1)
                    {
                        Debug.LogError("FSM Singleton Error");
                        return m_inst;
                    }

                    if (m_inst == null)
                    {
                        GameObject singleton = new GameObject();
                        m_inst = singleton.AddComponent<T>();
                        singleton.name = "(Singleton)" + typeof(T).ToString();
                        // singleton.hideFlags = HideFlags.HideAndDontSave;     // To hide Singleton Obj
                    }
                    else
                    {
                        Debug.LogError("FSM Singleton already exits");
                    }
                }
                return m_inst;
            }
        }
    }
}
