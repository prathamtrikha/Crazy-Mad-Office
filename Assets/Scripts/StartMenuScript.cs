using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//make cursor visible on StartMenu
		Cursor.visible = true;
	}

	//When Startbutton on StartMenu pressed
	public void StartButton(){
		//navigate to GameLevel
		SceneManager.LoadScene ("level01");
	}

	//Quit the game
	public void ExitButton(){
		Application.Quit();
	}

}
