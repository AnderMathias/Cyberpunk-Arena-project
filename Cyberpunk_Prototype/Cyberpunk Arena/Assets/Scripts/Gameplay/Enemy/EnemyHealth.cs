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
    //NavMesh navMeshCollider;
    bool isDead;
	bool isSinking;

    public ParticleSystem blood;
    public ParticleSystem died;


    void Awake() {
		capsuleCollider = GetComponent <CapsuleCollider>();
        
        //blood = GetComponentInChildren<ParticleSystem>();

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
            blood.Play();
            anim.SetTrigger("Hit");
		}
	}

	void Death(){
		isDead = true;
        gameObject.GetComponent<NavMeshAgent>().height = 0.1f;
        gameObject.GetComponent<NavMeshAgent>().enabled = false;
        died.Play();
        Invoke("StartSinking", sinkDelay);
		capsuleCollider.enabled = false;
		anim.SetTrigger("Dead");
	}

	void StartSinking(){
		GetComponent<NavMeshAgent>().enabled = false;
		GetComponent<Rigidbody>().isKinematic = true;
		isSinking = true;

		Destroy (gameObject,3f);
	}
}
