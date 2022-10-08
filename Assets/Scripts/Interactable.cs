using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    private Transform parentTransform;
    private GameObject parentObject;
    private Quaternion rotation;


    private void Start()
    {
        parentObject = gameObject.GetComponent<GameObject>();
        parentTransform = gameObject.GetComponent<Transform>();
    }

    public void GetPunched(Quaternion knockback)
    {
        //parentTransform.
    }
}
