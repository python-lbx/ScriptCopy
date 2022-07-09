using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowPool : MonoBehaviour
{
    public static ShadowPool instance;
    public GameObject swordPrefab;

    public int SwordCount;

    Queue<GameObject> availableObjects = new Queue<GameObject>();

    private void Awake() 
    {
        instance = this;

        FillPool();
    }
    // Start is called before the first frame update
    public void FillPool()
    {
        for(int i = 0; i<SwordCount ; i++)
        {
            var newSword = Instantiate(swordPrefab);
            newSword.transform.SetParent(transform);

            ReturnPool(newSword);
        }
    }

    public void ReturnPool(GameObject gameObject)
    {
        gameObject.SetActive(false);

        availableObjects.Enqueue(gameObject);
    }

    public GameObject GetFormPool()
    {
        var outSword = availableObjects.Dequeue();

        outSword.SetActive(true);

        return outSword;
    }
}
