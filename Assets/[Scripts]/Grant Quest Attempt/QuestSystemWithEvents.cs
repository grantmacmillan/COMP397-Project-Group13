using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestSystemWithEvents : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.DeleteAll();

        PointOfIntrestWithEvents.OnPointOfIntrestTriggered += PointOfIntrestWithEvents_OnPointOfIntrestTriggered;
    }

    private void OnDestroy()
    {
        PointOfIntrestWithEvents.OnPointOfIntrestTriggered -= PointOfIntrestWithEvents_OnPointOfIntrestTriggered;
    }

    private void PointOfIntrestWithEvents_OnPointOfIntrestTriggered(PointOfIntrestWithEvents poi)
    {
        string questKey = "quest-" + poi.PoiName;

        if (PlayerPrefs.GetInt(questKey) == 1)
        {
            return;
        }

        PlayerPrefs.SetInt(questKey, 1);
        Debug.Log("Unlocked " + poi.PoiName);
    }

    
}
