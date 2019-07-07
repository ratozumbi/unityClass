using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class control : MonoBehaviour
{

    private Animator myAnimator;
    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") > 0)
        {
            print(Input.GetAxis("Horizontal"));
            
            myAnimator.SetTrigger("start run");
            
        }
        else
        {
            myAnimator.SetTrigger("start idle");
        }
    }
}
