using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMent_Controller : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector2 movement = new Vector2(horizontal, vertical).normalized;

        rb.MovePosition(rb.position + movement * moveSpeed * Time.deltaTime);
    }
}
