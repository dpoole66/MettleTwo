using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class StateController_Enemy: MonoBehaviour {

    public State currentState;

    //dual use on both player and enemy?
    public EnemyStatus enemyStatus;
   
    public GameObject m_EnemyMettle;   
    public GameObject m_PlayerMettle;
    public Transform m_MettleEye;

    // IK animation for OnAnimatorIK below
    public bool ikActive = false;

    public GameObject m_EnemyLookAt = null;
    public GameObject m_EnemySwordTarget = null;
    public GameObject m_EnemyShieldTarget = null;

    public GameObject m_PlayerLookAtTarget = null;
    public GameObject m_PlayerSwordTarget = null;
    public GameObject m_PlayerShieldTarget = null;
    //

    public State remainState;

    [HideInInspector] public AudioSource m_NPCAudio;   
    [HideInInspector] public NavMeshAgent m_Agent;
    [HideInInspector] public Animator m_Anim, m_PlayerAnim;
    [HideInInspector] public List<Transform> wayPointList;
    [HideInInspector] public int nextWayPoint;   
    [HideInInspector] public float stateTimeElapsed;
    [HideInInspector] public Transform chaseTarget;
    [HideInInspector] public GameObject enemyTarget;

    private bool aiActive;
    public bool underAttack;
    private System.Object stateController_enemy;

    void Awake() {

        m_Agent = GetComponent<NavMeshAgent>();
        m_Anim = GetComponent<Animator>();
        chaseTarget = GetComponent<Transform>();

        enemyTarget = GameObject.Find("MettlePlayer(Clone)");


        m_PlayerLookAtTarget = GameObject.FindGameObjectWithTag("targetPlayerHead");


        m_PlayerShieldTarget = GameObject.FindGameObjectWithTag("targetPlayerShield");


        m_PlayerSwordTarget = GameObject.FindGameObjectWithTag("targetPlayerSword");

    
        m_NPCAudio = GetComponent<AudioSource>();        
      
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
        //currentState.UpdateState(this);

    }

    private void OnDrawGizmos() {
        if(currentState != null && m_MettleEye != null){

            Gizmos.color = currentState.sceneGizmoColor;
            Gizmos.DrawWireSphere(m_MettleEye.position, enemyStatus.lookSphereCastRadius);

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

        ClearAnimParams();
        stateTimeElapsed = 0;

    }

    
    public void ClearAnimParams(){

        foreach(AnimatorControllerParameter paramater in m_Anim.parameters){
                //m_Anim.SetBool("moving", false);
                m_Anim.ResetTrigger(paramater.name);

        }

    }

}
