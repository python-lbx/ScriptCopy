using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPointController : MonoBehaviour
{
    Rigidbody2D rb;
    Collider2D coll;

    public float horizontalspeed;
    public float verticalspeed;
    public bool touch;
    public GameObject beam;
    public GameObject particle;
    public GameObject laser;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        beam.SetActive(false);
        particle.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(!touch)
        {
            rb.velocity = new Vector2(horizontalspeed,0);
        }
        else
        {   
            beam.SetActive(true);
            particle.SetActive(true);
            laser.GetComponent<LaserCheck>().enabled = true;

            if(laser.GetComponent<LaserCheck>().faceup)
            {
                rb.velocity = new Vector2(0,verticalspeed);
                laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0,verticalspeed);
            }
            else
            {
                rb.velocity = new Vector2(0,-verticalspeed);
                laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0,-verticalspeed);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            touch = true;
        }
    }
}
