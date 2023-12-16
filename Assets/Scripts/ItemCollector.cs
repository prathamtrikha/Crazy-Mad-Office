using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ItemCollector : MonoBehaviour {

	public Text cashPowerUpText;
	public Text goalText;

	public AudioSource itemPickUpSoundSource;
	public AudioClip itemPickUpSound;

	public Button WeaponSwitchButton;

	int maxScore = 0;

	//GameEvents created using GameEvent Script
	[Header("Events")]
	public GameEvent cashGameEvent;
	public GameEvent burgerGameEvent;

	void Start(){
		WeaponSwitchButton.interactable = false;
	}

	// Use this for initialization
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("Player")) {
			if (this.gameObject.CompareTag("pickup")) {
				itemPickUpSoundSource.PlayOneShot (itemPickUpSound);

				//Checking for which Object is picked
				if (this.gameObject.name == "CashPowerUp") {
					cashGameEvent.Raise ();
				}
				if (this.gameObject.name == "HealthPowerUp") {
					burgerGameEvent.Raise ();
				}
				if (this.gameObject.name == "WeaponPowerUp") {
					WeaponSwitchButton.interactable = true;
				}
				if (this.gameObject.name == "KeyPowerUp") {
					SceneManager.LoadScene ("LevelClear");
				}
				//destroy when object is pickedup
				Destroy (this.gameObject);
			}
		}
	}

	//Increase CashScore each by 1 when pickedUp
	public void CashPickUp(){
		maxScore += 1;
		cashPowerUpText.text = maxScore.ToString();
	}

}
