using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngineInternal.Input;

public class control : MonoBehaviour
{
    public Rigidbody2D body;

    //public SpriteRenderer spriteRen;
    
    public Personagem personagem;

    private Animator myAnimator;

    public float jumpForce;

    private bool grounded = false;
    
    //public Sprite subindo;
    //public Sprite descendo;

    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();

        body = GetComponent<Rigidbody2D>();

        //spriteRen = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        ////MOVIMENTO HORIZONTAL

        if (Input.GetAxis("Horizontal") > 0)
        {
            Vector3 flipar = new Vector3(1, 1, 1);
            transform.localScale = flipar;

            if (body.velocity.magnitude < 4)
            {
                body.AddForce(Vector2.right * 8);
            }

            myAnimator.SetTrigger("run");
            myAnimator.ResetTrigger("idle");

        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            Vector3 flipar = new Vector3(-1, 1, 1);
            transform.localScale = flipar;

            if (body.velocity.magnitude < 4)
            {
                body.AddForce(Vector2.left * 8);
            }

            myAnimator.SetTrigger("run");
            myAnimator.ResetTrigger("idle");
        }
        else
        {
            myAnimator.SetTrigger("idle");
            myAnimator.ResetTrigger("run");
        }

        if (Input.GetAxis("Vertical") > 0 && grounded)
        {
            body.AddForce(Vector2.up*jumpForce);
        }
        
        if (body.velocity.y > 0)
        {
         myAnimator.SetTrigger("pulo");  
        }
        else if (body.velocity.y < 0)
        {
            myAnimator.ResetTrigger("pulo");
            myAnimator.SetTrigger(("queda"));
        }

        else if (body.velocity.y == 0)
        {
            myAnimator.ResetTrigger("pulo");
            myAnimator.ResetTrigger("queda");
        }
    }

//    private void LateUpdate()
//    {
//        if (body.velocity.y > 0)
//        {
//            spriteRen.sprite = subindo;
//        }
//
//        if (body.velocity.y < 0)
//        {
//            spriteRen.sprite = descendo;
//        }
//    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.name == "colliderGround")
        {
            print("sai do chão");
            grounded = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.transform.name == "colliderGround")
        {
            print("volta ao chão");
            grounded = false;
        }
    }
}