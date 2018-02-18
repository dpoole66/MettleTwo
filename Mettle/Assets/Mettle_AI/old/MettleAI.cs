using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MettleAI : MonoBehaviour {

    public int m_MettleNumber = 1;
    public GameObject m_MettleOne;
    public GameObject[] waypoints;

    public GameObject GetPlayer(){

        return m_MettleOne;

    }
	
    
    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
