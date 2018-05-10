using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour {

	public float speed = 5f;
	public float rotationSmoothing = 10f;

	Vector3 movement;
	Rigidbody playerRigidbody;

    private PlayerAnimations anim;
    

    void Awake(){
		playerRigidbody = GetComponent<Rigidbody>();
        anim = GetComponent<PlayerAnimations>();

        //Autoconfigure rigidbody
        playerRigidbody.drag = Mathf.Infinity;
		playerRigidbody.angularDrag = Mathf.Infinity;
		playerRigidbody.constraints = RigidbodyConstraints.FreezePositionY | 
			RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;

	}

	void FixedUpdate(){
		float h = Input.GetAxisRaw("Horizontal");
		float v = Input.GetAxisRaw("Vertical");

        if (h == 0 && v == 0) {
            anim.Idle();
        }
        else if (h != 0 || v != 0)
        {
            anim.Running();
        }

        Move(h,v);

		if(!(h==0 && v==0)){
			Turning();
		}

	}

	void Move(float h, float v){
		movement.Set(h,0f, v);
		movement = movement.normalized * speed * Time.deltaTime;

		playerRigidbody.MovePosition (transform.position + movement);
	}

	void Turning(){
		Vector3 lookDirection = movement*Time.deltaTime;;
		lookDirection.y = 0f;

		Quaternion newRotation = Quaternion.LookRotation(lookDirection);
		Quaternion finalRotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime*rotationSmoothing);
		playerRigidbody.MoveRotation(finalRotation);
	
	}

}
