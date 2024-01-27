using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    #region Class Variable
    [HideInInspector]
    public AnimationEvent m_animEvent;
    [HideInInspector]
    public InteractionManager m_interManager;
    [HideInInspector]
    public InputManager m_inputManager;
    [HideInInspector]
    public NavMeshAgent m_navAgent;
    [HideInInspector]
    public Camera m_mainCam;
    #endregion

    #region Player Info
    [SerializeField, Header("캐릭터 공격력")]
    private float m_damage = 5f;
    [SerializeField, Header("캐릭터 공격속도")]
    public float m_attackRate = 2f;
    [SerializeField, Header("캐릭터 이동속도")]
    public float m_speed = 5f;
    [SerializeField, Header("캐릭터 최대 체력")]
    private int m_maxHp = 100;
    private int m_curHp;

    [SerializeField, Header("구르기 재사용 대기 시간")]
    public float m_rollDuration = 5f;
    [HideInInspector]
    public float m_rollSpeed = 15f;
    [HideInInspector]
    public float m_rollDist = 10f;
    #endregion

    #region Property
    public float Damage { get { return m_damage; } set { m_damage = value; } }
    public int HP { get { return m_curHp; } set { m_curHp = value; } }
    #endregion

    private void Awake()
    {
        #region GetComPonent
        m_animEvent = GetComponentInChildren<AnimationEvent>();
        m_interManager = GetComponent<InteractionManager>();
        m_inputManager = GetComponent<InputManager>();
        m_navAgent = GetComponentInChildren<NavMeshAgent>();
        #endregion

        m_navAgent.speed = m_speed;
        m_mainCam = Camera.main;
        m_curHp = m_maxHp;
    }

    private void Update()
    {
        m_inputManager.GetKey_MouseLeft();

        m_inputManager.GetKey_MouseRight();

        m_inputManager.GetKeyDown_Space();

        m_inputManager.GetKeyDown_G();
    }

    private void LateUpdate()
    {
        if (m_navAgent.remainingDistance <= m_navAgent.stoppingDistance)
            m_animEvent.m_anim.SetFloat("Speed", 0f);
    }

    public void TakeDamage(float damage)
    {
        m_curHp -= Mathf.RoundToInt(damage);
        Debug.Log("받은 피해 :" + Mathf.RoundToInt(damage));
        Debug.Log("현재 체력 : " + m_curHp);
    }
}
