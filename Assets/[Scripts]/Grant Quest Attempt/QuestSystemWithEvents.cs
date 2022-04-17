using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestSystemWithEvents : MonoBehaviour
{
    // Start is called before the first frame update
    public QuestGiver questBox;

    private List<string> descriptionList = new List<string>();
    private List<string> rewardList = new List<string>();
    public List<Quest> questList = new List<Quest>();

    void Start()
    {
        PlayerPrefs.DeleteAll();

        PointOfIntrestWithEvents.OnPointOfIntrestTriggered += PointOfIntrestWithEvents_OnPointOfIntrestTriggered;

        Node.OnTowerBuilt += Node_OnTowerBuilt;

        //add to description box
        descriptionList.Add("Buld your first tower and get a reward");
        descriptionList.Add("Add Second Description here");
        descriptionList.Add("Add third Description here");
        descriptionList.Add("Add fourth Description here");

        //add to reward box
        rewardList.Add("10");
        rewardList.Add("20");
        rewardList.Add("30");
        rewardList.Add("40");

    }

    private void Node_OnTowerBuilt(Node obj)
    {
        
    }

    private void OnDestroy()
    {
        PointOfIntrestWithEvents.OnPointOfIntrestTriggered -= PointOfIntrestWithEvents_OnPointOfIntrestTriggered;
    }

    private void PointOfIntrestWithEvents_OnPointOfIntrestTriggered(PointOfIntrestWithEvents poi)
    {
        
        string questKey = "Quest #" + PointOfIntrestWithEvents.questCounter;
        

        //if (PointOfIntrestWithEvents.questCounter - PointOfIntrestWithEvents.questsCompleted == 1)
        //{
            if (PointOfIntrestWithEvents.questCounter == 1)
            {
                Debug.Log("In if Statement");
                questBox.titleText.text = questKey;
                questBox.descriptionText.text = questList[PointOfIntrestWithEvents.questCounter - 1].description;
                questBox.rewardAmount.text = rewardList[0];
            }
            if (PointOfIntrestWithEvents.questCounter == 2)
            {
                //Quest #2
                questBox.titleText.text = questKey;
                questBox.descriptionText.text = descriptionList[1];
                questBox.rewardAmount.text = rewardList[1];
            }
            if (PointOfIntrestWithEvents.questCounter == 3)
            {
                //Quest #3
                questBox.titleText.text = questKey;
                questBox.descriptionText.text = descriptionList[2];
                questBox.rewardAmount.text = rewardList[2];
            }
            if (PointOfIntrestWithEvents.questCounter == 4)
            {
                //Quest #4
                questBox.titleText.text = questKey;
                questBox.descriptionText.text = descriptionList[3];
                questBox.rewardAmount.text = rewardList[3];
            }

       // }


        if (PlayerPrefs.GetInt(questKey) == 1)
        {
            return;
        }

        PlayerPrefs.SetInt(questKey, 1);
        Debug.Log("Unlocked " + poi.PoiName);
    }

    
}
