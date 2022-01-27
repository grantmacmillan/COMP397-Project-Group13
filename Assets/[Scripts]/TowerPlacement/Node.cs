using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Node : MonoBehaviour
{
    private GameObject turret;
    public Vector3 positionOffset;
    public Color hoverColor;
    private Color originalColor;

    private Renderer renderer;

    void Start()
    {
        renderer = GetComponent<Renderer>();
        originalColor = renderer.materials[1].color;
    }

    private void OnMouseDown()
    {
        if (turret != null)
        {
            Debug.Log("occupied");
            return;
        }

        GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
        turret = (GameObject)Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);

    }
    private void OnMouseEnter()
    {
        renderer.materials[1].color = hoverColor;
    }

    private void OnMouseExit()
    {
        renderer.materials[1].color = originalColor;
    }
}
