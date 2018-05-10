using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour {

	public int startingHealth = 100;
	public int currentHealth;
	public float sinkSpeed = 0.5f;
	public float sinkDelay = 2f;

	Animator anim;
	CapsuleCollider capsuleCollider;
	bool isDead;
	bool isSinking;


	void Awake() {
		capsuleCollider = GetComponent <CapsuleCollider>();

		currentHealth = startingHealth;
		anim = GetComponentInChildren<Animator>();
	}
	

	void Update () {
		if(isSinking){
			transform.Translate(-Vector3.up * sinkSpeed * Time.deltaTime);
		}
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

		Invoke("StartSinking", sinkDelay);
		capsuleCollider.isTrigger = true;
		anim.SetTrigger("Dead");
	}

	void StartSinking(){
		GetComponent<NavMeshAgent>().enabled = false;
		GetComponent<Rigidbody>().isKinematic = true;
		isSinking = true;

		Destroy (gameObject,3f);
	}
}
