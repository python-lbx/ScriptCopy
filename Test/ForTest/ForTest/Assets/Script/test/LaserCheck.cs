using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserCheck : MonoBehaviour
{
    public Transform LaserCheckPoint;
    public LayerMask PlayerLayer;
    public LayerMask GroundLayer;
    public float LaserCheckDistance;
    public bool Player;
    public bool IsOnGround;
    public bool faceup;

    public GameObject UpPoint;
    public GameObject DownPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PhysicalCheck();

        if(transform.position.y > UpPoint.transform.position.y)
        {
            faceup = false;
        }
        else if(transform.position.y < DownPoint.transform.position.y)
        {
            faceup = true;
        }
    }

    void PhysicalCheck()
    {
        RaycastHit2D PlayerRay = Raycast(LaserCheckPoint,Vector2.right,LaserCheckDistance,PlayerLayer);
        //RaycastHit2D GroundRay = Raycast(LaserCheckPoint,Vector2.right,LaserCheckDistance,GroundLayer);

        if(PlayerRay)
        {
            Player = true;
        }
        else
        {
            Player = false;
        }
    }

    RaycastHit2D Raycast(Transform pointpos, Vector2 raydir, float raydis, LayerMask layer)
    {
        RaycastHit2D hit = Physics2D.Raycast(pointpos.position,raydir,raydis,layer);
        
        Color color = hit? Color.red:Color.green;

        Debug.DrawRay(pointpos.position,raydir * raydis,color);

        return hit;
    }
}
