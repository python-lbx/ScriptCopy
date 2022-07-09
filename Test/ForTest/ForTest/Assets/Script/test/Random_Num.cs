using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Random_Num : MonoBehaviour
{
    public int[] x; //箱子數 例如 4個 
    public int y; //for loop 檢查4個箱子
    public int num; //隨機數 
    //從1~10之間抽4個號碼,而且之間不重覆;
    // Start is called before the first frame update
    void Start()
    {   
        for(var i = 0; i < x.Length; i++)
        {
            num = Random.Range(0,10);
            for(y = 0 ; y < i ; y++)
            {
                if(x[y] == num)
                {
                    num = Random.Range(0,10);
                    y = -1;
                }
            }

            x[i] = num;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    public static void Main()
    {
        int len = 10;
        int[] x = new int[len];
        x = pick(len);

        foreach(var item in x)
        {
            print(item.ToString());
        }

    }

    public static int[] pick(int len)
    {
        int[] x = new int[len];
        int num;

        for(int i=0;i<len;i++)
        {
            num = Random.Range(0,10);

            for(int y = 0; y<i; y++)
            {
                if(x[y] == num)
                {
                    num = Random.Range(0,10);
                    y = -1;
                }
                else
                {
                    x[i] = num;
                }
            }
        }
        return x;
    }
}   
