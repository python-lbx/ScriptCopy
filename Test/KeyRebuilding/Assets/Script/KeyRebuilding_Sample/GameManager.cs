using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager GM;

    public KeyCode jump{get;set;}
    public KeyCode forward{get;set;}
    public KeyCode backward{get;set;}
    public KeyCode left{get;set;}
    public KeyCode right{get;set;}

    void Awake() 
    {
        //唯一
        if(GM == null)
        {
            DontDestroyOnLoad(gameObject);
            GM = this;
        }
        else if(GM != this)
        {
            Destroy(gameObject);
        }


        //按鍵預存
        jump = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("jumpKey","Space"));
        forward = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("forwardKey","W"));
        backward = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("backwardKey","S"));
        left = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("leftKey","A"));
        right = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("rightKey","D"));

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
