using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour
{
    public GameObject[] _temp;
    public bool isfull;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0 ; i < _temp.Length ; i++)
        {
                    print(i);

            if(_temp[i] == null)
            {   
                isfull = false;
                break;
            }
            else if(_temp[i] != null)
            {
                isfull = true;
            }

        }
    }
}
