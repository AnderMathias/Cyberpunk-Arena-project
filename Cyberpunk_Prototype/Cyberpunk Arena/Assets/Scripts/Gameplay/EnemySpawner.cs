using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	public PlayerHealth playerHealth;
	public GameObject enemy;
	public float spawnTime;
	public Transform[] spawnPoints;


	// Use this for initializations
	void Start () {
		InvokeRepeating("Spawn", spawnTime, spawnTime);
	}

	void Spawn(){
		if(playerHealth.currentHealth<=0){	
			return;
		}

		int spawnPointIndex = Random.Range(0,spawnPoints.Length);

		Instantiate (enemy, spawnPoints[spawnPointIndex].position,spawnPoints[spawnPointIndex].rotation);
	}
}
