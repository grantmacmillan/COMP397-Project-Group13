using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodTower : MonoBehaviour
{
    private int collectionTime = 10;

    //Records position and count of wood towers
    void Awake()
    {
        if (this.name.StartsWith("Wood") && !SaveManager.instance.hasLoaded && EnemyWaveSpawning.isFirstSave)
        {
            //Adds to save data
            SaveManager.instance.activeSave.woodTowerPositions.Add(this.transform.position.x);
            SaveManager.instance.activeSave.woodTowerPositions.Add(this.transform.position.y);
            SaveManager.instance.activeSave.woodTowerPositions.Add(this.transform.position.z);

            //Counts the number of cannon turrets placed
            SaveManager.instance.activeSave.woodTowerCount++;
        }

        if (this.name.StartsWith("Wood") && !SaveManager.instance.hasLoaded && !EnemyWaveSpawning.isFirstSave)
        {
            //Adds to save data
            SaveManager.instance.activeSave.tempWoodTowerPositions.Add(this.transform.position.x);
            SaveManager.instance.activeSave.tempWoodTowerPositions.Add(this.transform.position.y);
            SaveManager.instance.activeSave.tempWoodTowerPositions.Add(this.transform.position.z);

            //Counts the number of cannon turrets placed
            SaveManager.instance.activeSave.tempWoodTowerCount++;
        }
    }

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
            SaveManager.instance.activeSave.tempWood += 1;
        }
    }
}

