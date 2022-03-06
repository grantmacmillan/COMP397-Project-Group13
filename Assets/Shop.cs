using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    private BuildManager buildManager;

    public Tower cannonTower, balistaTower, blasterTower;

    void Start()
    {
        buildManager = BuildManager.instance;
    }
    public void PurchaseCannonTower()
    {
        buildManager.SetTurretToBuild(buildManager.turrets[0]);
    }
    public void PurchaseBalistaTower()
    {
        buildManager.SetTurretToBuild(buildManager.turrets[1]);
    }
    public void PurchaseBlasterTower()
    {
        buildManager.SetTurretToBuild(buildManager.turrets[2]);
    }


    public void Toggle()
    {
        if (gameObject.activeSelf)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }
}
