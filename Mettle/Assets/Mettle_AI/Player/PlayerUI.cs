using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour {

    Text m_EnemyRange;    
    GameObject m_Enemy;
    public Vector3 m_EnemyHeading;

    // Use this for initialization
    void Start () {

        m_Enemy = GameObject.Find("MettleNPC(Clone)");
        m_EnemyRange = GameObject.Find("v_NumRange").GetComponent<Text>();
        

    }
	
	// Update is called once per frame
	void Update () {

        //GetRange();

    }

public void GetRange() {

        var heading = m_Enemy.transform.position - this.transform.position;
        var range = heading.magnitude;
        m_EnemyRange.text = range.ToString();
        m_EnemyRange.color = Color.Lerp(Color.red, Color.yellow, range / 6.0f);

    }


}
