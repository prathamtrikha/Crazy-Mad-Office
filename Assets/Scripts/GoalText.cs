using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalText : MonoBehaviour {

	//game's MainGoal GameObject appears on Top-Center
	public GameObject goalTextAppear;

	// Use this for initialization
	void Start () {
		//initially setActive is false
		goalTextAppear.SetActive (false);
		//calling a coroutine Function
		StartCoroutine (GoalTextFunction());
	}

	//making a Coroutine function
	IEnumerator GoalTextFunction(){
		//make the GoalText appear
		yield return new WaitForSeconds (0.5f);
		goalTextAppear.SetActive (true);

		//make the GoalText Disappears
		yield return new WaitForSeconds (7f);
		goalTextAppear.SetActive (false);
	}
}
