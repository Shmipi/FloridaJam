using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{

    private float health;
    private float jamLvl;

    private bool stateOne;
    private bool stateTwo;
    private bool stateThree;

    // Start is called before the first frame update
    void Start()
    {
        health = 300f;
        jamLvl = 501f;
    }

    // Update is called once per frame
    void Update()
    {
        if(health > 200)
        {
            //state 1
        } else if(health > 100 && health < 201)
        {
            //state 2
        } else if(health < 101)
        {
            //state 3 start depleting jam
            if(jamLvl > 0)
            {
                jamLvl -= Time.deltaTime;
            }
        }

        if(jamLvl <= 0)
        {
            //Game Over man, Game Over
        }
    }

    public void Crack()
    {
        health -= 30f;
        Debug.Log("Health" + health);
    }

    public void TapePickup()
    {
        if (health > 100)
        {
            health = 300f;
        } else if (health < 101)
        {
            health = 200f;
        }
    }
}
