using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngineInternal.Input;

public class control : MonoBehaviour
{
    public Rigidbody2D body;
    
    public Personagem personagem;

    private Animator myAnimator;
    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();

        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
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
    }
}
