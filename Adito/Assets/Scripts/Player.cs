using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    float velocity = 2f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb.velocity = movement * velocity;

       
    }
}
