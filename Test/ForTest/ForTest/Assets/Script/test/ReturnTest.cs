using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnTest : MonoBehaviour
{
    public int num;
    public int result;
    public int A;
    public int B;
    // Start is called before the first frame update
    void Start()
    {
        //print(Cube(5)); //將 5 傳入 cube 入面的 num

        result = num * num * num;
        //print(result);

    }

    // Update is called once per frame
    void Update()
    {
        //print(Compare(A,B));
    }

    static int Cube(int num) //接收 5
    {
        int result = num * num * num; //運算
        return result; //將結果回傳比cube
    }

    public bool Compare(int first,int second)
    {

        if(first > second)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
