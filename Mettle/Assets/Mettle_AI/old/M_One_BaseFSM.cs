using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_One_BaseFSM : StateMachineBehaviour {

    public GameObject m_MettleOne;
    public GameObject m_MettlePrime;
    public float speed = 2.0f;
    public float rotSpeed = 1.3f;
    public float accuracy = 3.0f;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, System.Int32 layerIndex) {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        m_MettleOne = animator.gameObject;
        m_MettlePrime = m_MettleOne.GetComponent<MettleAI>().GetPlayer();
    }
}
