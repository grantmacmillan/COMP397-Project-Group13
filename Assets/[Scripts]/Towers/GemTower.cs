using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemTower : MonoBehaviour
{
    private int collectionTime = 30;

    //Records position and count of gem towers
    void Awake() {
        if (this.name.StartsWith("Gem") && !SaveManager.instance.hasLoaded) {
            //Adds to save data
            SaveManager.instance.activeSave.gemTowerPositions.Add(this.transform.position.x);
            SaveManager.instance.activeSave.gemTowerPositions.Add(this.transform.position.y);
            SaveManager.instance.activeSave.gemTowerPositions.Add(this.transform.position.z);

            //Counts the number of cannon turrets placed
            SaveManager.instance.activeSave.gemTowerCount++;
        }
    }

    // Start is called before the first frame update
    void Start() {
        StartCoroutine(AddGem(collectionTime));
    }

    private IEnumerator AddGem(int time) {
        while (true) {
            yield return new WaitForSeconds(time);
            ResourceManager.gems += 1;
        }
    }
}
