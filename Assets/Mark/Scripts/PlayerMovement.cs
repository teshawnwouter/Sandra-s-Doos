using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody m_rigidbody;

    GameObject jumpForcer;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpHeight;

    private float jumpTimer = 0;
    private float jumpTrigger = 0.3f;

    public int coins = 0;

    void Awake()
    {
        m_rigidbody = GetComponent<Rigidbody>();
        jumpForcer = GameObject.Find("JumpForcing");
    }

    void Update()
    {
        float translation = Input.GetAxis("Horizontal") * moveSpeed;
        translation *= Time.deltaTime;

        jumpForcer.GetComponent<Rigidbody>().velocity = Vector3.right * translation;

        m_rigidbody.MovePosition(m_rigidbody.position + jumpForcer.GetComponent<Rigidbody>().velocity);

        JumpTimer();
        GroundCheck();
    }

    private void GroundCheck()
    {
        Debug.DrawRay(transform.position + new Vector3(0.3f, 0, 0), transform.TransformDirection(Vector3.down) * 0.8f, Color.yellow);
        Debug.DrawRay(transform.position + new Vector3(-0.3f, 0, 0), transform.TransformDirection(Vector3.down) * 0.8f, Color.yellow);
        if (Physics.Raycast(transform.position + new Vector3(0.3f, 0, 0), transform.TransformDirection(Vector3.down), out RaycastHit hit, 0.8f) || Physics.Raycast(transform.position + new Vector3(-0.3f, 0, 0), transform.TransformDirection(Vector3.down), out hit, 0.8f))
        {
            Debug.Log("Did Hit");
            if (Input.GetKey(KeyCode.Space) && jumpTimer >= jumpTrigger)
            {
                m_rigidbody.AddForce(transform.up * jumpHeight);
                jumpTimer = 0;
            }
        }
    }

    private void JumpTimer()
    {
        if (jumpTimer < jumpTrigger)
        {
            jumpTimer += Time.deltaTime;
        }
    }


}