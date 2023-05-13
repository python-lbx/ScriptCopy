using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazer : MonoBehaviour
{
    LineRenderer lineRenderer;
    public LayerMask ground;
    public LayerMask player;
    //public bool hitground,hitplayer;
    public float distance;
    public Transform LaserHit;
    public float time;
    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.enabled = true;
        lineRenderer.useWorldSpace = true;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position,transform.up,distance,ground);
        RaycastHit2D hitPlayer = Physics2D.Raycast(transform.position,transform.up,distance,player);
        Debug.DrawLine(transform.position,hit.point);
        LaserHit.position = hit.point;
        lineRenderer.SetPosition(0,transform.position);
        lineRenderer.SetPosition(1,LaserHit.position);

        //hitplayer = hitPlayer;
        //hitground = hit;

            if(time > 0)
            {
                time -= Time.deltaTime;
            } 


        if(hit.collider.CompareTag("Player"))
        {
            if(time <= 0)
            {
                print("造成傷害");
                time = 0.5f;
            }

        }

        //print(hit.collider.name);
    }
}
