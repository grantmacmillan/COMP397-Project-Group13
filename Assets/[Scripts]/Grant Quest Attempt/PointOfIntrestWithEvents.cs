using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PointOfIntrestWithEvents : MonoBehaviour
{
    public static event Action<PointOfIntrestWithEvents> OnPointOfIntrestEntered;

    [SerializeField]
    private string _poiName;

    public string PoiName { get { return _poiName; } }

    private void OnTriggerEnter(Collider other)
    {
        if (OnPointOfIntrestEntered != null)
        {
            OnPointOfIntrestEntered(this);
        }
    }
}
