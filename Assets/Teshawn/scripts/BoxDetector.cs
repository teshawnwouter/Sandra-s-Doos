using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxDetector : MonoBehaviour
{

    [SerializeField]private bool isAbleToFreeze;

    [SerializeField] private bool isUnlocked;

    Door door;  


    void Start()
    {
        door = FindAnyObjectByType<Door>();

       isUnlocked = false;
       isAbleToFreeze = true;
    }

   
    void Update()
    {
        

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Doos"))
        {
            Debug.Log(other);
            StartCoroutine(FreezeBoxForPuzzle(other));
        }
    }

    IEnumerator FreezeBoxForPuzzle(Collider other)
    {
        if (isAbleToFreeze && !isUnlocked)
        {
            yield return new WaitForSeconds(.2f);
            other.attachedRigidbody.isKinematic = true;
            yield return new WaitForSeconds(2f);
            isAbleToFreeze = false;
            Debug.Log("kan nu vallen");
            isUnlocked = true;
            other.attachedRigidbody.isKinematic = false;
            door.OpenDoor();

        }
        yield return null;
    }

   
}
