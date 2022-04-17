using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class QuestGiver : MonoBehaviour

{   [SerializeField] private GameObject questMenu;
    public Quest quest;
    public ResourceManager resourceManager;
    public Node node;
    public List<Node> listOfTiles = new List<Node>();
    public GameObject parent;

    public Text titleText;
    public Text descriptionText;
    public Image rewardImage;
    public Text rewardAmount;

    private void Start()
    {
        for (int i = 0; i < parent.transform.childCount; i++)
        {
            listOfTiles.Add(parent.transform.GetChild(i).GetComponent<Node>());
            StartQuest(parent.transform.GetChild(i).GetComponent<Node>());
        }
    }

    public void CloseQuestMenu()
    {
        questMenu.SetActive(false);
    }

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
        quest.isActive = true;
    }

     
    public void StartQuest(Node node)
    {
        Debug.Log("Start quest function");
        node.quest = quest;
        quest.isActive = true;
        resourceManager.quest = quest;
        
    }
}
