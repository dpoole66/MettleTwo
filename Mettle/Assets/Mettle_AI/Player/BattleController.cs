using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MettlePlayer;

public class BattleController : MonoBehaviour {

    [HideInInspector] public GameObject m_Enemy;  
    [HideInInspector] public Transform m_Player;
    [HideInInspector] public Vector3 m_Heading;
    [HideInInspector] public float m_Range;
    [HideInInspector] public Quaternion m_Rotation;


    // Use this for initialization
    void Start() {

        m_Enemy = GameObject.Find("MettleNPC(Clone)");     
        m_Player = GetComponent<Transform>(); 
        m_Range = GetRange(m_Range);
        m_Heading = GetHeading(m_Heading);
        m_Rotation = GetRotation(m_Rotation);

    }


    float GetRange(float m_Range) {

        var heading = m_Enemy.transform.position - this.transform.position;
        var range = heading.magnitude;

        float returnRange = range;
        returnRange = m_Range; ;
        return m_Range;

    }

   Vector3 GetHeading(Vector3 m_Heading) {

        var heading = m_Enemy.transform.position - this.transform.position;

        Vector3 returnHeading = heading;
        returnHeading = m_Heading; ;
        return m_Heading;

    }

    Quaternion  GetRotation(Quaternion m_Rotation) {

        var returnRotation = m_Enemy.transform.rotation;
        returnRotation = m_Rotation;
        return m_Rotation;

    }

    public void RotateToFaceEnemy()  {

        Quaternion DestRot = Quaternion.LookRotation(m_Enemy.transform.position - this.transform.position, Vector3.up);

        this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, m_Enemy.transform.rotation, 90.0f * Time.deltaTime);

    }

}
