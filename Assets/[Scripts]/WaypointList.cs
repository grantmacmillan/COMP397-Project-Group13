using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointList : MonoBehaviour
{
    public static Transform[] waypoints;

    private void Awake()
    {
        waypoints = new Transform[transform.childCount];
        for (int w = 0; w < waypoints.Length; w++)
        {
            waypoints[w] = transform.GetChild(w);
        }
    }
}
