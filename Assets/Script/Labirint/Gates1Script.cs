using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gates1Script : MonoBehaviour
{
    private float swingPeriod = 3f;


    void Start()
    {

    }

    void Update()
    {
        float factor = Time.deltaTime / swingPeriod;
        if (!LabirintState.checkPoint1Passed)
        {
            factor *= 00.3f;
        }

      
        Vector3 newPosition = this.transform.position + factor * Vector3.down;
        if (newPosition.y <= -0.35f || newPosition.y >= 0f)
        {
            newPosition.y = newPosition.y <= -0.35f ? -0.35f : 0f;
            swingPeriod = -swingPeriod;
        }
        this.transform.position = newPosition;
    }
}
