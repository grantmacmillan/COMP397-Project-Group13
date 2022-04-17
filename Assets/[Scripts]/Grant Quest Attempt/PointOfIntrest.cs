using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointOfIntrest : Subject
{
    [SerializeField]
    private string poiName;

    private void OnTriggerEnter(Collider other)
    {
        //Notify(poiName, NotificationType.QuestUnlocked);
    }
}
