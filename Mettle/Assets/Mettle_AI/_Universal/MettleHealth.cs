using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MettleHealth : MonoBehaviour {

    //Public
    public float m_StartingHealth = 100.0f;
    public Slider m_HealthSlider;
    public Image m_FillImage;
    public Color m_FullHealthColor = Color.green;
    public Color m_ZeroHealthColor = Color.red;
    public GameObject m_DeathPrefab;
    //Private
    private AudioSource m_DeathAudio;
    private ParticleSystem m_DeathParticles;
    private float m_CurrentHealth;
    private bool m_Dead;


    void Awake() {

        m_DeathParticles = Instantiate(m_DeathPrefab).GetComponent<ParticleSystem>();
        m_DeathAudio = m_DeathParticles.GetComponent<AudioSource>();
        m_DeathParticles.gameObject.SetActive(false);

    }

    void OnEnable() {

        m_CurrentHealth = m_StartingHealth;
        m_Dead = false;

    }

    //Encapsulating Health/Dead to send to whatever needs it.
    public float M_P_CurrentHealth {

        get { return m_CurrentHealth; }

    }

    public bool M_Dead {

        get { return m_Dead; }

    }

    public void TakeDamage(float amount) {

        Debug.Log("MettleHealth records a hit");

        m_CurrentHealth -= amount;

        //UI update
        SetHealthUI();

        //Check for death
        if (m_CurrentHealth <= 0f && !m_Dead) {

            OnDeath();

        }

    }

    public void SetHealthUI() {

        m_HealthSlider.value = m_CurrentHealth;

        m_FillImage.color = Color.green;

    }

    public void OnDeath() {

        m_Dead = true;
        //death fx
        m_DeathParticles.transform.position = transform.position;
        m_DeathParticles.gameObject.SetActive(true);
        m_DeathParticles.Play();
        //m_DeathAudio.Play();
        //deactivate player mettle
        gameObject.SetActive(false);

    }
}
