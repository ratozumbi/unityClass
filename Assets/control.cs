using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngineInternal.Input;

public class control : MonoBehaviour
{
    public Rigidbody2D body;
    
    public Personagem personagem;

    private Animator myAnimator;

    private float jumpForce;

    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();

        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        ////MOVIMENTO HORIZONTAL
        
        if (Input.GetAxis("Horizontal") > 0)
        {
            Vector3 flipar = new Vector3(1,1,1);
            transform.localScale = flipar;
            
            if (body.velocity.magnitude < 4)
            {
                body.AddForce(Vector2.right*8);    
            }
            
            myAnimator.SetTrigger("start run");
            myAnimator.ResetTrigger("start idle");
            
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            Vector3 flipar = new Vector3(-1,1,1);
            transform.localScale = flipar;
            
            if (body.velocity.magnitude < 4)
            {
                body.AddForce(Vector2.left*8);    
            }

            myAnimator.SetTrigger("start run");
            myAnimator.ResetTrigger("start idle");  
        }
        else
        {
            myAnimator.SetTrigger("start idle");
            myAnimator.ResetTrigger("start run");
        }
        
        ////MOVIMENTO VERTICAL

        if (Input.GetKeyDown(KeyCode.UpArrow) && Input.GetAxis("Vertical") < 0.07)
        {
            jumpForce = 230;
            body.AddForce(Vector2.up * jumpForce);

        }

        else
        {
            jumpForce = 0;
        }

    }
}
