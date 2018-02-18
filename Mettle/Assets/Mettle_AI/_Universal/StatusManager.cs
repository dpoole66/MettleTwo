using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusManager : MonoBehaviour {
    [SerializeField]
    private Transform m_MettleNPC;
    [HideInInspector]
    public Transform M_mettleNPCPos {

        get {
            return m_MettleNPC;
        }
        set {
            m_MettleNPC = value;
        }

    }
    [SerializeField]
    private Transform m_MettlePlayer;
   [HideInInspector] public Transform M_mettlePlayerPos{

    get { 
        return m_MettlePlayer;
     }
     set {  
            m_MettlePlayer = value;    
     }

    }
    private Transform opponentPos;
    public Transform OpponentPos {

        get {
            return opponentPos;
        }

        set{
            opponentPos = value;         
        }

    }

    void Start () {

        m_MettleNPC = GetComponent<Transform>();
        m_MettlePlayer = GetComponent<Transform>();

    }

     public void GetOpponent(StateController controller) {

        OpponentPosition(controller);

     }

     private void OpponentPosition(StateController controller){
         if(controller.thisIsPlayer == true) {

            controller.m_Opponent = "MettleNPC(Clone)";
            m_MettlePlayer = OpponentPos;
            Debug.Log("MettleNPC is chaseTarge");
        }   else
            controller.m_Opponent = "MettlePlayer(Clone)";
            m_MettleNPC = OpponentPos;
            Debug.Log("MettlePlayer is chaseTarge");
    }


}
