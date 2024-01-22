using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    public ItemData m_itemData;

    InteractionManager m_interManager;
    NavMeshAgent m_navAgent;
    Camera m_mainCam;

    Vector3 m_movePoint;

    [SerializeField, Header("캐릭터 이동속도")]
    private float m_speed = 5f;
    [SerializeField, Header("캐릭터 공격력")]
    private float m_damage = 5f;
    private float m_attackRange = 5;
    private float m_attackRate = 1f;
    private float m_time;
    [SerializeField, Header("캐릭터 체력")]
    private int m_maxHp = 100;
    private int m_curHp;

    public float Damage { get { return m_damage; } set { m_damage = value; } }
    public int HP { get { return m_curHp; } set { m_curHp = value; } }

    private void Awake()
    {
        m_interManager = GetComponent<InteractionManager>();
        m_navAgent = GetComponent<NavMeshAgent>();
        m_navAgent.speed = m_speed;
        m_mainCam = Camera.main;
        m_curHp = m_maxHp;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            Ray ray = m_mainCam.ScreenPointToRay(Input.mousePosition);

            Debug.DrawRay(ray.origin, ray.direction * 100f, Color.red);

            if (Physics.Raycast(ray, out RaycastHit raycastHit))
            {
                m_movePoint = raycastHit.point;
                //Debug.Log("movePoint : " + m_movePoint.ToString());
                //Debug.Log("맞은 객체 : " + raycastHit.transform.name);
            }
        }

        m_time += Time.deltaTime;

        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (m_time > m_attackRate)
            {
                GameObject[] enemy = GameObject.FindGameObjectsWithTag("Enemy");
                for (int i = 0; i < enemy.Length; i++)
                {
                    if (IsCloseToTarget(enemy[i].transform.position, m_attackRange))
                        enemy[i].GetComponent<Enemy>().TakeDamage(m_damage);
                }

                m_time = 0f;
            }
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            m_interManager.ReturnSelectedNPC();
        }
    }

    private void FixedUpdate()
    {
        if (Vector3.Distance(transform.position, m_movePoint) > 0.1f)
        {
            m_navAgent.SetDestination(m_movePoint);
        }
    }

    public void TakeDamage(float damage)
    {
        m_curHp -= Mathf.RoundToInt(damage);
        Debug.Log("받은 피해 :" + Mathf.RoundToInt(damage));
        Debug.Log("현재 체력 : " + m_curHp);
    }

    private bool IsCloseToTarget(Vector3 targetPos, float range)
    {
        float dist = Vector3.SqrMagnitude(transform.position - targetPos);

        if (dist < range * range)
            return true;

        return false;
    }
}
