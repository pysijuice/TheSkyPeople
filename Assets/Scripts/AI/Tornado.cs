using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tornado : MonoBehaviour
{

    private float xMaxPosition = 2000f;
    private float zMaxPosition = 2000f;
    private Vector3 randomPosition;
    private float timer;
    [SerializeField] float speed;

    bool isMoving;

    // Start is called before the first frame update
    void Start()
    {
        RandomingPosition();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        timer += Time.deltaTime;
        if (timer > 10f)
        {
            RandomingPosition();
            timer = 0f;
        }

    }

    void RandomingPosition()
    {
        randomPosition = new Vector3(Random.Range(-xMaxPosition, xMaxPosition), 0, Random.Range(-zMaxPosition, zMaxPosition));
    }

    void Movement()
    {
        transform.position = Vector3.MoveTowards(transform.position, randomPosition, speed * Time.deltaTime);
    }
}
