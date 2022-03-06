using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemTower : MonoBehaviour
{
    private int collectionTime = 30;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AddGem(collectionTime));
    }
    private IEnumerator AddGem(int time)
    {
        while (true)
        {
            yield return new WaitForSeconds(time);
            ResourceManager.gems += 1;
        }
    }
}
