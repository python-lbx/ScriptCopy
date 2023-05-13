using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateLaserB : MonoBehaviour
{
    // Start is called before the first frame update
    public LineRenderer line;
    public Transform startPoint;
    public Transform A_Point;

    // Start is called before the first frame update
    void Start()
    {
        line = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        line.SetPosition(0,startPoint.position);
        line.SetPosition(1,A_Point.position);
    }
}
