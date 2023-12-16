using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformCompilation : MonoBehaviour {

	//this script is platform Dependent

	public GameObject desktopController;
	public GameObject mobileController;

	public GameObject WeaponSwitchText;
	public GameObject rightHand;


	//ActivatePlayerController in Mobile Only
	public GameObject touchField;
	public GameObject touchJoystick;
	public GameObject mobilePunchButton;
	public GameObject mobileGunButton;
	public GameObject weaponSwitchButton;

	// Use this for initialization
	void Awake () {
		//if Platform on which game is running is Android || IOS
		#if UNITY_ANDROID || UNITY_IPHONE
		//make desktopController disappear
		desktopController.SetActive(false);
		//make mobileController appear and related buttons for MobileDevice
		mobileController.SetActive(true);
		WeaponSwitchText.SetActive(false);
		rightHand.SetActive(true);

		//playerController Activate
		touchField.SetActive(true);
		touchJoystick.SetActive(true);
		mobilePunchButton.SetActive(true);
		mobileGunButton.SetActive(true);
		weaponSwitchButton.SetActive(true);
		#endif
	}
	
	
}
