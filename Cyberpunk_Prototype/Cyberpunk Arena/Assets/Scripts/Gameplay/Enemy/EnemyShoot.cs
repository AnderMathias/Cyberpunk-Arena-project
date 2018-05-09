using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot: MonoBehaviour {

	public float timeBetweenAttacks= 1f;
	public int attackDamage = 10;
	public float attackRange = 5f;

	public Transform bulletProjectile;
	public float bulletSpeed = 200f;
	public Transform bulletSource;


	GameObject player;
	PlayerHealth playerHealth;
	EnemyHealth enemyHealth;
	EnemyMovement enemyMovement;
	bool playerInRange;
	float timer;


	void Awake () {
		player = GameObject.FindGameObjectWithTag("Player");
		playerHealth = player.GetComponent<PlayerHealth>();
		enemyHealth = GetComponent<EnemyHealth>();
		enemyMovement = GetComponent<EnemyMovement>();
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

		Transform bullet = Instantiate(bulletProjectile,transform.position,transform.rotation);

		bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward*bulletSpeed);
		bullet.GetComponent<BulletScript>().parentEnemy = transform.gameObject;
//		if(playerHealth.currentHealth >0){
//			playerHealth.TakeDamage(attackDamage);
//		}
	}

}
