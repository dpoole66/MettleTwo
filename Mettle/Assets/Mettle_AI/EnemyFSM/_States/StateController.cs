using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StateController : MonoBehaviour {

    public State currentState;
    public MettleStats enemyStats;
    public Transform m_MettleEye;
    public State remainState;
    public GameObject m_PlayerMettle;
    public bool m_PlayerAttacking;

    [HideInInspector] public AudioSource m_NPCAudio;   
    [HideInInspector] public NavMeshAgent m_Agent;
    [HideInInspector] public Animator m_Anim;
    [HideInInspector] public List<Transform> wayPointList;
    [HideInInspector] public int nextWayPoint;   
    [HideInInspector] public float stateTimeElapsed;
    [HideInInspector] public Transform chaseTarget;
    [HideInInspector] public AttackStats_Enemy m_Attack;
    [HideInInspector] public Animator m_Player_Anim;

    private bool aiActive;

    void Awake() {

        m_Agent = GetComponent<NavMeshAgent>();
        m_Anim = GetComponent<Animator>();
        chaseTarget = GetComponent<Transform>();
        m_NPCAudio = GetComponent<AudioSource>();
        m_Attack = GetComponent<AttackStats_Enemy>();
        m_Player_Anim = m_PlayerMettle.GetComponent<Animator>();

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

        // experimental, Talk to Player animator to see if it's attacking
        if (m_Player_Anim.GetBool("isAttacking") == true) {

            m_PlayerAttacking = true;

        } else m_PlayerAttacking = false;
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
                ClearAnimParams();

          }

    }

    public bool CheckIfCountDownElapsed(float duration){

        stateTimeElapsed += Time.deltaTime;
        return (stateTimeElapsed >= duration);

    }

    private void OnExitState(){  

        stateTimeElapsed = 0;

    }

    public void ClearAnimParams(){

        foreach(AnimatorControllerParameter paramater in m_Anim.parameters){
                m_Anim.SetBool(paramater.name, false);

        }

    }

}
