using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MettleHitDetection : MonoBehaviour {

    //[HideInInspector] public AudioSource m_NPCAudio;
    public PlayerHealth M_P_Health { get; set; }

    public string m_Opponent;
    //string m_OpponentName;

    void Start() {

        M_P_Health = GetComponent<PlayerHealth>();

    }


    // Hit Trigger count

    //Player
    void OnTriggerEnter(Collider other) {

        if (other.gameObject.CompareTag("Enemy")) {                 
            
            return;

        } else {

            M_P_Health.TakeDamage(5.0f);

        }

        if (M_P_Health.m_P_HealthSlider.value <= 0) {

            M_P_Health.OnDeath();

        }

    }

    private void OnTriggerExit(Collider other) {

        Debug.Log("Hit Over");

    }

}
