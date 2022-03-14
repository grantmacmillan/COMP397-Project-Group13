using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance; 
    private Tower turretToBuild;
    private GameObject selectedTile;
    private Button btn;
    public List<Tower> turrets = new List<Tower>();

    private void Awake()
    {
        instance = this;
        btn = GameObject.Find("Place Tower").GetComponent<Button>();
#if UNITY_IOS || UNITY_ANDROID
        btn.onClick.AddListener(BuildTowerOnTile);
#endif
    }
    private void Start()
    {
        btn.gameObject.SetActive(false);
    }
    public Tower GetTurretToBuild()
    {
        return turretToBuild;
    }

    public void SetTurretToBuild(Tower turret)
    {
        turretToBuild = turret;
    }
#if UNITY_IOS || UNITY_ANDROID
    public void SetTileSelected(GameObject tile)
    {
        selectedTile = tile;
    }

    private void BuildTowerOnTile()
    {
        selectedTile.GetComponent<Node>().BuildTower();
    }
#endif
}
