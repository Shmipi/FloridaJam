using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDamage : MonoBehaviour
{
    
    private CharacterController controller;
    private PlayerScript playerScript;

    private bool grounded;
    private float fallSpeed;
    //private Rigidbody2D rb2D;
    [SerializeField]private float minFallDamage;

    // Start is called before the first frame update
    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        //rb2D = GetComponent<Rigidbody2D>();
        playerScript = GetComponent<PlayerScript>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        grounded = controller.isGrounded;
        
        if (grounded)
        {
            return;
        }

        fallSpeed = playerScript.GetFallspeed();
        if (!grounded && fallSpeed < -minFallDamage)
        {

            //Falldamage
            /** TODO
             * Lägg in logik för skada. idé: Köra typ 50 hp, 10sek fall garanterad död, 10% dmg mellan 3 och 10 sek
             */
        }


        
    }
}
