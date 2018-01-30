using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI
;

public class DetectHit : MonoBehaviour {
    public Slider healthbar;
    Animator m_Anim;
    public string m_Opponent;

    void Start() {

        m_Anim = GetComponent<Animator>();
        healthbar.value = 100;
    }

    // Update is called once per frame
    void Update() {

    }

    // Hit Trigger count
    void OnTriggerEnter(Collider other) {

        if (other.gameObject.tag != m_Opponent) {
            
            return;
        }

        healthbar.value -= 10;

        if(healthbar.value <= 0){

            m_Anim.SetBool("isDead", true);
        }
      
    }


}
