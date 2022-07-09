using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    Transform menuPanel;
    Event keyEvent;
    Text buttonText;
    KeyCode newKey;

    bool waitingForKey;

    // Start is called before the first frame update
    void Start()
    {
        menuPanel = transform.Find("Panel");
        //menuPanel.gameObject.SetActive(false);
        waitingForKey = false;

        //各對應元物件底下的子物件
        for(int i = 0; i < menuPanel.childCount; i++)
        {
            if(menuPanel.GetChild(i).name == "ForwardKey")
            {
                menuPanel.GetChild(i).GetComponentInChildren<Text>().text = GameManager.GM.forward.ToString();
            }
            else if(menuPanel.GetChild(i).name == "BackwardKey")
            {
                menuPanel.GetChild(i).GetComponentInChildren<Text>().text = GameManager.GM.backward.ToString();
            }
            else if(menuPanel.GetChild(i).name == "LeftKey")
            {
                menuPanel.GetChild(i).GetComponentInChildren<Text>().text = GameManager.GM.left.ToString();
            }
            else if(menuPanel.GetChild(i).name == "RightKey")
            {
                menuPanel.GetChild(i).GetComponentInChildren<Text>().text = GameManager.GM.right.ToString();
            }
            else if(menuPanel.GetChild(i).name == "JumpKey")
            {
                menuPanel.GetChild(i).GetComponentInChildren<Text>().text = GameManager.GM.jump.ToString();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //開啟菜單
        if(Input.GetKeyDown(KeyCode.Escape) && !menuPanel.gameObject.activeSelf) //該物件是否激活?
        {
            menuPanel.gameObject.SetActive(true);
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && menuPanel.gameObject.activeSelf)
        {
            menuPanel.gameObject.SetActive(false);
        }
    }


    //UI控制
    private void OnGUI() 
    {
        keyEvent = Event.current;

        if(keyEvent.isKey && waitingForKey)
        {
            newKey = keyEvent.keyCode;
            waitingForKey = false;
        }
    }

    public void StartAssignment(string keyName)
    {
        if(!waitingForKey)
        {
            StartCoroutine(AssignKey(keyName));
        }
    }


    //顯示按鍵字元
    public void SendText(Text text)
    {
        buttonText = text;
    }

    IEnumerator WaitForKey()
    {
        while(!keyEvent.isKey)
        {
            yield return null;
        }
    }


    //更改按鍵
    public IEnumerator AssignKey(string keyName)
    {
        waitingForKey = true;
        yield return WaitForKey();

        switch(keyName)
        {
            case "forward":
            GameManager.GM.forward = newKey;
            buttonText.text = GameManager.GM.forward.ToString();
            PlayerPrefs.SetString("forwardKey",GameManager.GM.forward.ToString());
            break;

            case "backward":
            GameManager.GM.backward = newKey;
            buttonText.text = GameManager.GM.backward.ToString();
            PlayerPrefs.SetString("backwardKey",GameManager.GM.backward.ToString());
            break;

            case "left":
            GameManager.GM.left = newKey;
            buttonText.text = GameManager.GM.left.ToString();
            PlayerPrefs.SetString("leftKey",GameManager.GM.left.ToString());
            break;

            case "right":
            GameManager.GM.right = newKey;
            buttonText.text = GameManager.GM.right.ToString();
            PlayerPrefs.SetString("rightKey",GameManager.GM.right.ToString());
            break;

            case "jump":
            GameManager.GM.jump = newKey;
            buttonText.text = GameManager.GM.jump.ToString();
            PlayerPrefs.SetString("jumpKey",GameManager.GM.jump.ToString());
            break;
        }

        yield return null;
    }

    public void ResetKey(string keyName)
    {
        waitingForKey = true;

        switch(keyName)
        {
            case "forward":
            GameManager.GM.forward = KeyCode.W;
            buttonText.text = GameManager.GM.forward.ToString();
            PlayerPrefs.SetString("forwardKey",GameManager.GM.forward.ToString());
            break;

            case "backward":
            GameManager.GM.backward = KeyCode.S;
            buttonText.text = GameManager.GM.backward.ToString();
            PlayerPrefs.SetString("backwardKey",GameManager.GM.backward.ToString());
            break;

            case "left":
            GameManager.GM.left = KeyCode.A;
            buttonText.text = GameManager.GM.left.ToString();
            PlayerPrefs.SetString("leftKey",GameManager.GM.left.ToString());
            break;

            case "right":
            GameManager.GM.right = KeyCode.D;
            buttonText.text = GameManager.GM.right.ToString();
            PlayerPrefs.SetString("rightKey",GameManager.GM.right.ToString());
            break;

            case "jump":
            GameManager.GM.jump = KeyCode.Space;
            buttonText.text = GameManager.GM.jump.ToString();
            PlayerPrefs.SetString("jumpKey",GameManager.GM.jump.ToString());
            break;
        }

        waitingForKey = false;
    }
}
