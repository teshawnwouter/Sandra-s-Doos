using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] bool playerButton;
    Animator anim;
    [SerializeField] Door door;
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
        if (playerButton && collision.transform.CompareTag("Player")) 
            {
            anim.SetTrigger("Pressed");
            if (door != null)
            {
                door.OpenDoor();
            }
        }

        if(!playerButton && collision.transform.CompareTag("Doos"))
        {
            anim.SetTrigger("Pressed");
            if (door != null)
            {
                door.OpenDoor();
            }
        }

    }

    private void OnCollisionExit(Collision collision)
    {
        anim.SetTrigger("Unpressed");
        door.buttonsPressed--;
    }

}
