using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMettle : MonoBehaviour {

    Animator m_Anim;
    float lastPos;

    public float ApproachSpeed = 1.0f;  

    // Use this for initialization
    void Start () {
        m_Anim = GetComponent<Animator>();
        lastPos = this.transform.position.z;
	}
	/*
	// Update is called once per frame
	void Update () {
        var curPos = this.transform.position;

        if (m_Rigid.velocity.magnitude > 1.0f){

            m_Anim.SetBool("isAdvancing", true);

        } else{
            m_Anim.SetBool("isIdle", true);
            m_Anim.SetBool("isAdvancing", true);
        }
	}
     */
}
