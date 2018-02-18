using System;
using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;


    [Serializable]
    public class MettleManager
    {   
    public Color m_MettleColor;
    public Transform m_SpawnPoint;
    [HideInInspector] public int m_MettleNumber;
    [HideInInspector] public string m_ColoredMettleText;
    [HideInInspector] public GameObject m_Instance;
    [HideInInspector] public int m_Wins;                
	[HideInInspector] public List<Transform> m_WayPointList;

    //private MettleMovement m_MettleMovement;
    //private PlayerAttack m_PlayerAttack;

    private GameObject m_CanvasGameObject;                  
	private StateController m_StateController;				// This is Enemy Mettle fsm
    private MettleAttack m_MettleAttack;

        

	public void SetupAI(List<Transform> wayPointList)
	{
        m_StateController = m_Instance.GetComponent<StateController> ();
        m_StateController.SetupAI (true, wayPointList);

        m_StateController = m_Instance.GetComponent<StateController>();
        m_StateController.SetupAI(true, wayPointList);

        m_MettleAttack = m_Instance.GetComponent<MettleAttack>();
        m_MettleAttack.m_MettleNumber = m_MettleNumber;

        m_CanvasGameObject = m_Instance.GetComponentInChildren<Canvas>().gameObject;
        m_ColoredMettleText = "<color =#" + ColorUtility.ToHtmlStringRGB(m_MettleColor) + ">METTLE" + m_MettleNumber + "</color>";

        MeshRenderer[] renderers = m_Instance.GetComponentsInChildren<MeshRenderer>();

        // Go through all the renderers...
        for (int i = 0; i < renderers.Length; i++) {
            // ... set their material color to the color specific to this tank.
            renderers[i].material.color = m_MettleColor;
        }

    }

    public void SetUpPlayerMettle() {
        m_MettleAttack = m_Instance.GetComponent<MettleAttack>();    
        m_CanvasGameObject = m_Instance.GetComponentInChildren<Canvas>().gameObject;

        //Set the player number. Not sure this is working
        m_MettleAttack.m_MettleNumber = m_MettleNumber;   

        //m_PlayerAttack.m_MettleNumber = m_MettleNumber;
        m_ColoredMettleText = "<color =#" + ColorUtility.ToHtmlStringRGB(m_MettleColor) + ">METTLE" + m_MettleNumber + "</color>";

        MeshRenderer[] renderers = m_Instance.GetComponentsInChildren<MeshRenderer>();

        // Go through all the renderers...
        for (int i = 0; i < renderers.Length; i++) {
            // ... set their material color to the color specific to this tank.
            renderers[i].material.color = m_MettleColor;

        }
    }

    public void Reset() {
        m_Instance.transform.position = m_SpawnPoint.position;
        m_Instance.transform.rotation = m_SpawnPoint.rotation;

        m_MettleAttack.ResetAttack();

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
