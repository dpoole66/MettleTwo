using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour {             
    //Public
    public float m_StartingHealth = 100.0f;
    public Slider m_E_HealthSlider;
    public Image m_FillImage;
    public Color m_FullHealthColor = Color.green;
    public Color m_ZeroHealthColor = Color.red;
    public GameObject m_DeathPrefab;
    //Private
    private AudioSource m_E_DeathAudio;
    private ParticleSystem m_E_DeathParticles;
    private  float m_E_CurrentHealth;
    private bool m_Dead;


    void Awake() {

        m_E_DeathParticles = Instantiate(m_DeathPrefab).GetComponent<ParticleSystem>();
        m_E_DeathAudio = m_E_DeathParticles.GetComponent<AudioSource>();
        m_E_DeathParticles.gameObject.SetActive(false);

    }

    void OnEnable() {

        m_E_CurrentHealth = m_StartingHealth;
        m_Dead = false;

    }

    // Encapsulated health and death to give to UI or whatever else needs it.
    public float M_E_CurrentHealth{

        get{ return m_E_CurrentHealth; }

    }

    public bool M_Dead{

        get{ return m_Dead;}

    }
    //

    public void TakeDamage(float amount) {

        Debug.Log("EnemyHealth records a hit");

        m_E_CurrentHealth -= amount;

        //UI update
        SetHealthUI();

        //Check for death
        if (m_E_CurrentHealth <= 0f && !m_Dead) {

            OnDeath();

        }

    }

    public void SetHealthUI() {

        m_E_HealthSlider.value = m_E_CurrentHealth;

        m_FillImage.color = Color.Lerp(m_ZeroHealthColor, m_FullHealthColor, m_E_CurrentHealth / m_StartingHealth);

    }

    public void OnDeath() {

        m_Dead = true;
        //death fx
        m_E_DeathParticles.transform.position = transform.position;
        m_E_DeathParticles.gameObject.SetActive(true);
        m_E_DeathParticles.Play();
        //m_E_DeathAudio.Play();
        //deactivate player mettle
        gameObject.SetActive(false);

    }
}
