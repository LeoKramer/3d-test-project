using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rigidBody;
    Color originalColor;
    float verticalDirection;
    float horizontalDirection;

    public int score;
    public float timeLeft = 10;
    public Color newColor;
    public float speed = 5;
    public bool moving = false;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        originalColor = GetComponent<MeshRenderer>().material.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeLeft > 0)
        {
            verticalDirection = Input.GetAxis("Vertical");
            horizontalDirection = Input.GetAxis("Horizontal");
        }

        timeLeft -= Time.deltaTime;

        if (timeLeft <= 0)
        {
            timeLeft = 0;
        }
    }

    public void FixedUpdate()
    {
        Move();
        ColorChange();
    }

    public void Move()
    {
        float horizontalSpeed = horizontalDirection * (speed * 100) * Time.deltaTime;
        float verticalSpeed = verticalDirection * (speed * 100) * Time.deltaTime;

        if (horizontalSpeed != 0 || verticalSpeed != 0)
        {
            moving = true;
            rigidBody.velocity = new Vector3(horizontalSpeed, rigidBody.velocity.y, verticalSpeed);
        }

        if (horizontalSpeed == 0 && verticalSpeed == 0)
        {
            moving = false;
            rigidBody.velocity = new Vector3(horizontalSpeed, rigidBody.velocity.y, verticalSpeed);
        }
    }

    public void ColorChange()
    {
        if (moving)
        {
            GetComponent<MeshRenderer>().material.color = newColor;
        }
        else
        {
            GetComponent<MeshRenderer>().material.color = originalColor;
        }
    }
}
