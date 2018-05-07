using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Rigidbody))]
public class EnemyMovement : MonoBehaviour {
	
	Rigidbody enemyRigidbody;

	Transform player;
	PlayerHealth playerHealth;
	EnemyHealth enemyHealth;
	NavMeshAgent nav;


	void Awake(){
		enemyRigidbody = GetComponent<Rigidbody>();

		//Autoconfigure rigidbody
		enemyRigidbody.drag = Mathf.Infinity;
		enemyRigidbody.angularDrag = Mathf.Infinity;
		enemyRigidbody.constraints = RigidbodyConstraints.FreezePositionY | 
			RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;

		player = GameObject.FindGameObjectWithTag("Player").transform;
		playerHealth = player.GetComponent<PlayerHealth>();
		enemyHealth = GetComponent<EnemyHealth>();
		nav = GetComponent<NavMeshAgent>();
	}

	void Update (){
		if(enemyHealth.currentHealth >0 && playerHealth.currentHealth >0){
			nav.SetDestination(player.position);
		}else{
			nav.enabled = false;
		}

	}

}
