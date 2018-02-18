using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetectHitPrime : MonoBehaviour {

    public Slider healthbar;
    Animator m_Anim;
    public string m_Enemy;

    // Hit Trigger count
    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag != m_Enemy) return;     

        healthbar.value -= 10;

        if (healthbar.value <= 0.0f) {

            m_Anim.SetBool("isDead", true);

        }
        Debug.Log(healthbar.value);
    }


    void Start() {

        m_Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {

    }
}
