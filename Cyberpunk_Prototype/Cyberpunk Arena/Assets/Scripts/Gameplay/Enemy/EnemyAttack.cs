using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {

	public float timeBetweenAttacks= 1f;
	public int attackDamage = 10;
	public float attackRange = 2f;

	GameObject player;
	PlayerHealth playerHealth;
	EnemyHealth enemyHealth;
	EnemyMovement enemyMovement;
	bool playerInRange;
	float timer;

	Animator anim;


	void Awake () {
		player = GameObject.FindGameObjectWithTag("Player");
		playerHealth = player.GetComponent<PlayerHealth>();
		enemyHealth = GetComponent<EnemyHealth>();
		enemyMovement = GetComponent<EnemyMovement>();
		anim = GetComponentInChildren<Animator>();
	}


	void Update(){
		timer += Time.deltaTime;

		if(timer >= timeBetweenAttacks && enemyHealth.currentHealth>0){
			if(Vector3.Distance(transform.position,player.transform.position) < attackRange){
				Attack();
				enemyMovement.chasePlayer = false;
			}else{
				enemyMovement.chasePlayer = true;
			}
		}

	}

	void Attack(){
		timer = 0f;
		anim.SetTrigger("Attack");
		if(playerHealth.currentHealth >0){
			playerHealth.TakeDamage(attackDamage);
		}
	}

}
