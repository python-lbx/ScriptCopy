using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Collider2D coll;
    public SpriteRenderer SR;

    public Color Tough_color;
    public Color Not_Tough_color;
    public Color Geted_color;
    public Color NotGet_color;
    public bool here;
    public bool holded;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<Collider2D>();
        SR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(here)
        {
            if(Input.GetKeyDown(KeyCode.G))
            {
                transform.position = player.transform.GetChild(0).GetComponent<Transform>().position;
                holded = true;
            }
        }

        if(holded)
        {
            transform.position = player.transform.GetChild(0).GetComponent<Transform>().position;
        }

        if(!holded)
        {
            transform.position = transform.position;
        }
    }

    private void OnTriggerStay2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
        {
            here = true;
            SR.color = Tough_color;
            player = other.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
        {
            here = false;
            SR.color = Not_Tough_color;
            player = null;
        } 
    }
}
