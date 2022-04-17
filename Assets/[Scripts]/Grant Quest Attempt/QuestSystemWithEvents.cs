using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestSystemWithEvents : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.DeleteAll();

        PointOfIntrestWithEvents.OnPointOfIntrestEntered += PointOfIntrestWithEvents_OnPointOfIntrestEntered;
    }

    private void OnDestroy()
    {
        PointOfIntrestWithEvents.OnPointOfIntrestEntered -= PointOfIntrestWithEvents_OnPointOfIntrestEntered;
    }

    private void PointOfIntrestWithEvents_OnPointOfIntrestEntered(PointOfIntrestWithEvents poi)
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
