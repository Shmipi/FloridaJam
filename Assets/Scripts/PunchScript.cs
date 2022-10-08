using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PunchScript : MonoBehaviour
{
    private GameObject player;
    private float timer;
    private Vector3 position;
    [SerializeField]private float attackCooldown;
    [SerializeField] private float rayCastLength;

    [SerializeField] private BoxCollider punchCollider;


    private Quaternion rotation;
    // Start is called before the first frame update
    void Start()
    {
        if (rayCastLength == 0) rayCastLength = 5;
        player = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        rotation = player.transform.rotation;
        position = player.transform.position;
        if (Input.GetKeyDown(KeyCode.Mouse1) && timer >= attackCooldown)
        {
            timer = 0;
            StartCoroutine(Countdown());

            //TODO Shooting

        }
        if (Input.GetKeyDown(KeyCode.Mouse2) && timer >= attackCooldown)
        {
            timer = 0;
            StartCoroutine(Countdown());
            //TODO Använd en collider
            if (punchCollider.TryGetComponent(out Collider interactable))
            {
                //TODO Lägg in objekt som blir slaget
                interactable.GetComponent<Interactable>().GetPunched(rotation);
            }
        }
    }

    private IEnumerator Countdown()
    {
        float duration = attackCooldown+1; // 3 seconds you can change this 
        //to whatever you want
        float normalizedTime = 0;
        while (normalizedTime <= 1f)
        {
            normalizedTime += Time.deltaTime / duration;
            timer = normalizedTime;
            yield return null;
        }
    }
    
    
    void OnDrawGizmosSelected()
    {
        // Draws a 5 unit long red line in front of the object
        Gizmos.color = Color.red;
        Vector3 direction = transform.TransformDirection(Vector3.forward) * rayCastLength;
        Gizmos.DrawRay(transform.position, direction);
    }
}
