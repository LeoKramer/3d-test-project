using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rigidBody;
    public float speed = 5;
    float horizontalDirection;
    float verticalDirection;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalDirection = Input.GetAxis("Horizontal");
        verticalDirection = Input.GetAxis("Vertical");
    }

    public void FixedUpdate()
    {
        Move();
    }

    public void Move()
    {
        float horizontalSpeed = horizontalDirection * (speed * 100) * Time.deltaTime;
        float verticalSpeed = verticalDirection * (speed * 100) * Time.deltaTime;

        if (horizontalSpeed != 0)
        {
            rigidBody.velocity = new Vector3(horizontalSpeed, rigidBody.velocity.y, rigidBody.velocity.z);
        }

        if (verticalSpeed != 0)
        {
            rigidBody.velocity = new Vector3(rigidBody.velocity.x, rigidBody.velocity.y, verticalSpeed);
        }
    }
}
