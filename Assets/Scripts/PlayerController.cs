using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float speed = 10.0f;

    private Rigidbody rb;
    private int totalItems;

    private int count;
    public Text countText;
    public Text winText;

    // Call at the very first frame
    private void Start()
    {
        // Access the Rigidbody component which is attached to the current game object
        rb = GetComponent<Rigidbody>();
        totalItems = GameObject.FindGameObjectsWithTag("Pick up").Length;
        count = 0;
        SetCountText();
        winText.text = "";
    }

    // Call before a physic effetc
    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical   = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        //Destroy(other.gameObject);
        if (other.gameObject.CompareTag("Pick up"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
            UpdateWinText();
        }
    }

    private void SetCountText()
    {
        countText.text = "<i>Count: <b>" + count.ToString() + " / " + totalItems.ToString() + "</b></i>";
    }

    private void UpdateWinText()
    {
        if (count == totalItems)
        {
            winText.text = "<b>YOU WIN!</b>";
        }
    }

}
