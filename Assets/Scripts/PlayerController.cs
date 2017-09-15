using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed = 10.0f;

    private Rigidbody rb;

    // Call at the very first frame
    private void Start()
    {
        // Access the Rigidbody component which is attached to the current game object
        rb = GetComponent<Rigidbody>();
    }

    // Call before a physic effetc
    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical   = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);
    }
}
