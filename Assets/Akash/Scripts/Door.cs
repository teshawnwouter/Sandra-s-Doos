using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    Animator anim;
    bool doorOpened = false;
    [SerializeField] int buttonsNeeded;
    public int buttonsPressed;
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

    public void OpenDoor()
    {
        buttonsPressed++;

        if (!doorOpened && buttonsPressed >= buttonsNeeded)
        {

            anim.SetTrigger("Door");
            doorOpened = true;
        }
    }
}
