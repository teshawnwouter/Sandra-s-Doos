using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawner : MonoBehaviour
{
    public GameObject doos;
  
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        Destroy(this.gameObject);
        Instantiate(doos, transform.position, Quaternion.identity);
    }
    
        
    
}
