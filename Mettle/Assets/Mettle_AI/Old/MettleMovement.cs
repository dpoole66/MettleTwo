using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MettleMovement : MonoBehaviour {

    public int m_MettleNumber = 0;              // Used to identify which Mettle belongs to which player.  This is set by this Mettle's manager.
    public float m_Speed = 12f;                 // How fast the Mettle moves forward and back.
    public float m_TurnSpeed = 180f;            // How fast the Mettle turns in degrees per second.
    public AudioSource m_MovementAudio;         // Reference to the audio source used to play engine sounds. NB: different to the shooting audio source.
    public AudioClip m_MettleIdle;              // Audio to play when the Mettle isn't moving.
    public AudioClip m_MettleMoving;            // Audio to play when the Mettle is moving.
    public float m_PitchRange = 0.2f;           // The amount by which the pitch of the engine noises can vary.

    private string m_MovementAxisName;          // The name of the input axis for moving forward and back.
    private string m_TurnAxisName;              // The name of the input axis for turning.
    private Rigidbody m_Rigidbody;              // Reference used to move the Mettle.
    private Animator m_Anim;
    private float m_MovementInputValue;         // The current value of the movement input.
    private float m_TurnInputValue;             // The current value of the turn input.
    private float m_OriginalPitch;              // The pitch of the audio source at the start of the scene.



    private void Awake() {
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Anim = GetComponent<Animator>();
    }


    private void OnEnable() {
        // When the Mettle is turned on, make sure it's not kinematic.
        m_Rigidbody.isKinematic = false;

        // Also reset the input values.
        m_MovementInputValue = 0f;
        m_TurnInputValue = 0f;

    }


    private void OnDisable() {
        // When the Mettle is turned off, set it to kinematic so it stops moving.
        m_Rigidbody.isKinematic = true;

    }


    private void Start() {
        // The axes names are based on player number.
        m_MovementAxisName = "Vertical" + m_MettleNumber;
        m_TurnAxisName = "Horizontal" + m_MettleNumber;

        MettleAudio();
    }


    private void Update() {
        // Store the value of both input axes.
        m_MovementInputValue = Input.GetAxis(m_MovementAxisName);
        m_TurnInputValue = Input.GetAxis(m_TurnAxisName);

        MettleAudio();
    }


    private void FixedUpdate() {
        // Adjust the rigidbodies position and orientation in FixedUpdate.
        Move();
        Turn();
    }


    private void Move() {
        // Create a vector in the direction the Mettle is facing with a magnitude based on the input, speed and the time between frames.
        Vector3 movement = transform.forward * m_MovementInputValue * m_Speed * Time.deltaTime;

        // Apply this movement to the rigidbody's position.
        m_Rigidbody.MovePosition(m_Rigidbody.position + movement);   
        

    }


    private void Turn() {
        // Determine the number of degrees to be turned based on the input, speed and time between frames.
        float turn = m_TurnInputValue * m_TurnSpeed * Time.deltaTime;

        // Make this into a rotation in the y axis.
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);

        // Apply this rotation to the rigidbody's rotation.
        m_Rigidbody.MoveRotation(m_Rigidbody.rotation * turnRotation);


    }

        private void MettleAudio() {
        // If there is no input (the tank is stationary)...
        if (Mathf.Abs(m_MovementInputValue) < 0.1f && Mathf.Abs(m_TurnInputValue) < 0.1f) {
            // ... and if the audio source is currently playing the driving clip...
            if (m_MovementAudio.clip == m_MettleMoving) {
                // ... change the clip to idling and play it.
                m_MovementAudio.clip = m_MettleIdle;
                m_MovementAudio.pitch = Random.Range(m_OriginalPitch - m_PitchRange, m_OriginalPitch + m_PitchRange);
                m_MovementAudio.Play();
            }
        } else {
            // Otherwise if the tank is moving and if the idling clip is currently playing...
            if (m_MovementAudio.clip == m_MettleIdle) {
                // ... change the clip to driving and play.
                m_MovementAudio.clip = m_MettleMoving;
                m_MovementAudio.pitch = Random.Range(m_OriginalPitch - m_PitchRange, m_OriginalPitch + m_PitchRange);
                m_MovementAudio.Play();
            }
        }
    }
}
