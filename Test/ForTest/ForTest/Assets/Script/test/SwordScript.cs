using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordScript : MonoBehaviour
{
    public Controller Point;
    public GameObject Target;

    Rigidbody2D rb;
    public int rate;
    public int speed;

    public Vector3 startpos;

    public float focustime;

    public Vector2 Direction;

    public float rnum;
    // Start is called before the first frame update

    //生成
    //換位置
    //瞄準
    //落下
    //返回
    private void OnEnable() 
    {
        rb = GetComponent<Rigidbody2D>();
        Point = GameObject.FindObjectOfType<Controller>();
        Target = GameObject.Find("Player");
        transform.position = Point.transform.position;
        startpos = new Vector3(transform.position.x,5.5f,transform.position.z);

        rnum = Random.Range(154,206);
        transform.Rotate(0,0,rnum);

    }
    private void OnDisable() 
    {
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //瞄準
        //Vector2 targetpos = Target.transform.position;

        //Direction = targetpos - (Vector2)transform.position;
        
        if(focustime > 0)
        {
            focustime -= Time.deltaTime;

            //transform.up = Direction;
        
        }
        else
        {
            rb.velocity = transform.up * speed;
        }
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.name == "Ground")
        {   
            speed = 0;
            /*print("A");
            transform.position = startpos;
            focustime = 1;
            ShadowPool.instance.ReturnPool(this.gameObject);*/
        }
    }
}
