using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StateController : MonoBehaviour {

    public State currentState;
    public MettleStats enemyStats;
    public Transform m_MettleEye;
    public Transform m_EnemyMettle;
    public State remainState;

    [HideInInspector] public NavMeshAgent m_Agent;
    [HideInInspector] public Animator m_Anim;
    [HideInInspector] public List<Transform> wayPointList;
    [HideInInspector] public int nextWayPoint;
    [HideInInspector] public Transform m_EnemyTarget;
    [HideInInspector] public float stateTimeElapsed = 1.0f;
    [HideInInspector] public MettleAttack m_Attack;
    [HideInInspector] public float nextAttackTime = 1.0f;  
    [HideInInspector] public bool inAttack;

    private bool aiActive;

    void Awake() {

        m_Agent = GetComponent<NavMeshAgent>();
        m_Anim = GetComponent<Animator>();
        m_EnemyMettle = GetComponent<Transform>();
        m_Attack = GetComponent<MettleAttack>();

    }

    public void SetupAI(bool aiActivationFromMettleManager, List<Transform> wayPointsFromMettleManager) {
        wayPointList = wayPointsFromMettleManager;
        aiActive = aiActivationFromMettleManager;
        if (aiActive) {
            m_Agent.enabled = true;
        } else {
            m_Agent.enabled = false;
        }
    }

    private void Update() {
        if (!aiActive) return;
        currentState.UpdateState(this);
    }

    private void OnDrawGizmos() {
        if(currentState != null && m_MettleEye != null){

            Gizmos.color = currentState.sceneGizmoColor;
            Gizmos.DrawWireSphere(m_MettleEye.position, enemyStats.lookSphereCastRadius);

        }
    }

    public void TransitionToState(State nextState){

      if(nextState != remainState){

            currentState = nextState;

            OnExitState();

      }

    }

    public bool CheckIfCountDownElapsed(float duration){

        stateTimeElapsed += Time.deltaTime;
        return (stateTimeElapsed >= duration);

    }

    private void OnExitState(){

        stateTimeElapsed = 0;

    }

    public void Attack(float AttackForce, float AttackRate) {

        nextAttackTime = Time.time + AttackRate;
        m_Agent.isStopped = true;
        m_Anim.SetBool("isAttacking", true);
        inAttack = true;

    }
}
