using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour {

    // Use this for initialization
    public Animator anim;
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    //Chamado no PlayerHealth linha 81
    public void Died()
    {
        anim.SetBool("Died", true);
    }

    //Chamado no PlayerMovement linha 38
    public void Running()
    {
        anim.SetBool("Idle", false);
        anim.SetBool("Running", true);
    }

    //Chamado no PlayerMovement linha 34
    public void Idle()
    {
        anim.SetBool("Running", false);
        anim.SetBool("Idle", true);
    }

    //Chamado pelo PlayerShoot linha 50
    public void Shooting()
    {
        anim.SetTrigger("Shooting");
    }

    //Chamado no PlayerHealth linha 41
    public void Damaged()
    {
        anim.SetTrigger("Damaged");
    }
}
