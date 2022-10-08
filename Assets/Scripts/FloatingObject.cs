using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class FloatingObject : MonoBehaviour
{

    public Transform[] floaters;
    
    public float underWaterDrag = 3f;
    public float underWaterAngularDrag = 1f;
    public float airDrag = 0f;
    public float airAngularDrag = 0.05f;

    public float waterHeight = 0f;

    private Rigidbody rb;

    private bool underwater;

    public float floatingPower = 15f;

    private int floatersUnderwater;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        floatersUnderwater = 0;
        for (int i = 0; i < floaters.Length; i++)
        {
            float diff = floaters[i].position.y-waterHeight;
            if (diff < 0)
            {
                rb.AddForceAtPosition(Vector3.up * floatingPower * Mathf.Abs(diff), floaters[i].position, ForceMode.Force);
                floatersUnderwater++;
                if (!underwater)
                {
                    underwater = true;
                    SwitchState(underwater);
                }
            }else if (floatersUnderwater == 0 && underwater) 
            {
                underwater = false;
                SwitchState(underwater);

            }
        }
    }

    void SwitchState(bool isUnderwater)
    {
        if (isUnderwater)
        {
            rb.drag = underWaterDrag;
            rb.angularDrag = underWaterAngularDrag;
        }
        else
        {
            rb.drag = airDrag;
            rb.angularDrag = airAngularDrag;
        }
    }
}
