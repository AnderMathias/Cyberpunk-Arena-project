using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

	public int startingHealth = 100;
	public int currentHealth;


	CapsuleCollider capsuleCollider;
	bool isDead;


	void Awake() {
		capsuleCollider = GetComponent <CapsuleCollider>();

		currentHealth = startingHealth;
	}
	

	void Update () {
		
	}

	public void TakeDamage(int amount){
		if(isDead)
			return;

		currentHealth -= amount;

		if(currentHealth <=0){
			Death();
		}
	}

	void Death(){
		isDead = true;

		capsuleCollider.isTrigger = true;
		
	}
}
