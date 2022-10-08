using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    private GameObject player;
    private bool attackable;
    private Vector3 position;
    [SerializeField]private float attackCooldown;
    [SerializeField] private float rayCastLength;

    [SerializeField] private BoxCollider punchCollider;
    [SerializeField] private float punchForce;

    private GameObject punchObject;

    private Quaternion rotation;
    // Start is called before the first frame update
    void Start()
    {
        if (rayCastLength == 0) rayCastLength = 5;
        player = GameObject.FindGameObjectWithTag("Player");
        punchCollider.enabled = false;
        attackable = true;
    }

    // Update is called once per frame
    void Update()
    {
        rotation = player.transform.rotation;
        position = player.transform.position;
        if (Input.GetKeyDown(KeyCode.Mouse0) && attackable)
        {
            attackable = false;            
            StartCoroutine(Countdown());

            //TODO Shooting

        }
        if (Input.GetMouseButton(1) && attackable)
        {
            punchCollider.enabled = true;
            if (punchCollider.enabled == true)
            {
                print("Kan slå");
            }

            print("Mus1");
            attackable = false;
            StartCoroutine(Countdown());
            //TODO Använd en collider
            if (punchCollider.TryGetComponent(out GameObject interactable))
            {
                //TODO Lägg in objekt som blir slaget
                if (punchObject != null)
                {
                    punchObject.GetComponent<Interactable>().GetPunched(position, punchForce);
                    punchObject = null;

                }
            }
            punchCollider.enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.P) && attackable)
        {
            List<GameObject> enemies = GameObject.FindGameObjectsWithTag("Interactable").ToList();
            foreach (var en in enemies)
            {
                en.GetComponent<Interactable>().GetPunched(position, punchForce);
            }
        }
    }

    private IEnumerator Countdown()
    {
        yield return new WaitForSeconds(attackCooldown);
        attackable = true;

    }
    
    
    void OnDrawGizmosSelected()
    {
        // Draws a 5 unit long red line in front of the object
        Gizmos.color = Color.red;
        Vector3 direction = transform.TransformDirection(Vector3.forward) * rayCastLength;
        Gizmos.DrawRay(transform.position, direction);
    }
}
