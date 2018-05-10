using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

	public int startingHealth = 100;
	public int currentHealth;


	CapsuleCollider capsuleCollider;
	bool isDead;
	Animator anim;

	void Awake() {
		capsuleCollider = GetComponent <CapsuleCollider>();

		currentHealth = startingHealth;
		anim = GetComponentInChildren<Animator>();
	}
	

	void Update () {
		
	}

	public void TakeDamage(int amount){
		if(isDead)
			return;

		currentHealth -= amount;

		if(currentHealth <=0){
			Death();
		}else{
			anim.SetTrigger("Hit");
		}
	}

	void Death(){
		isDead = true;

		capsuleCollider.isTrigger = true;
		anim.SetTrigger("Dead");
	}
}
