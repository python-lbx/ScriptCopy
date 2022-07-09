using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    public ReturnTest result;
    public int A;
    public int B;
    public static bool can;

    // Start is called before the first frame update
    void Start()
    {
        result = FindObjectOfType<ReturnTest>();
    }

    // Update is called once per frame
    void Update()
    {   

        print(result.Compare(A,B));
    }
}
