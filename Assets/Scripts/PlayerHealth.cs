using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

	public float maxHealth = 100;
	public float currentHealth;

	public Image healthBar;
	public Image easeHealthBar;

	float LerpTime ;
	float chipSpeed = 2f;

	public AudioSource damageSource;
	public AudioClip damageSound;

	public AudioSource playerDieAudioSource;
	public AudioClip playerDieSound;

	//death cam components
	public GameObject desktopCam;
	public GameObject mobileCam;
	public Camera deathCam;
	public GameObject backMenu;
	//public Animator deathCamAnim;

	//player controller
	public GameObject DesktopController;
	public GameObject MobileController;

	// Use this for initialization
	void Start () {
		currentHealth = maxHealth;	
		LerpTime = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		//update the HealthUI when there is change in Player Health
		UpdateUI ();
			
	}

	//function for taking damage from Enemy
	public void Damage(float damage){
		currentHealth -= damage;
		damageSource.PlayOneShot (damageSound);
		healthBar.fillAmount = currentHealth / maxHealth;
		if (currentHealth <= 0f) {
			currentHealth = 0f;
			//make controller deactive
			desktopCam.SetActive(false);
			mobileCam.SetActive (false);

			//deathcam animation active
			deathCam.gameObject.SetActive(true);
			playerDieAudioSource.PlayOneShot (playerDieSound);
			//making BackMenu enable
			StartCoroutine (EnableBackMenu ());
		}

	}

	//function for healing player when picksUp healthPickUp
	public void Heal(float heal){
		currentHealth += heal;
		if (currentHealth >= 100f) {
			currentHealth = maxHealth;
		}
		healthBar.fillAmount = currentHealth / maxHealth;
		easeHealthBar.fillAmount = healthBar.fillAmount; 
	}

	//updating the HealthUI
	void UpdateUI(){
		if (easeHealthBar.fillAmount > healthBar.fillAmount) {
			easeHealthBar.fillAmount = Mathf.Lerp (easeHealthBar.fillAmount, currentHealth / maxHealth, (LerpTime + Time.deltaTime) 
				* chipSpeed);
		}
	}

	//making of coroutine Function
	IEnumerator EnableBackMenu(){
		yield return new WaitForSeconds (2f);
		backMenu.SetActive (true);
	}

}

