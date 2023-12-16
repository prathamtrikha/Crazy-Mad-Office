using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackMenuScript : MonoBehaviour {

	//When PlayerDies BackMenu appears
	//reference to BackMenu Object
	public GameObject backMenuObject;

	// Use this for initialization
	void Start () {
		//initially BackMenu is disabled
		backMenuObject.SetActive (false);
	}

	public void RetryFunction(){
		//When Retrybutton pressed after player dies restart the level
		SceneManager.LoadScene ("level01");
	}

	public void MainMenuFucntion(){
		//When MainMenu Button pressed after player dies navigate to StartMenu
		SceneManager.LoadScene ("StartMenu");
	}

	void Update(){
		//checking if BackMenu is active
		if (backMenuObject.activeInHierarchy) {
			//Game stops including Player and Enemy when BackMenu is active on screen
			Time.timeScale = 0f;
			Cursor.visible = true;
		} else {
			//else everything is normally functioning
			Time.timeScale = 1f;
			Cursor.visible = false;
		}
	}

}
