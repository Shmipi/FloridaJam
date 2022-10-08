using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Interactable : MonoBehaviour
{
    private Transform parentTransform;
    private GameObject parentObject;
    private Quaternion rotation;
    private Collider collider;
    private Rigidbody rb;
    

    private void Start()
    {
        parentObject = gameObject.GetComponent<GameObject>();
        parentTransform = gameObject.GetComponent<Transform>();
        collider = gameObject.GetComponent<Collider>();
        rb = gameObject.GetComponent<Rigidbody>();
        Physics.IgnoreLayerCollision(7, 6, true);
        Physics.IgnoreLayerCollision(6, 7, true);

    }

    public void GetPunched(Vector3 knockback, float punchForce)
    {
        print("TEST");
        gameObject.layer = 7;
        StartCoroutine(Punching());        
        Vector3 direction =  transform.position - knockback;
        rb.AddForce(direction.normalized * punchForce, ForceMode.Impulse);
    }
    
    private IEnumerator Punching()
    {
        yield return new WaitForSeconds(1.5f);
        gameObject.layer = 6;
    }

}
