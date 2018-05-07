using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {

	public float timeBetweenAttacks= 0.5f;
	public float attackDamage = 10;

	GameObject player;
	EnemyMovement enemyMove;
	bool playerInRange;
	float timer;


	void Awake () {
		player = GameObject.FindGameObjectWithTag("Player");
		enemyMove = GetComponent<EnemyMovement>();
	}

	void OnTriggerEnter (Collider other){
		if(other.gameObject == player){
			playerInRange = true;
		}
	}

	void OnTriggerExit (Collider other){
		if( other.gameObject == player){
			playerInRange = false;
		}
	}


	void Update(){
		timer += Time.deltaTime;

		if(timer >= timeBetweenAttacks && playerInRange){
			Attack();
		}
	}

	void Attack(){
		timer = 0f;
	}

}
