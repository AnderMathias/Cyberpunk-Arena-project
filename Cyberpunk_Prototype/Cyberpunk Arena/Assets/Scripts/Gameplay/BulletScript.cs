using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {
	public int damage = 10;
	public float lifeTime = 5f;
	public GameObject parentEnemy;

	float timer;
	

	void Update () {
		timer += Time.deltaTime;

		if(timer > lifeTime){
			Explode();
		}		
	}

	void OnTriggerEnter(Collider other){
		if(other.gameObject.CompareTag("Player")){
			other.GetComponent<PlayerHealth>().TakeDamage(damage);
			Destroy(this.gameObject);
		}else{
			if(other.gameObject != parentEnemy){
				Explode();
			}
		}
	}

	void Explode(){
		Destroy(this.gameObject);
	}
}
