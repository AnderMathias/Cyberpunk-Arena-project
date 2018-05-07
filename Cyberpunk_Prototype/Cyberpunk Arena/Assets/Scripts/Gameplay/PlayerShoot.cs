﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {

	public int damagePerShot = 10;
	public float timeBetweenShots = 0.2f;
	public float range = 50;


	float shotTimer;
	Ray shootRay;
	RaycastHit shootHit;
	int shootableMask;
	LineRenderer gunLine;
	Light gunLight;
	float effctsDisplayTime = 0.2f;


	void Awake () {
		shootableMask = LayerMask.GetMask("Shootable");
		gunLine = GetComponent<LineRenderer>();
		gunLight = GetComponent<Light>();
				
	}
	
	// Update is called once per frame
	void Update () {
		shotTimer += Time.deltaTime;

		if(Input.GetButton("Fire1") && shotTimer >= timeBetweenShots){
			Shoot();
		}

		if(shotTimer >= timeBetweenShots * effctsDisplayTime){
			DisableEffects();
		}
	}

	public void DisableEffects(){
		gunLine.enabled = false;
		gunLight.enabled = false;
	}

	void Shoot(){
		shotTimer = 0f;

		gunLight.enabled = true;
		gunLine.enabled = true;
		gunLine.SetPosition(0,transform.position);

		shootRay.origin = transform.position;
		shootRay.direction = transform.forward;

		if(Physics.Raycast (shootRay, out shootHit, range, shootableMask)){

			//verificar e dar dano no inimigo AQUI


			gunLine.SetPosition(1,shootHit.point);
		}else{
			gunLine.SetPosition(1,shootRay.origin + shootRay.direction*range);
		}
	}
}