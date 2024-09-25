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
    BoxStates m_boxStates;
    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            switch (m_boxStates)
            {
                case BoxStates.InHands:
                    break;
                case BoxStates.Launched:
                    break;
                case BoxStates.Frozen:
                    break;
            }
        }
    }
}
