using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour {
		
	public GameEvent gameEvent;

	public UnityEvent response;

	public void OnEnable(){
		gameEvent.RegisterListener (this);
	}

	public void OnDisable(){
		gameEvent.UnregisterListener (this);
	}

	public void OnEnableResponse(){
		response.Invoke ();
	}

}
