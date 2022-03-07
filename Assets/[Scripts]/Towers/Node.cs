using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    private GameObject turret;
    public Vector3 positionOffset;
    public Color hoverColor;
    private Color originalColor;

    private Renderer renderer;

    private BuildManager buildManager;

    public GameObject towerRadiusPrefab, radiusObject;

    void Start()
    {
        buildManager = BuildManager.instance;
        renderer = GetComponent<Renderer>();
        originalColor = renderer.materials[1].color;
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        if (buildManager.GetTurretToBuild() != null)
        {
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
    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        if (buildManager.GetTurretToBuild() != null)
        {
            radiusObject = (GameObject)Instantiate(towerRadiusPrefab, transform.position + new Vector3(0,0.2f,0), transform.rotation);
            radiusObject.transform.localScale = new Vector3(buildManager.GetTurretToBuild().range, radiusObject.transform.localScale.y, buildManager.GetTurretToBuild().range);
            renderer.materials[1].color = hoverColor;
        }
    }

    private void OnMouseExit()
    {
        renderer.materials[1].color = originalColor;
        Destroy(radiusObject);
    }
}
