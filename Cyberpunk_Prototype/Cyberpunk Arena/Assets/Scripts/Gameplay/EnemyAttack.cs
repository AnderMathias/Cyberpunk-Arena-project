using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {

	public int timeBetweenAttacks= 0.5f;
	public int attackDamage = 10;

	GameObject player;
	bool playerInRange;
	float timer;


	void Awake () {
		player = GameObject.FindGameObjectWithTag("Player");		
	}

	void OnTriggerEnter (Collider other){
		if(other.gameObject == player){
			playerInRange = true;
		}
	}

}
