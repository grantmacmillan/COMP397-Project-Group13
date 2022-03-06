using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance; 
    private Tower turretToBuild;
    public List<Tower> turrets = new List<Tower>();

    private void Awake()
    {
        instance = this;
    }
    public Tower GetTurretToBuild()
    {
        return turretToBuild;
    }

    public void SetTurretToBuild(Tower turret)
    {
        turretToBuild = turret;
    }
}
