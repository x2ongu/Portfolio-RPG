using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Zoom : MonoBehaviour
{
    [SerializeField]
    private CinemachineVirtualCamera[] m_virtualCameras;

    [SerializeField]
    private float m_zoomSpeed = 1f;

    private int m_curCamIndex = 0;

    private void Start()
    {
        SwitchCamera(m_curCamIndex);
    }

    private void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        if (scroll > 0f)
        {
            if (m_curCamIndex + 1 < m_virtualCameras.Length)
                SwitchCamera(m_curCamIndex + 1);
        }
        else if (scroll < 0f)
        {
            if (m_curCamIndex > 0)
                SwitchCamera(m_curCamIndex - 1);
        }
    }

    void SwitchCamera(int newIndex)
    {
        m_virtualCameras[m_curCamIndex].gameObject.SetActive(false);
        m_virtualCameras[newIndex].gameObject.SetActive(true);

        m_curCamIndex = newIndex;

        // Virtual Camera�� Active�� �Ѱ� ���鼭 ��ȯ�Ǵ� ȭ�� �ӵ��� ����
        CinemachineCore.Instance.GetActiveBrain(0).m_DefaultBlend.m_Time = m_zoomSpeed;        
    }
}
