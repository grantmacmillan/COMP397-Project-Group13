using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Quest 
{
    public bool isActive;
    
    public string title;
    public string description;
    public Sprite rewardIcon;
    public int rewardAmount;

    public QuestGoal goal;


    public void Complete()
    {
        isActive = false;
        Debug.Log(title = " is completed");
    }

   /*
    public Quest(Text titleText, Text descriptionText, Image rewardImage,int rewardAmount)
    {
        title = titleText.text;
        description =descriptionText.text;
        rewardIcon = rewardImage.sprite;
        this.rewardAmount = rewardAmount;
    }
   */
}
