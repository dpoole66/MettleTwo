using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MettleAttacking : MonoBehaviour {

    public int m_MettleNumber = 1;
    Animator  m_Anim;
    private string m_AttackButton;

    // Use this for initialization
    void Start () {
        m_AttackButton = "Fire" + m_MettleNumber;
        m_Anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
		 if(Input.GetButton(m_AttackButton)){

            m_Anim.SetBool("isAttacking", true);

         }  else{
            m_Anim.SetBool("isAttacking", false);
         }
	}
}
