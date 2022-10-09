using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntMovement : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private int points;
    public Vector2 xLimits = new Vector2(0, 1);
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject ant;

    [SerializeField] private int amplitude;
    [SerializeField] private int frequency;

    private float z;
    private float y;
    private float currentPoint = 0;

    float tau = Mathf.PI * 2;

    private float xMovement;
    private float zMovement;

    Vector2 distance;
    void Start()
    {
        y = ant.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {

        float xPyth = (ant.transform.position.x - player.transform.position.x);
        float zPyth = (ant.transform.position.z - player.transform.position.z);

        distance = new Vector2(xPyth, zPyth).normalized;
        xMovement = 0.008f * distance.x;
        zMovement = 0.008f * distance.y;

        AntsMovement();
    }

    void AntsMovement()
    {
        float xStart = xLimits.x;
        currentPoint++;
        {
            float height = (Mathf.PerlinNoise(Time.time, 0.0f) - 0.5f) * 2;

            float progress = (float)currentPoint / (points - 1);
            float x = Mathf.Lerp(xStart, player.transform.position.x, progress);

            z = Mathf.Lerp(5, player.transform.position.z, progress) + (1 - Mathf.Pow(progress, 5)) * (amplitude * Mathf.Sin((tau * frequency * x) + Time.timeSinceLevelLoad));

            ant.transform.position = new Vector3(ant.transform.position.x - xMovement, y, ant.transform.position.z - zMovement);

            ant.transform.eulerAngles = new Vector3(0, 135, 0);
            ant.transform.LookAt(player.transform);
            ant.transform.eulerAngles = ant.transform.eulerAngles + new Vector3(0, -90, 0);
            ant.transform.eulerAngles = new Vector3(0, ant.transform.eulerAngles.y, 0);
        }
    }
}