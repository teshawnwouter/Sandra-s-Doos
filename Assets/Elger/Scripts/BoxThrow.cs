using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum BoxStates
{
    InHands,
    Launched,
    Frozen
}

public class BoxThrow : MonoBehaviour
{
    [SerializeField] BoxStates m_boxStates;
    Collider m_collider;
    Rigidbody m_rb;
    [SerializeField] RigidbodyConstraints m_rbCnstrts;
    [SerializeField] LayerMask detectionLayer;
    [SerializeField] float forceMultiplier;
    Animator anim;
    GameObject player;
    Vector3 lockPoint;
    bool inAir = false;
    private void Awake()
    {
        m_boxStates = BoxStates.InHands;
        m_collider = GetComponent<Collider>();
        m_rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player");
        lockPoint = GameObject.FindWithTag("LockPoint").transform.position;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            switch (m_boxStates)
            {
                case BoxStates.InHands:
                    m_rb.isKinematic = false;
                    m_collider.enabled = true;
                    anim.SetTrigger("Grow");
                    m_rb.AddForce((mouseCheck()-transform.position)*forceMultiplier, ForceMode.Impulse);
                    m_boxStates = BoxStates.Launched;
                    break;
                case BoxStates.Launched:
                    m_rb.isKinematic = true;
                    m_boxStates = BoxStates.Frozen;
                    break;
                case BoxStates.Frozen:
                    if (!inAir)
                    {
                        m_collider.enabled = false;
                        anim.SetTrigger("Shrink");
                        StartCoroutine(ReturnBox());
                    }                   
                    break;
            }
        }

        if (m_boxStates == BoxStates.InHands)
        {
            transform.position = lockPoint;
        }
    }

    Vector3 mouseCheck()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out var hitInfo, Mathf.Infinity, detectionLayer))
        {
            return hitInfo.point;
        }
        else
            return Vector3.zero;
    }

    IEnumerator ReturnBox()
    {
        float loops = 0;

        inAir = true;
        while (transform.position != lockPoint && loops < 300)
        {
            loops++;
            transform.position = Vector3.MoveTowards(transform.position, lockPoint, 0.2f);
            yield return new WaitForSeconds(0.01f);
        }
        m_boxStates = BoxStates.InHands;
        inAir = false;
    }
}
