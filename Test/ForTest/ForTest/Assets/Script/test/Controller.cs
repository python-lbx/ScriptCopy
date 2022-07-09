using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public int speed;
    public int time;
    public float delaytime;
    public float lastGetTime;
    Rigidbody2D rb;

    public int rnum;

    public Vector3 startpos;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startpos = transform.position;
        print(test.Compare(speed,time));
    }

    // Update is called once per frame
    void Update()
    {   
        //rnum = Random.Range(0,2);
        if(time > 0)
        {        
            rb.velocity = new Vector2(speed,rb.velocity.y);

            if(Time.time > (delaytime + lastGetTime))
            {
                lastGetTime = Time.time;
                time --;
                if(rnum == 0)
                {
                ShadowPool.instance.GetFormPool();
                }
            }
        }
        else
        {
            transform.position = startpos;
            rb.velocity = new Vector2(0,0);
        }

        if(Input.GetKeyDown(KeyCode.Q))
        {
            time = 10;
        }
    }
}
