using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodTower : MonoBehaviour
{
    private int collectionTime = 10;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AddWood(collectionTime));
    }
    private IEnumerator AddWood(int time)
    {
        while (true)
        {
            yield return new WaitForSeconds(time);
            ResourceManager.wood += 1;
        }
    }
}
