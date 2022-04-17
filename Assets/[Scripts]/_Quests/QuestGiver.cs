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
}
