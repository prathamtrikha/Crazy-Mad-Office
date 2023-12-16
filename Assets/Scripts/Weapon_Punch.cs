using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Punch : Weapons {

	SpriteRenderer spriteRen;

	public AudioClip punchSound;
	public AudioSource punchSource;
	float damagee = 10f;
	Animator anim;
	public Animator anim2;

	[Header("GameEvetns")]
	public GameEvent attackToEnemy;
	public GameEvent enemyHealth;

	// Use this for initialization
	void Start () {
		spriteRen = GetComponent<SpriteRenderer> ();
		anim = GetComponent<Animator> ();
		readyToShoot = true;
		range = 2f;
		timeBetweenShooting = 0.2f;
		reloadTime = 0.3f;
	}
	
	// Update is called once per frame
	void Update () {
		MyInput ();
	}

	void MyInput(){
		if (Input.GetButton ("Fire1") && readyToShoot) {
			StartCoroutine (Shoot ());
		}
	}

	IEnumerator Shoot(){
		readyToShoot = false;
	
		anim.SetTrigger("punch");

		anim2.SetBool("pun" , true);
		punchSource.PlayOneShot (punchSound);
		RaycastHit hit;

		if (Physics.Raycast (Camera.main.transform.position, Camera.main.transform.forward, out hit, range)) {
			if (hit.transform.gameObject.CompareTag ("Enemy")) {
				attackToEnemy.Raise ();
				enemyHealth.Raise ();
			}
		}

		yield return new WaitForSeconds (0.4f);
		anim2.SetBool ("pun", false);


		Invoke ("ResetShoot", timeBetweenShooting);

		Invoke ("Shoot", reloadTime);


	}

	void ResetShoot(){
		readyToShoot = true;
	}

	public void MobilePunchButton(){
		StartCoroutine (Shoot ());
	}

}
