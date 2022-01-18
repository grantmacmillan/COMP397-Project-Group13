using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = System.Numerics.Vector2;
using Vector3 = UnityEngine.Vector3;

public class CameraController : MonoBehaviour
{
    public float panSpeed, zoomSpeed;
    private float currentZoom = 0f, zoomRotation = 1;
    private Vector2 zoomRange = new Vector2(-7, 7);
    private Vector2 panRangeX = new Vector2(0, 14);
    private Vector2 panRangeZ = new Vector2(-10, 0);
    private Vector3 initPos, initRotation;
    // Update is called once per frame

    void Start()
    {
        initPos = transform.position;
        initRotation = transform.eulerAngles;
    }
    void Update()
    {
        //panning camera with WASD/Arrows
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveX, 0, moveZ) * panSpeed * Time.deltaTime;

        //bounds for panning, could probably be condensed in some way
        transform.Translate(movement, Space.World);
        if(transform.position.x < panRangeX.X) transform.position = new Vector3(panRangeX.X, transform.position.y, transform.position.z);
        if (transform.position.x > panRangeX.Y) transform.position = new Vector3(panRangeX.Y, transform.position.y, transform.position.z);
        if (transform.position.z < panRangeZ.X) transform.position = new Vector3(transform.position.x, transform.position.y, panRangeZ.X);
        if (transform.position.z > panRangeZ.Y) transform.position = new Vector3(transform.position.x, transform.position.y, panRangeZ.Y);

        //zooming in/out camera with scroll wheel
        currentZoom -= Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * 1000 * zoomSpeed;

        currentZoom = Mathf.Clamp(currentZoom, zoomRange.X, zoomRange.Y);

        transform.position -= new Vector3(0f,(transform.position.y - (initPos.y + currentZoom)) * 0.1f, 0f);
        transform.eulerAngles -= new Vector3((transform.eulerAngles.x - (initRotation.x + currentZoom * zoomRotation)) * 0.1f, 0f, 0f);
    }
}
