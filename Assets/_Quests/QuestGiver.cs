using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class QuestGiver : MonoBehaviour

{   [SerializeField] private GameObject questMenu;
    public Quest quest;
    public ResourceManager resourceManager;
    
    public Text titleText;
    public Text descriptionText;
    public Image rewardImage;
    public Text rewardAmount;

    

    public void OpenQuestMenu()
    { 
        titleText.text = quest.title;
        descriptionText.text = quest.description;
        rewardImage.sprite = quest.rewardIcon;
        rewardAmount.text = quest.rewardAmount.ToString();

    }
    public void ShowQuestMenu()
    { 
        questMenu.SetActive(true);
    }

        public void CloseQuestMenu()
    {
        questMenu.SetActive(false);

    }
}
