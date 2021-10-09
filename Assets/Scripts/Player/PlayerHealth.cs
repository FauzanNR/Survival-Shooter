using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerHealth: MonoBehaviour {
	public int startingHealth = 100;
	public int currentHealth;
	public Slider healthSlider;
	public Image damageImage;
	public AudioClip deathClip;
	public float flashSpeed = 5f;
	public Color flashColour = new Color( 1f, 0f, 0f, 0.1f );


	Animator anim;
	AudioSource playerAudio;
	PlayerMovement playerMovement;
	PlayerShooting playerShooting;
	InputHandler input;

	bool isDead;
	bool damaged;


	void Awake() {
		anim = GetComponent<Animator>();
		playerAudio = GetComponent<AudioSource>();
		input = GetComponent<InputHandler>();
		playerMovement = GetComponent<PlayerMovement>();
		playerShooting = GetComponentInChildren<PlayerShooting>();

		currentHealth = startingHealth;
	}


	void Update() {
		if(damaged) {
			damageImage.color = flashColour;
		} else {
			damageImage.color = Color.Lerp( damageImage.color, Color.clear, flashSpeed * Time.deltaTime );
		}

		if(currentHealth > startingHealth) {
			currentHealth = startingHealth;
		}
		healthSlider.value = currentHealth;
		damaged = false;
	}


	public void TakeDamage(int amount) {
		damaged = true;

		currentHealth -= amount;

		healthSlider.value = currentHealth;

		playerAudio.Play();

		if(currentHealth <= 0 && !isDead) {
			Death();
		}
	}


	void Death() {
		isDead = true;

		playerShooting.DisableEffects();
		anim.SetTrigger( "Die" );

		playerAudio.clip = deathClip;
		playerAudio.Play();

		playerMovement.enabled = false;
		playerShooting.enabled = false;
		input.enabled = false;
	}

	private void OnTriggerEnter(Collider other) {
		float itemDistance = Vector3.Distance( transform.position, other.transform.position );
		if(other.tag == "Respawn" && itemDistance < 3) {
			currentHealth += 20;
		}
	}
}
