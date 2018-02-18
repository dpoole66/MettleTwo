using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour {

    Text m_VitalsEnemy;
    GameObject m_Enemy;  
    EnemyHealth m_enemyHealth;
    [HideInInspector] public float EnemyHealth;

    Text m_VitalsPlayer;
    GameObject m_Player;
    PlayerHealth m_playerHealth;
    [HideInInspector] public float PlayerHealth;

    void Start () {

        m_Player = GameObject.Find("MettlePlayer(Clone)");    
        m_VitalsPlayer = GameObject.Find("v_PlayerHealth").GetComponent<Text>();
        m_playerHealth = m_Player.GetComponent<PlayerHealth>();

        m_Enemy = GameObject.Find("MettleNPC(Clone)");  
        m_VitalsEnemy = GameObject.Find("v_EnemyHealth").GetComponent<Text>();
        m_enemyHealth = m_Enemy.GetComponent<EnemyHealth>();

    }

	
	// Update is called once per frame
	void Update () {
  
        PlayerHealth = m_playerHealth.M_P_CurrentHealth;
        m_VitalsPlayer.text = PlayerHealth.ToString();

        EnemyHealth = m_enemyHealth.M_E_CurrentHealth;
        m_VitalsEnemy.text = EnemyHealth.ToString();

    }
}
