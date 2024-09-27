using System.Collections;
using System.Collections.Generic;
using Unity.Loading;
using UnityEngine;
using UnityEngine.SceneManagement;
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
            if (Physics.Raycast(transform.position, transform.up, out hit, 100.0f, mask))
            {
                Debug.Log("geraakt");
                if (hit.transform.CompareTag("Doos"))
                {
                    Debug.Log("heb de doos Geraakt");
                    SceneManager.LoadScene("GameOverScene");
                }
                if (hit.transform.CompareTag("Player"))
                {
                    SceneManager.LoadScene("GameOverScene");
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
