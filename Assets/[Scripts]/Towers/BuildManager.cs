using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance; 
    private Tower turretToBuild;
    private GameObject selectedTile, placeholder;
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

    public GameObject GetTileSelected()
    {
        return selectedTile;
    }

    private void BuildTowerOnTile()
    {

        DestroyPlaceholder();
        selectedTile.GetComponent<Node>().BuildTower();
    }
#endif
    public void InstantiatePlaceholder()
    {
        placeholder = Instantiate(turretToBuild.placeHolderPrefab, transform.position, Quaternion.identity);
    }

    public void MovePlaceholder(Vector3 pos)
    {
        placeholder.transform.position = pos;
    }

    public void MovePlaceholderToTile(Vector3 pos)
    {
        
    }

    public void DestroyPlaceholder()
    {
        if (placeholder != null)
        {
            Destroy(placeholder);
        }
    }

}
