using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;
using System;

public class Node : MonoBehaviour, IDropHandler
{
    private GameObject turret;
    public Vector3 positionOffset;
    public Color hoverColor;
    private Color originalColor;
    private Button btn;
    private Renderer renderer;
    

    private BuildManager buildManager;

    public GameObject towerRadiusPrefab, radiusObject;

    public static event Action<Tower> OnTowerBuilt;


    //for the quest
    public Quest quest;
    public int towersBuilt = 0;
    public ResourceManager resourceManager;
    public TextMeshProUGUI goldText, woodText, gemsText, livesText;

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
    public void OnDrop(PointerEventData data)
    {
        Debug.Log("dropped on node");
#if UNITY_STANDALONE
        if (EventSystem.current.IsPointerOverGameObject())
            return;
#endif
#if UNITY_IOS || UNITY_ANDROID
       /* if (EventSystem.current.IsPointerOverGameObject(0))
            return;*/
#endif
        if (buildManager.GetTurretToBuild() != null)
        {
#if UNITY_IOS || UNITY_ANDROID
            buildManager.SetTileSelected(this.gameObject);
            btn.gameObject.SetActive(true);
            buildManager.MovePlaceholder(transform.position + positionOffset);
#endif
            /*radiusObject = (GameObject) Instantiate(towerRadiusPrefab, transform.position + new Vector3(0, 0.2f, 0),
                transform.rotation);
            radiusObject.transform.localScale = new Vector3(buildManager.GetTurretToBuild().range,
                radiusObject.transform.localScale.y, buildManager.GetTurretToBuild().range);
            renderer.materials[1].color = hoverColor;*/
        }
    }

    /*public void OnPointerExit(PointerEventData data)
    {
        Debug.Log("pointerexit");
        renderer.materials[1].color = originalColor;
        Destroy(radiusObject);
    }*/
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

            Tower tower = buildManager.GetTurretToBuild();
            if (ResourceManager.Purchase(tower.gold, tower.wood, tower.gem))
            {
                FindObjectOfType<Sound_Manager>().Play("Build");
                GameObject turretToBuild = tower.towerPrefab;
                turret = (GameObject)Instantiate(turretToBuild, transform.position + positionOffset,
                    transform.rotation);
                
                buildManager.SetTurretToBuild(null);
                btn.gameObject.SetActive(false);
                if (OnTowerBuilt != null)
                {
                    OnTowerBuilt(tower);
                }
            }
        }
    }
#endif
}
