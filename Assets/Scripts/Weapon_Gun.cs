using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon_Gun : Weapons {

	public float currentAmmo;
	float maxAmmo;

	//gunObject Animator
	Animator gunAnim;

	//gunShot Sound	
	public AudioSource gunShootSource;
	public AudioClip gunShootSound;

	//making BulletSpriteArray for showing bullet amount
	public Transform[] bulletSprite;
	int  bulletSpriteIndex;
	public Text bulletText;

	public Button gunButton;
	public GameObject gunObject;
	Weapon_Gun gunScript;

	[Header("GameEvents")]
	public GameEvent attackToEnemy;
	public GameEvent GunAttackToEnemy;

	// Use this for initialization
	void Start () {
		gunAnim = GetComponent<Animator> ();
		maxAmmo = ammo;
		currentAmmo = maxAmmo;
		readyToShoot = true;
	}
	
	// Update is called once per frame
	void Update () {
		//checking for input
		MyInput ();
	}

	void MyInput(){
		if (Input.GetButtonDown ("Fire1") && readyToShoot == true && currentAmmo > 0) {
			//calling a Coroutine function
			StartCoroutine (Shoot ());

		} 
		if (Input.GetButtonDown("Fire1") && currentAmmo <= 0) {
			StartCoroutine (UpdateBulletText ());
		}
	}


	//making of Coroutine Function
	IEnumerator Shoot(){
		currentAmmo -= 1f;
		readyToShoot = false;
		gunShootSource.PlayOneShot (gunShootSound);
		gunAnim.SetBool ("shoot",true);

		if (bulletSpriteIndex < 3) {
			UpdateBulletSprite ();
			bulletSpriteIndex++;
		} else if (bulletSpriteIndex >= 3 || currentAmmo <= 0 ) {
			StartCoroutine (UpdateBulletText ());
		}

		RaycastHit hit;
		if (Physics.Raycast (Camera.main.transform.position, Camera.main.transform.forward, out hit, range)) {
			if (hit.collider.gameObject.CompareTag ("Enemy")) {
				attackToEnemy.Raise ();
				GunAttackToEnemy.Raise ();
				Debug.Log ("Enemy Hit");
			}
		}

		yield return new WaitForSeconds (0.3f);
		gunAnim.SetBool ("shoot", false);

		Invoke ("ResetShoot", timeBetweenShooting);

		Invoke ("Shoot", reloadTime);

		yield return null;
	}

	void ResetShoot(){
		readyToShoot = true;
	}

	//makes one bulletSprite disappear when gun is fired
	void UpdateBulletSprite(){
		if (bulletSprite [bulletSpriteIndex] != null) {
			bulletSprite [bulletSpriteIndex].gameObject.SetActive (false);
		}
	}

	//shows NoBulletLeft Text if ammoAmount is null
	IEnumerator UpdateBulletText(){
		bulletText.text = "No Bullet Left!";

		yield return new WaitForSeconds (1f);
		bulletText.text = " ";
	}

	//MobileShooting
	public void MobileGunShoot(){
		StartCoroutine (Shoot ());
	}

	//when BulletAmount less than or equal to 0 disable the GunFireButton
	public void BlockGunButton(){
		if (currentAmmo <= 0) {
			gunButton.interactable = false;
		}
	}
}


