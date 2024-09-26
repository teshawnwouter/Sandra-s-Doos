using System.Collections;
using System.Collections.Generic;
using Unity.Loading;
using UnityEngine;

public class BoxDestroyer : MonoBehaviour
{


    LineRenderer lineRenderer;
    [SerializeField] LayerMask mask;
    bool isGonnaShoot;
    void Start()
    {
        isGonnaShoot = true;
        lineRenderer = GetComponent<LineRenderer>();
    }

    void Update()
    {
        StartCoroutine(Laser());
    }



    IEnumerator Laser()
    {
        if (isGonnaShoot)
        {
            RaycastHit hit;
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, transform.position + (transform.forward * 100f));
            if (Physics.Raycast(transform.position, transform.forward, out hit, 100.0f, mask))
            {
                Debug.Log("geraakt");
                //Destroy(other);
                if (hit.transform.CompareTag("Doos"))
                {
                    Debug.Log("heb de doos Geraakt");
                    Destroy(hit.transform.gameObject);

                }
                if (hit.transform.CompareTag("Player"))
                {
                    Destroy(hit.transform.gameObject);
                }
            }
            yield return new WaitForSeconds(1f);
            isGonnaShoot = false;
        }else
        {
            lineRenderer.enabled = false;
            yield return new WaitForSeconds(1f);
            lineRenderer.enabled = true;
            isGonnaShoot = true;
        }
        

    }
}
