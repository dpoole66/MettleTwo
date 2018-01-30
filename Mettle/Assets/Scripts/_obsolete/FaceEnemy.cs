using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FaceEnemy : MonoBehaviour {

    public Transform EnemyMettle;
    Animator m_Animator;
    NavMeshAgent m_Agent;
    Vector3 m_TurnDir;
    bool turnRight, turnLeft;
    public float speed;


    // Use this for initialization
    void Start () {
        m_Animator = GetComponent<Animator>();
        m_TurnDir = this.transform.rotation.eulerAngles;
        m_Agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Vector3.Distance(EnemyMettle.position, this.transform.position) < 18.0f){

            Vector3 direction = EnemyMettle.position - this.transform.position;

            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);
            this.transform.RotateAround(EnemyMettle.position, Vector3.up, -45 * Time.deltaTime);
            turnRight = true;

            m_Animator.SetTrigger("TurnRight");




            /*
       //Dumb mover
        float step = speed * Time.deltaTime;
         this.transform.position = Vector3.MoveTowards(this.transform.position, EnemyMettle.transform.position, step);


      if (m_RigidBody.angularVelocity.magnitude > 0.5f) {

      turnRight = true;

          m_Animator.SetTrigger("TurnRight");
      } else turnRight = false;
          m_Animator.SetTrigger("TurnLeft");


      // Rotation into animator
      if(m_TurnDir == this.transform.rotation.eulerAngles){

          m_Animator.SetFloat("Rotation", 0.0f);
          Debug.Log(m_TurnDir);

      } else{

          m_TurnDir = this.transform.rotation.eulerAngles;
          m_Animator.SetFloat("Rotation", m_TurnDir.y, 0.1f, Time.deltaTime);
          Debug.Log(this.transform.);

      }
      */

        }
    }
}
