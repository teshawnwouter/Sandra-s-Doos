using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOutScript : MonoBehaviour
{
    [SerializeField] Image BlackScreen;
    GameObject player;
    [SerializeField] float dist;


    [SerializeField] Vector3 NewPoint;
    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
    }
    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < dist)
            BlackScreen.color = new Vector4(0, 0, 0, 1 / Vector3.Distance(transform.position, player.transform.position));
        else 
            BlackScreen.color = new Vector4(0, 0, 0, 0);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.transform.position = new Vector3(NewPoint.x, NewPoint.y,NewPoint.z);
        }
    }
}
