using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MettleAttack : MonoBehaviour {
    
    public int m_PlayerNumber = 1;
    private float nextFireTime;
    private bool inAttack;

    public void Attack(float AttackForce, float AttackRate){

        nextFireTime = Time.time + AttackRate;
        // Set bool to lock call.
        inAttack = true;

    }
}
