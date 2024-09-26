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
    [SerializeField] Animation grow;
    private void Awake()
    {
        m_boxStates = BoxStates.InHands;
        m_collider = GetComponent<Collider>();
        m_rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();

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
                    m_rb.AddForce((mouseCheck()-transform.position)*forceMultiplier, ForceMode.Impulse);
                    anim.SetTrigger("Grow");
                    m_boxStates = BoxStates.Launched;
                    break;
                case BoxStates.Launched:
                    m_rb.isKinematic = true;
                    m_boxStates = BoxStates.Frozen;
                    break;
                case BoxStates.Frozen:
                    m_collider.enabled = false;
                    m_boxStates = BoxStates.InHands;
                    break;
            }
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
}
