using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSwitch : MonoBehaviour {

	public Weapon_Punch punchScript;
	public Weapon_Gun gunScript;

	bool isPunch;
	bool isGun;

	public GameObject gunObject;
	public GameObject punchObject;
	public GameObject weaponPickUp;

	public GameObject Key2Image;
	public GameObject Key2Text;

	//for MobileButton SpriteArray
	public GameObject mobilePunchBtn;
	public GameObject mobileGunBtn;
	bool toChange;

	// Use this for initialization
	void Start () {
		punchObject.SetActive (true);
		gunObject.SetActive (false);
		gunScript.enabled = false;
		mobileGunBtn.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		//for switching punch weapon for desktop
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			isPunch = !isPunch;
			if (isPunch) {
				punchObject.SetActive (false);
				punchScript.enabled = false;
			} else {
				punchObject.SetActive (true);
				punchScript.enabled = true;
			}
			gunObject.SetActive (false);
			gunScript.enabled = false;
		}

		//for switching gun weapon for desktop
		//weaponPickUp == null checking if it is Active in scene
		if (Input.GetKeyDown (KeyCode.Alpha2) && weaponPickUp == null) {
			isGun = !isGun;
			Key2Image.SetActive (true);
			Key2Text.SetActive (true);
			if (isGun) {
				gunObject.SetActive (true);
				gunScript.enabled = true;
			} else {
				gunObject.SetActive (false);
				gunScript.enabled = false;
			}
			punchObject.SetActive (false);
			punchScript.enabled = false;
		}

	}

	//WeaponSwitch for MobileVersion
	public void MobileWeaponSwitch(){
		toChange = !toChange;
		if (toChange == true) {
			mobilePunchBtn.SetActive (false);
			mobileGunBtn.SetActive (true);
			gunScript.enabled = true;

			punchObject.SetActive (false);
			gunObject.SetActive (true);
		}
		if (toChange == false) {
			mobilePunchBtn.SetActive (true);
			mobileGunBtn.SetActive (false);

			punchObject.SetActive (true);
			gunObject.SetActive (false);
		}

	}

}
