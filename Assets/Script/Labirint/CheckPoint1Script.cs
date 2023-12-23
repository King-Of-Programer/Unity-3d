using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckPoint1Script : MonoBehaviour
{
    [SerializeField]
    private Image indicator;
    private float checkPoint1Timeout = 10f;
   
    
    // Start is called before the first frame update
    void Start()
    {
       LabirintState.checkPoint1Amount = 1f;
        LabirintState.checkPoint1Passed = false;
        //indicator = GameObject.Find("Indecator");
    }

    // Update is called once per frame
    void Update()
    {
        LabirintState.checkPoint1Amount -= Time.deltaTime / checkPoint1Timeout;
        if(LabirintState.checkPoint1Amount > 0f)
        {
            indicator.fillAmount = LabirintState.checkPoint1Amount;
        }
        else
        {
            GameObject.Destroy(this.gameObject);
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        // Debug.Log("CheckPoint1Script: " + other.name);
        LabirintState.checkPoint1Passed = true;
        GameObject.Destroy(this.gameObject);
    }
}
