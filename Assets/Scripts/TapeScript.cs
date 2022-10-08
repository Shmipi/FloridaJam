using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapeScript : MonoBehaviour
{
    public HealthScript healthScript;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            healthScript.TapePickup();
            //run pickup ability
            Destroy(gameObject);
        }
    }
}
