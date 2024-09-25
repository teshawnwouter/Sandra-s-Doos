using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{

    Animator anim;
    // Start is called before the first frame update

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        anim.SetTrigger("Pressed");
    }

    private void OnCollisionExit(Collision collision)
    {
        anim.SetTrigger("Unpressed");
    }
}
