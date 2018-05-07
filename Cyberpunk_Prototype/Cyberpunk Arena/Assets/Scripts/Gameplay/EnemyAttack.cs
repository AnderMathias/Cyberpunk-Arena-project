using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {

	public int timeBetweenAttacks= 1;
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
