using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripleLaser : MonoBehaviour
{
    public GameObject LaserCheckPoint;
    /*public GameObject A_Point; //物件位置
    public Vector2 A_Pos; //方向
    public Vector2 A_Target;
    public bool A_Ready;
    public GameObject B_Point;
    public Vector2 B_Pos;
    public GameObject C_Point;
    public Vector2 C_Pos;*/
    public LayerMask PlayerLayer;
    public LayerMask GroundLayer;
    public float LaserCheckDistance;
    public float moveSpeed;
    public float rotateSpeed;
    public float step;
    public bool Player;
    public float time;

    public GameObject[] Point;
    public Vector2[] Pos;
    public Vector2[] Target;
    public bool[] Ready;
    

    // Start is called before the first frame update
    void Start()
    {

    }

    private void FixedUpdate() 
    {

    }
    // Update is called once per frame
    void Update()
    {                
        //transform.Rotate(0,0,rotateSpeed);

    
        for(var i = 0; i < Point.Length; i ++)
        {
            Pos[i].x = Point[i].transform.position.x;
            Pos[i].y = Point[i].transform.position.y;
        }

        PhysicalCheck();

        /*A_Pos.x = A_Point.transform.position.x;
        A_Pos.y = A_Point.transform.position.y;

        B_Pos.x = B_Point.transform.position.x;
        B_Pos.y = B_Point.transform.position.y;

        C_Pos.x = C_Point.transform.position.x;
        C_Pos.y = C_Point.transform.position.y;*/

        if(time <= 0)
        {
            transform.Rotate(0,0,rotateSpeed);
        }

    }

    void PhysicalCheck()
    {   
  

        RaycastHit2D A_Ray = Raycast(LaserCheckPoint.transform,Pos[0],LaserCheckDistance,PlayerLayer);
        RaycastHit2D B_Ray = Raycast(LaserCheckPoint.transform,Pos[1],LaserCheckDistance,PlayerLayer);
        RaycastHit2D C_Ray = Raycast(LaserCheckPoint.transform,Pos[2],LaserCheckDistance,PlayerLayer);

        RaycastHit2D A_Ray_G = Raycast(LaserCheckPoint.transform,Pos[0],LaserCheckDistance,GroundLayer);
        RaycastHit2D B_Ray_G = Raycast(LaserCheckPoint.transform,Pos[1],LaserCheckDistance,GroundLayer);
        RaycastHit2D C_Ray_G = Raycast(LaserCheckPoint.transform,Pos[2],LaserCheckDistance,GroundLayer);

        Target[0] = A_Ray_G.point;
        Target[1] = B_Ray_G.point;
        Target[2] = C_Ray_G.point;


        for(var i = 0; i < Point.Length; i++)
        {
            if(!Ready[i])
            {
                Point[i].transform.position = Vector2.MoveTowards(Point[i].transform.position,Target[i],moveSpeed * Time.deltaTime);

                if(Vector2.Distance(Point[i].transform.position,Target[i]) < 0.1f)
                {
                    Ready[i] = true;
                }
            }
        }

        if(time > 0)
        {
            time -= Time.deltaTime;
        }
        else if(time <= 0)
        {
            transform.Rotate(0,0,rotateSpeed);

            Point[0].transform.position = A_Ray_G.point;
            Point[1].transform.position = B_Ray_G.point;
            Point[2].transform.position = C_Ray_G.point;
        }
        


        //print(A_Ray_G.point);
        /*Point[0].transform.position = A_Ray_G.point;
        Point[1].transform.position = B_Ray_G.point;
        Point[2].transform.position = C_Ray_G.point;*/
    }

    RaycastHit2D Raycast(Transform pointpos, Vector2 raydir, float raydis, LayerMask layer)
    {
        RaycastHit2D hit = Physics2D.Raycast(pointpos.position,raydir,raydis,layer);
        
        Color color = hit? Color.red:Color.green;

        Debug.DrawRay(pointpos.position,raydir * raydis,color);

        return hit;
    }
}
