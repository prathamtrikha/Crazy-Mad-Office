using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour {

	void Start(){
		//When Player Wins the game
		//make cursor visible on screen
		Cursor.visible = true;
		Screen.lockCursor = false;
	}


	//When BackMenu button pressed navigate to StartMenu Screen
	public void BackMenu(){
		SceneManager.LoadScene("StartMenu");
	}
	

}
