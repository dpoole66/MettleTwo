using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectHitShield : MonoBehaviour {

    private GameObject m_MettlePlayer, m_MettleEnemy;                   
    Animator m_AnimEnemy, m_AnimPlayer;

    // Use this for initialization
    void Start () {
        m_MettlePlayer = GameObject.Find("MettlePlayer(Clone)");
        m_MettleEnemy = GameObject.Find("MettleNPC(Clone)");
        m_AnimEnemy = m_MettleEnemy.GetComponent<Animator>();
        m_AnimPlayer = m_MettlePlayer.GetComponent<Animator>();
    }

    // Hit Trigger count
    void OnTriggerEnter(Collider other) {

        if (other.gameObject.tag != "PlayerSword") {

            return;

        } else {

            m_AnimEnemy.SetTrigger("Defending");
            m_AnimPlayer.SetTrigger("Blocked");
            //Debug.Log("Defending");

        }

    }
}
