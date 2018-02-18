using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {
    //Public
    public float m_StartingHealth = 100.0f;
    public  Slider m_P_HealthSlider;
    public Image m_FillImage;
    public Color m_FullHealthColor = Color.green;
    public Color m_ZeroHealthColor = Color.red;
    public GameObject m_DeathPrefab;
    //Private
    private AudioSource m_P_DeathAudio;
    private ParticleSystem m_P_DeathParticles;
    private  float m_P_CurrentHealth;
    private bool m_Dead;


	void Awake () {

        m_P_DeathParticles = Instantiate(m_DeathPrefab).GetComponent<ParticleSystem>();
        m_P_DeathAudio = m_P_DeathParticles.GetComponent<AudioSource>();
        m_P_DeathParticles.gameObject.SetActive(false);
		
	}

	void OnEnable() {

        m_P_CurrentHealth = m_StartingHealth;
        m_Dead = false;      

    }

    //Encapsulating Health/Dead to send to whatever needs it.
    public float M_P_CurrentHealth{

    get{ return m_P_CurrentHealth; }

    }

    public bool M_Dead{

    get{ return m_Dead; }

    }

    public void TakeDamage(float amount){

        Debug.Log("PlayerHealth records a hit");

        m_P_CurrentHealth -= amount;

        //UI update
        SetHealthUI();

        //Check for death
        if(m_P_CurrentHealth <= 0f && !m_Dead){

            OnDeath();

        }

    }

    public  void SetHealthUI() {

        m_P_HealthSlider.value = m_P_CurrentHealth;

        m_FillImage.color = Color.Lerp(m_ZeroHealthColor, m_FullHealthColor, m_P_CurrentHealth / m_StartingHealth);

    }

   public  void OnDeath(){

        m_Dead = true;
        //death fx
        m_P_DeathParticles.transform.position = transform.position;
        m_P_DeathParticles.gameObject.SetActive(true);
        m_P_DeathParticles.Play();
        //m_P_DeathAudio.Play();
        //deactivate player mettle
        gameObject.SetActive(false);

    }

}
