using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody m_rigidbody;


    [SerializeField] private float moveSpeed;

    [SerializeField] private float jumpHeight;

    void Awake()
    {
        m_rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float translation = Input.GetAxis("Horizontal") * moveSpeed;
        translation *= Time.deltaTime;

        transform.Translate(0, 0, translation);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            m_rigidbody.AddForce(transform.up * jumpHeight);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag(""))
        {
            
        }
    }
}