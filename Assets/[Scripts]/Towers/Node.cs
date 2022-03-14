using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Node : MonoBehaviour
{
    private GameObject turret;
    public Vector3 positionOffset;
    public Color hoverColor;
    private Color originalColor;
    private Button btn;
    private Renderer renderer;

    private BuildManager buildManager;

    public GameObject towerRadiusPrefab, radiusObject;

    void Awake()
    {
        btn = GameObject.Find("Place Tower").GetComponent<Button>();
    }
    void Start()
    {
        buildManager = BuildManager.instance;
        renderer = GetComponent<Renderer>();
        originalColor = renderer.materials[1].color;
    }
#if UNITY_STANDALONE
    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (buildManager.GetTurretToBuild() != null)
        {
            Debug.Log("Place");
            if (turret != null)
            {
                Debug.Log("occupied");
                return;
            }

            Tower tower = BuildManager.instance.GetTurretToBuild();
            if (ResourceManager.Purchase(tower.gold, tower.wood, tower.gem))
            {
                GameObject turretToBuild = tower.towerPrefab;
                turret = (GameObject) Instantiate(turretToBuild, transform.position + positionOffset,
                    transform.rotation);
                buildManager.SetTurretToBuild(null);
            }
        }
    }
#endif
    private void OnMouseEnter()
    {
#if UNITY_STANDALONE
        if (EventSystem.current.IsPointerOverGameObject())
            return;
#endif
#if UNITY_IOS || UNITY_ANDROID
        if (EventSystem.current.IsPointerOverGameObject(0))
            return;
#endif
        if (buildManager.GetTurretToBuild() != null)
        {
            radiusObject = (GameObject)Instantiate(towerRadiusPrefab, transform.position + new Vector3(0, 0.2f, 0), transform.rotation);
            radiusObject.transform.localScale = new Vector3(buildManager.GetTurretToBuild().range, radiusObject.transform.localScale.y, buildManager.GetTurretToBuild().range);
            renderer.materials[1].color = hoverColor;
#if UNITY_IOS || UNITY_ANDROID
            buildManager.SetTileSelected(this.gameObject);
            btn.gameObject.SetActive(true);
#endif
        }
    }

    private void OnMouseExit()
    {
        renderer.materials[1].color = originalColor;
        Destroy(radiusObject);
    }
#if UNITY_IOS || UNITY_ANDROID
    public void BuildTower()
    {
        if (buildManager.GetTurretToBuild() != null)
        {
            Debug.Log("Place");
            if (turret != null)
            {
                Debug.Log("occupied");
                return;
            }

            Tower tower = BuildManager.instance.GetTurretToBuild();
            if (ResourceManager.Purchase(tower.gold, tower.wood, tower.gem))
            {
                GameObject turretToBuild = tower.towerPrefab;
                turret = (GameObject)Instantiate(turretToBuild, transform.position + positionOffset,
                    transform.rotation);
                buildManager.SetTurretToBuild(null);
                btn.gameObject.SetActive(false);
            }
        }
    }
#endif
}
