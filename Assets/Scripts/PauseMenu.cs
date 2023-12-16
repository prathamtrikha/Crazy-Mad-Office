using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

	//PauseMenu for game when [Esc] key is pressed
	public GameObject pauseMenu;

	bool isPaused;

	// Use this for initialization
	void Start () {
		//initially PauseMenu is setActive false
		pauseMenu.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		//checking if [Esc] key is pressed
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (isPaused) {
				//if already Paused Resume the Game
				ResumeGame ();
			} else {
				//if not already Paused, make the game pause and PauseMenu Object appears
				PauseGame();
			}
		}
	}

	//function for pausing the game
	void PauseGame(){
		Time.timeScale = 0f;
		pauseMenu.SetActive(true);
		Cursor.visible = true;
		isPaused = true;
	}

	//function for resuming the game back
	public void ResumeGame(){
		Time.timeScale = 1f;
		pauseMenu.SetActive (false);
		Cursor.visible = false;
		isPaused = false;
	}

}
