using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetectHit : MonoBehaviour {
    //[HideInInspector] public AudioSource m_NPCAudio;
    public Slider healthbar;
    private GameObject m_UIslider;
    Animator m_Anim;
    public string m_Opponent;

    void Start() {

        m_Anim = GetComponent<Animator>();
        m_UIslider = GameObject.Find("UI");
        healthbar = m_UIslider.GetComponentInChildren<Slider>();
        healthbar.value = 100;
    }

    // Update is called once per frame
    void Update() {
 
    }

    // Hit Trigger count
    void OnTriggerEnter(Collider other) {

        if (other.gameObject.tag != m_Opponent) {
            
            return;

        } else  {

            healthbar.value -= 10;
            //Debug.Log("Hit");

        }

        if(healthbar.value <= 0){

            m_Anim.SetBool("isDead", true);

        }
      
    }


}
