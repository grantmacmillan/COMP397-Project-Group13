using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class QuestSystemWithEvents : MonoBehaviour
{
    // Start is called before the first frame update
    public QuestGiver questBox;
    public static int questCounter = 0;

    private List<string> descriptionList = new List<string>();
    private List<string> rewardList = new List<string>();
    public List<Quest> questList = new List<Quest>();

    void Start()
    {
        Quest_OnComplete(questList[0]);
        PlayerPrefs.DeleteAll();

        Node.OnTowerBuilt += Node_OnTowerBuilt;
        Quest.OnComplete += Quest_OnComplete;
        Shop.OnOpenShop += Shop_OnOpenShop;
        EnemyWaveSpawning.OnStartGame += EnemyWaveSpawning_OnStartGame;

        //add to description box
        descriptionList.Add("Build your first tower and get a reward");
        descriptionList.Add("Add Second Description here");
        descriptionList.Add("Add third Description here");
        descriptionList.Add("Add fourth Description here");

        //add to reward box
        rewardList.Add("10");
        rewardList.Add("20");
        rewardList.Add("30");
        rewardList.Add("40");

    }

    private void EnemyWaveSpawning_OnStartGame()
    {
        if (questCounter == 4)
        {
            questList[4].Complete();
        }
    }

    private void Shop_OnOpenShop()
    {
        if (questCounter == 0)
        {
            questList[0].Complete();
        }
    }

    private void Node_OnTowerBuilt(Tower tower)
    {
        if(questCounter == 1 && tower.towerPrefab.name == "Cannon")
        {
            questList[1].Complete();
        }
        if (questCounter == 2 && tower.towerPrefab.name == "Wood")
        {
            questList[2].Complete();
        }
        if (questCounter == 3 && tower.towerPrefab.name == "Cannon")
        {
            questList[3].Complete();
        }
    }

    private void Quest_OnComplete(Quest quest)
    {
        string questKey = "Quest #" + PointOfIntrestWithEvents.questCounter;
        

        //if (PointOfIntrestWithEvents.questCounter - PointOfIntrestWithEvents.questsCompleted == 1)
        //{
            if (PointOfIntrestWithEvents.questCounter == 0)
            {
                Debug.Log("In if Statement");
                questBox.titleText.text = questList[0].title;
                questBox.descriptionText.text = questList[0].description;
                questBox.rewardAmount.text = questList[0].rewardAmount.ToString();
            }
            if (PointOfIntrestWithEvents.questCounter == 1)
            {
                //Quest #2
                questBox.titleText.text = questKey;
                questBox.descriptionText.text = descriptionList[1];
                questBox.rewardAmount.text = rewardList[1];
            }
            if (PointOfIntrestWithEvents.questCounter == 2)
            {
                //Quest #3
                questBox.titleText.text = questKey;
                questBox.descriptionText.text = descriptionList[2];
                questBox.rewardAmount.text = rewardList[2];
            }
            if (PointOfIntrestWithEvents.questCounter == 3)
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
        
    }

    
}
