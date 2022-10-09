using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoombaScript : MonoBehaviour
{

    private Transform roombaTransform;

    [SerializeField] private Transform pos1;
    [SerializeField] private Transform pos2;

    private float speed = 10;

    private bool there;
    // Start is called before the first frame update
    void Start()
    {
        roombaTransform = gameObject.transform;
        there = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (there)
        {
            transform.position = Vector3.MoveTowards(transform.position, pos2.position, speed * Time.deltaTime);
            if (transform.position == pos2.position)
            {
                there = false;
            }
        } else if(there == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, pos1.position, speed * Time.deltaTime);
            if (transform.position == pos1.position)
            {
                there = true;
            }
        }
    }
}
