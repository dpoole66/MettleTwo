using System;
using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;


    [Serializable]
    public class MettleManager
    { 
    public Transform m_SpawnPoint;     
    [HideInInspector] public GameObject m_Instance;
    [HideInInspector] public int m_MettleNumber;            // This specifies which player this the manager for.
    [HideInInspector] public string m_ColoredPlayerText;

    [HideInInspector] public int m_Wins;                    // The number of wins this player has so far.
	[HideInInspector] public List<Transform> m_WayPointList;      

    private GameObject m_CanvasGameObject;                  // Used to disable the world space UI during the Starting and Ending phases of each round.
	private StateController m_StateController;				// Reference to the StateController for AI Mettles
                                                                                                  
	public void SetupAI(List<Transform> wayPointList)
	{
		m_StateController = m_Instance.GetComponent<StateController> ();
		m_StateController.SetupAI (true, wayPointList);           
        
	}

    public void SetUpPlayerMettle(){

        m_CanvasGameObject = m_Instance.GetComponentInChildren<Canvas> ().gameObject;

    }

    public void Reset() {
        m_Instance.transform.position = m_SpawnPoint.position;
        m_Instance.transform.rotation = m_SpawnPoint.rotation;

        m_Instance.SetActive(false);
        m_Instance.SetActive(true);
    }

    public void EnableControl() {
 
        if (m_StateController != null)
            m_StateController.enabled = true;

        m_CanvasGameObject.SetActive(true);
    }

    public void DisableControl() {      

        if (m_StateController != null)
            m_StateController.enabled = false;              

        m_CanvasGameObject.SetActive(false);
    }

}
