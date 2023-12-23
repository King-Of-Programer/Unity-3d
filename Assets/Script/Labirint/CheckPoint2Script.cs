using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckPoint2Script : MonoBehaviour
{
    [SerializeField]
    private Image indicator;

    private float checkPoint2Timeout = 10f;

    void Start()
    {
        LabirintState.checkPoint2Amount = 1f;
        LabirintState.checkPoint2Active = false;
    }

    void Update()
    {
        if (LabirintState.checkPoint2Active)
        {
            LabirintState.checkPoint2Amount -= Time.deltaTime / checkPoint2Timeout;
            if (LabirintState.checkPoint2Amount > 0f)
            {
                indicator.fillAmount = LabirintState.checkPoint2Amount;
                indicator.color = new Color(
                    1f - indicator.fillAmount,
                    indicator.fillAmount,
                    0.3f
                 );
            }
            else
            {
                GameObject.Destroy(this.gameObject);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("CheckPoint1Script: " + other.name);
        LabirintState.checkPoint2Active = true;
        GameObject.Destroy(this.gameObject);
    }
}
