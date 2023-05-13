using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
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
    public bool circle_here;
    //public float button_cd_time;
    //public float last_button_time;
    public GameObject player;
    public GameObject Magic_Circle;

    public bool Get_Press;
    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<Collider2D>();
        SR = GetComponent<SpriteRenderer>();
        //last_button_time = -button_cd_time;
    }

    // Update is called once per frame
    void Update()
    {
        //if(Time.time >= last_button_time + button_cd_time)
        //{
        //    if (Input.GetKeyDown(KeyCode.G))
        //    {
        //        last_button_time = Time.time;
        //    }
        //}

        if (here)
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                //transform.position = player.transform.GetChild(0).GetComponent<Transform>().position;
                holded = !holded;
            }
        }

        if (holded)
        {
            transform.position = player.transform.GetChild(0).GetComponent<Transform>().position;
        }
        else
        {
            transform.position = transform.position;
        }

        if(holded && circle_here && here)
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                transform.position = Magic_Circle.transform.GetChild(0).GetComponent<Transform>().position;
                holded = !holded;
            }
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

        if(other.name == "Circle")
        {
            circle_here = true;
            Magic_Circle = other.gameObject;
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

        if (other.name == "Circle")
        {
            circle_here = false;
            Magic_Circle = null;
        }
    }
}
