using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody m_rigidbody;
    [SerializeField] Animator animator;

    GameObject jumpForcer;
    [SerializeField] GameObject playerModel;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpHeight;

    private float jumpTimer = 0;
    private float jumpTrigger = 0.3f;

    public Image jumpscareImage;
    public float flashDuration = 0.2f;
    private bool jumpscareTriggered = false;
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

        if (translation != 0)
        {
            animator.SetBool("IsRunning", true);
        }
        else
        {
            animator.SetBool("IsRunning", false);
        }

        if (translation > 0)
        {
            playerModel.transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        if (translation < 0)
        {
            playerModel.transform.rotation = Quaternion.Euler(0, -90, 0);
        }

        JumpTimer();
        GroundCheck();

        if (coins >= 25 && !jumpscareTriggered)
        {
            StartCoroutine(FlashJumpscare());
        }
    }

    private void GroundCheck()
    {
        Debug.DrawRay(transform.position + new Vector3(0.33f, 0, 0), transform.TransformDirection(Vector3.down) * 0.8f, Color.yellow);
        Debug.DrawRay(transform.position + new Vector3(-0.33f, 0, 0), transform.TransformDirection(Vector3.down) * 0.8f, Color.yellow);
        Debug.DrawRay(transform.position + new Vector3(0, 0, 0), transform.TransformDirection(Vector3.down) * 0.8f, Color.yellow);
        if (Physics.Raycast(transform.position + new Vector3(0, 0, 0), transform.TransformDirection(Vector3.down), out RaycastHit hit, 0.8f) ||Physics.Raycast(transform.position + new Vector3(0.33f, 0, 0), transform.TransformDirection(Vector3.down), out hit, 0.8f) || Physics.Raycast(transform.position + new Vector3(-0.33f, 0, 0), transform.TransformDirection(Vector3.down), out hit, 0.8f))
        {
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

    private IEnumerator FlashJumpscare()
    {
        jumpscareTriggered = true;
        jumpscareImage.enabled = true;
        yield return new WaitForSeconds(flashDuration);
        jumpscareImage.enabled = false;
    }
}