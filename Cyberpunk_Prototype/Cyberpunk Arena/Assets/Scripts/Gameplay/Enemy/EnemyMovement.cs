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

	public bool chasePlayer;
	public float stoppedRotationSpeed = 5f;


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

		chasePlayer = true;
	}

	void Update (){
		if(enemyHealth.currentHealth >0 && playerHealth.currentHealth >0){
			if(chasePlayer){
				if(nav.isStopped){
					nav.isStopped = false;
				}
				nav.SetDestination(player.position);
			}else{
				nav.isStopped = true;
				Vector3 lookPos = player.position - transform.position;
				lookPos.y = 0;
				Quaternion rotation = Quaternion.LookRotation(lookPos);
				transform.rotation = Quaternion.Slerp(transform.rotation,rotation,stoppedRotationSpeed*Time.deltaTime);
			}
		}else{
			nav.enabled = false;
		}

	}
}
