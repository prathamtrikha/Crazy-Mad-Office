using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour {

	//Main Camera reference
	Camera mainCam;

	void Start(){
		mainCam = Camera.main;
	}

	//Wherever the Camera rotates, move the 2d sprite with it 
	void LateUpdate(){
		//Gets the direction and magnitude between the object and the player
		Vector3 LookDir = new Vector3 (mainCam.transform.position.x - this.transform.position.x, 0f, mainCam.transform.position.z -
		                  this.transform.position.z);

		//Assigns the Direction where to look to the object and its rotation
		this.transform.rotation = Quaternion.LookRotation (-LookDir.normalized, Vector3.up);

	}

}
