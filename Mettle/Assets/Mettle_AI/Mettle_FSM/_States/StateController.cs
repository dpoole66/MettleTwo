using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class StateController: MonoBehaviour {

    public State currentState;
    private bool aiActive;
    public bool thisIsPlayer;
    public bool isUnderAttack;
    //dual use on both player and enemy with generic mettleStatus m_MettleEye and public string  Opponent to indentify
    public string m_Opponent;
    public MettleStatus mettleStatus; 
    public Transform m_MettleEye;
    /*
    private bool  isplayer;
    public bool Isplayer{

    get { 
            return isplayer;    
            }

            set { 
            isplayer = value;
            }

    }
   /*
   

    /*
   // IK animation for OnAnimatorIK below
   public bool ikActive = false;

   public GameObject m_EnemyLookAt = null;
   public GameObject m_EnemySwordTarget = null;
   public GameObject m_EnemyShieldTarget = null;

   public GameObject m_PlayerLookAtTarget = null;
   public GameObject m_PlayerSwordTarget = null;
   public GameObject m_PlayerShieldTarget = null;
   */

    public State remainState;
    [HideInInspector] public StatusManager m_StatusManager;
    [HideInInspector] public AudioSource m_NPCAudio;   
    [HideInInspector] public NavMeshAgent m_Agent;
    [HideInInspector] public Animator m_Anim;
    [HideInInspector] public List<Transform> wayPointList;
    [HideInInspector] public int nextWayPoint;   
    [HideInInspector] public float stateTimeElapsed;
    [HideInInspector] public Transform chaseTarget;  

   

    void Awake() {
       
        m_Agent = GetComponent<NavMeshAgent>();
        m_Anim = GetComponent<Animator>();
        chaseTarget = GetComponent<Transform>();
        if (this.gameObject.tag != ("Enemy")) {

            m_Opponent = "MettleNPC(Clone)";
            thisIsPlayer = true;

        } else m_Opponent = "MettlePlayer(Clone)";
            thisIsPlayer = false;

        Debug.Log(m_Opponent);
 

        //enemyTarget = GameObject.Find("MettlePlayer(Clone)");

        /*
        m_PlayerLookAtTarget = GameObject.FindGameObjectWithTag("targetPlayerHead");


        m_PlayerShieldTarget = GameObject.FindGameObjectWithTag("targetPlayerShield");


        m_PlayerSwordTarget = GameObject.FindGameObjectWithTag("targetPlayerSword");
        */

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
        currentState.UpdateState(this);

    }

    private void OnDrawGizmos() {
        if(currentState != null && m_MettleEye != null){

            Gizmos.color = currentState.sceneGizmoColor;
            Gizmos.DrawWireSphere(m_MettleEye.position, mettleStatus.lookSphereCastRadius);

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
