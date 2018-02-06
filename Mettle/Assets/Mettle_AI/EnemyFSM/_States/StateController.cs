using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StateController : MonoBehaviour {

    public State currentState;
    public EnemyStats enemyStats;
    public MettleStats playerStats;
    public Transform m_MettleEye;
    public State remainState;
    public GameObject m_PlayerMettle;

    [HideInInspector] public AudioSource m_NPCAudio;   
    [HideInInspector] public NavMeshAgent m_Agent;
    [HideInInspector] public Animator m_Anim, m_PlayerAnim;
    [HideInInspector] public List<Transform> wayPointList;
    [HideInInspector] public int nextWayPoint;   
    [HideInInspector] public float stateTimeElapsed;
    [HideInInspector] public Transform chaseTarget;  

    private bool aiActive;

    void Awake() {

        m_Agent = GetComponent<NavMeshAgent>();
        m_Anim = GetComponent<Animator>();
        chaseTarget = GetComponent<Transform>();
        m_NPCAudio = GetComponent<AudioSource>();        
        m_PlayerAnim = m_PlayerMettle.GetComponent<Animator>();
 
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

        //ClearAnimParams();
        stateTimeElapsed = 0;

    }

    
    public void ClearAnimParams(){

        foreach(AnimatorControllerParameter paramater in m_Anim.parameters){
                m_Anim.SetBool("moving", false);
                m_Anim.ResetTrigger(paramater.name);

        }

    }
    

}
