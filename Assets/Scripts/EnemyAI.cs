using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class EnemyAI : MonoBehaviour {

	NavMeshAgent agent;
	public Transform[] wayPoints;
	Vector3 target;
	float chasingDistance = 10f;
	float attackDistance = 1f;

	public GameEvent playerHealthDecreaseEvent;
	public Transform playerDesktop;
	public Transform playerMobile;
	public bool isAttack;
	public float timeBetweeenAttack;

	Animator anim;
	SpriteRenderer enemySprite;

	//Enemy's Heath
	float maxHealth = 100f;

	public float currentHealth;


	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent> ();
		anim = GetComponent<Animator> ();
		enemySprite = GetComponent<SpriteRenderer> ();
		UpdateDestination ();
		isAttack = true;
		timeBetweeenAttack = 1.5f;
		currentHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		Chase ();

	}

	void UpdateDestination(){
		int random = Random.Range (0, wayPoints.Length);
		target = wayPoints [random].position;
		agent.SetDestination (target);
	}

	void Chase(){
		if (playerDesktop.gameObject.activeInHierarchy) {
			if (Vector3.Distance (transform.position, playerDesktop.position) < chasingDistance) {
				target = playerDesktop.position;
			}
		}else {
			target = playerMobile.position;
		}
			
		agent.SetDestination (target);

		if (Vector3.Distance (transform.position, target) < 1) {
			UpdateDestination ();
		}

		if (playerDesktop.gameObject.activeInHierarchy) {
			if (Vector3.Distance (playerDesktop.position, transform.position) < attackDistance) {
				Attack ();
				agent.speed = 0;
			} 
		}else {
			agent.speed = 2;
		}

		if (playerMobile.gameObject.activeInHierarchy) {
			if (Vector3.Distance (playerMobile.position, transform.position) < attackDistance) {
				Attack ();
				agent.speed = 0;
			} 
		}else {
			agent.speed = 2;
		}

	}

	void Attack(){
		
		if (isAttack) {
			anim.SetBool("attack", true);
			playerHealthDecreaseEvent.Raise();
			isAttack = false;
			Invoke("ResetTime", timeBetweeenAttack);
		}
		else {
			anim.SetBool("attack", false);
		}
	}

	void ResetTime(){
		isAttack = true;
	}

	public void EnemyRed(){
		//enemySprite.color = Color.red;

		Invoke ("EnemyChangeRed", 0.3f);
	}

	void EnemyChangeRed(){
		enemySprite.color = Color.red;
		Invoke ("EnemyChangeWhite", 0.5f);
	}

	void EnemyChangeWhite(){
		enemySprite.color = Color.white;
	}


	//health function

	public void EnemyHealthDamage(float damage){
		currentHealth -= damage;
		if (currentHealth <= 0) {
			Invoke ("DestroyEnemy", 0.2f);
		}
	}

	void DestroyEnemy(){
		Destroy (this.gameObject);
	}

}
