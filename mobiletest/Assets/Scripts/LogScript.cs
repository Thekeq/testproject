using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogScript : MonoBehaviour
{
    private GatherResources GR;

    private void Start()
    {
        GR = FindObjectOfType<GatherResources>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GR.IncrementPoints();
            Destroy(gameObject);
        }
    }
}
