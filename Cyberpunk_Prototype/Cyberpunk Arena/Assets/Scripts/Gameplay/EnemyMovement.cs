using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Rigidbody))]
public class EnemyMovement : MonoBehaviour {
	
	Rigidbody enemyRigidbody;

	Transform player;
	NavMeshAgent nav;


	void Awake(){
		enemyRigidbody = GetComponent<Rigidbody>();

		//Autoconfigure rigidbody
		enemyRigidbody.drag = Mathf.Infinity;
		enemyRigidbody.angularDrag = Mathf.Infinity;
		enemyRigidbody.constraints = RigidbodyConstraints.FreezePositionY | 
			RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;

		player = GameObject.FindGameObjectWithTag("Player").transform;
		nav = GetComponent<NavMeshAgent>();
	}

	void Update (){
		nav.SetDestination(player.position);
	}

}
