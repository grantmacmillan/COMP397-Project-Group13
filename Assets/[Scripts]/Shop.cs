using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Shop : MonoBehaviour
{
    private BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }
    public void PurchaseCannonTower() {
        buildManager.SetTurretToBuild(buildManager.turrets[0]);
        buildManager.SetTileSelected(null);
        buildManager.DestroyPlaceholder();
        buildManager.InstantiatePlaceholder();
        StartCoroutine("MoveImage");
    }
    public void PurchaseBalistaTower() {
        buildManager.SetTurretToBuild(buildManager.turrets[1]);
        buildManager.SetTileSelected(null);
        buildManager.DestroyPlaceholder();
        buildManager.InstantiatePlaceholder();
        StartCoroutine("MoveImage");
    }

    public void PurchaseBlasterTower() {
        buildManager.SetTurretToBuild(buildManager.turrets[2]);
        buildManager.SetTileSelected(null);
        buildManager.DestroyPlaceholder();
        buildManager.InstantiatePlaceholder();
        StartCoroutine("MoveImage");
    }

    public void PurchaseWoodTower()
    {
        buildManager.SetTurretToBuild(buildManager.turrets[3]);
        buildManager.SetTileSelected(null);
        buildManager.DestroyPlaceholder();
        buildManager.InstantiatePlaceholder();
        StartCoroutine("MoveImage");
    }

    public void PurchaseGemTower() {
        buildManager.SetTurretToBuild(buildManager.turrets[4]);
        buildManager.SetTileSelected(null);
        buildManager.DestroyPlaceholder();
        buildManager.InstantiatePlaceholder();
        StartCoroutine("MoveImage");
    }

    public void SetTowerToBuildNull()
    {
        buildManager.SetTurretToBuild(null);
    }

    public void StopMoveImage()
    {
        Debug.Log("drag ended");
        StopCoroutine("MoveImage");
        StartCoroutine("DestroyAfterDelay");
    }

    private IEnumerator DestroyAfterDelay()
    {
        yield return new WaitForSeconds(0.05f);
        if (buildManager.GetTileSelected() == null)
        {
            buildManager.DestroyPlaceholder();
        }
    }
    private IEnumerator MoveImage()
    {
        while (true)
        {
            Vector3 position = new Vector3(0, 0, 0);
            Plane plane = new Plane(Vector3.up, 0);
            float distance;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (plane.Raycast(ray, out distance))
            {
                position = ray.GetPoint(distance);
            }

            position.y = 0.2f;
            buildManager.MovePlaceholder(position);
            Debug.Log("Dragging");
            yield return new WaitForFixedUpdate();
        }
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
