using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gates2Script : MonoBehaviour
{
    private float period = 100f / 360f;
    void Start()
    {
        LabirintState.AddPropertyListener(
            nameof(LabirintState.checkPoint2Active),
            OnCheckPoint2Changed);
    }

    
    void Update()
    {
        this.transform.Rotate(Vector3.up, Time.deltaTime / period);
    }
    private void OnCheckPoint2Changed()
    {
        if(LabirintState.checkPoint2Active)
        {
            period /= 10f;
        }
       
    }
    private void OnDestroy()
    {
        LabirintState.RemovePropertyListener(
            nameof(LabirintState.checkPoint2Active),
            OnCheckPoint2Changed);
    }
}
