using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject MyBag;

    public bool isopen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        openmybag();
    }

    void openmybag()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            isopen = !isopen;
            MyBag.SetActive(isopen);

            InventoryManager.CleanItemInfo();
        }
    }
}