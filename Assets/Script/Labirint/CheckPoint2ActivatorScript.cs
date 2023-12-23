using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint2ActivatorScript : MonoBehaviour
{
    void Start()
    {
        LabirintState.checkPoint2Active = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        LabirintState.checkPoint2Active = true;
        LabirintState.gameLevel += 1;
        GameObject.Destroy(this.gameObject);
    }
}
