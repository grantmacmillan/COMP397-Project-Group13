using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance; 
    private GameObject turretToBuild;
    public List<GameObject> turrets = new List<GameObject>();

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        turretToBuild = turrets[0];
    }
    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }
}
