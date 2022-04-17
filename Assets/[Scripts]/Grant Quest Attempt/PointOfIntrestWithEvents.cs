using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PointOfIntrestWithEvents : MonoBehaviour
{
    public static event Action<PointOfIntrestWithEvents> OnPointOfIntrestTriggered;

    [SerializeField]
    private string _poiName;

    public string PoiName { get { return _poiName; } }

    private void OnTriggerEnter(Collider other)
    {
        if (OnPointOfIntrestTriggered != null)
        {
            OnPointOfIntrestTriggered(this);
        }
    }

    public void TriggerQuest()
    {
        Debug.Log("Here");
        if (OnPointOfIntrestTriggered != null)
        {
            Debug.Log("Not Here");
            OnPointOfIntrestTriggered(this);
        }
    }
}
