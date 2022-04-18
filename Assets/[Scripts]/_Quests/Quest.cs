using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Quest
{
    public static event Action<Quest> OnComplete;
    public string title;
    public string description;
    public Sprite questIcon;
    public Sprite rewardIcon;
    public int rewardAmount;
    public RewardType rewardType;
    public enum RewardType
    {
        Gold,
        Wood,
        Gem
    }


    public void Complete()
    {
        QuestSystemWithEvents.questCounter++;
        SaveManager.instance.activeSave.currentQuest = QuestSystemWithEvents.questCounter;

        if (rewardType == RewardType.Gold)
        {
            ResourceManager.gold += rewardAmount;
            SaveManager.instance.activeSave.goldAmount += rewardAmount;
        }
        if (rewardType == RewardType.Wood)
        {
            ResourceManager.wood += rewardAmount;
            SaveManager.instance.activeSave.woodAmount += rewardAmount;
        }
        if (rewardType == RewardType.Gem)
        {
            ResourceManager.gems += rewardAmount;
            SaveManager.instance.activeSave.gemAmount += rewardAmount;
        }
        if (OnComplete != null)
        {
            OnComplete(this);
        }
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
