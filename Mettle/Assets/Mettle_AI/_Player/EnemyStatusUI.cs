using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatusUI : MonoBehaviour {

    Text m_UI_Health;
    GameObject m_Enemy;
    EnemyHealth m_enemyHealth;
    [HideInInspector] public float m_EnemyHealth;

    // Use this for initialization
    void Start () {

        m_Enemy = GameObject.Find("MettleNPC(Clone)");
        m_UI_Health = GameObject.Find("v_EnemyHealth").GetComponent<Text>();
        m_UI_Health.color = Color.white;

        m_enemyHealth = m_Enemy.GetComponent<EnemyHealth>();

    }
	
	// Update is called once per frame
	void Update () {

        m_EnemyHealth = m_enemyHealth.M_E_CurrentHealth;
        m_UI_Health.text = m_EnemyHealth.ToString();

        if (m_EnemyHealth <= 90.0f) {

            m_UI_Health.color = Color.red;

        }

    }

    
}
