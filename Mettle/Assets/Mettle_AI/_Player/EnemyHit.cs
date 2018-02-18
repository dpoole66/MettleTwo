using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour {

   EnemyHealth m_EnemyHealth;        
   public string m_Opponent;

    void Start() {

        m_EnemyHealth = GetComponent<EnemyHealth>();

    }


    // Hit Trigger count

    //Player
    void OnTriggerEnter(Collider other) {

        if (other.gameObject.tag != ("PlayerSword")) {
            Debug.Log("Enemy False Alarm");
            return;

        } else {

            m_EnemyHealth.TakeDamage(5.0f);
            Debug.Log("Enemy Take Damage 5.0");
            var EnemyHealth = m_EnemyHealth.M_E_CurrentHealth;
            Debug.Log(EnemyHealth);

        }

        if (m_EnemyHealth.m_E_HealthSlider.value <= 0) {

            m_EnemyHealth.OnDeath();
            Debug.Log("Enemy Dead");

        }

    }

    private void OnTriggerExit(Collider other) {

        Debug.Log("Enemy Taking Hit Over");

    }
}
