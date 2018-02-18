using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStatusUI : MonoBehaviour {

    Text m_UI_Health;
    GameObject m_Player;
    PlayerHealth m_playerHealth;
    [HideInInspector] public float m_PlayerHealth;

    // Use this for initialization
    void Start () {

        m_Player = GameObject.Find("MettlePlayer(Clone)");
        m_UI_Health = GameObject.Find("v_PlayerHealth").GetComponent<Text>();
        m_UI_Health.color = Color.white;

        m_playerHealth = m_Player.GetComponent<PlayerHealth>();

    }
	
	// Update is called once per frame
	void Update () {

        m_PlayerHealth = m_playerHealth.M_P_CurrentHealth;
        m_UI_Health.text = m_PlayerHealth.ToString();

        if (m_PlayerHealth <= 90.0f) {

            m_UI_Health.color = Color.red;

        }

    }

    
}
