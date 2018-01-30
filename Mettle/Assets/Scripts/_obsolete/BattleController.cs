using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.AI;
using UnityEngine;

public class BattleController : MonoBehaviour {

    private Animator thisAnimator;
    private NavMeshAgent thisAgent;
    private GameObject myEnemy;

    int AttackHash = Animator.StringToHash("Attack");
    int DefendHash = Animator.StringToHash("Defend");

    public void Start() {

        myEnemy = GameObject.FindGameObjectWithTag("Enemy");
        thisAnimator = GetComponentInChildren<Animator>();
        thisAgent = GetComponent<NavMeshAgent>();

    }

    public void AttackNow() {

        thisAnimator.SetTrigger(AttackHash);
  

    }

    public void DefendNow(){

        thisAnimator.SetTrigger(DefendHash);

    }
}
