using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StateController : MonoBehaviour {

    public State currentState;
    public MettleStats enemyStats;
    public Transform m_MettleEye;
    public State remainState;
    //public Transform chaseTarget;

    [HideInInspector] public NavMeshAgent m_Agent;
    [HideInInspector] public Animator m_Anim;
    [HideInInspector] public List<Transform> wayPointList;
    [HideInInspector] public int nextWayPoint;   
    [HideInInspector] public float stateTimeElapsed;
    [HideInInspector] public Transform chaseTarget;


    private bool aiActive;

    void Awake() {

        m_Agent = GetComponent<NavMeshAgent>();
        m_Anim = GetComponent<Animator>();
        chaseTarget = GetComponent<Transform>();

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

}
