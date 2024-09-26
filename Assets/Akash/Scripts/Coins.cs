using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{

    PlayerMovement player;
    // Start is called before the first frame update
    void Start()
    {
        
        player = GameObject.FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        player.coins++;
        Destroy(gameObject);
;    }
}
