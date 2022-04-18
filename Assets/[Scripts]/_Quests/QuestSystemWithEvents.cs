using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class QuestSystemWithEvents : MonoBehaviour
{
    // Start is called before the first frame update
    public static int questCounter;
    public TextMeshProUGUI title, description, rewardAmount;

    public Image rewardImage;
    public Image questImage;
    public Image progressBar;
    public GameObject tutorial;

    public List<Quest> questList = new List<Quest>();

    
    void Start()
    {
        questCounter = 0;
        if (SaveManager.instance.hasLoaded)
        {
            questCounter = SaveManager.instance.activeSave.currentQuest;
        }
        else
        {
            questCounter = 0;
        }
        SaveManager.instance.activeSave.currentQuest = questCounter;
        if (questCounter == 5)
        {
            tutorial.SetActive(false);
        }
        else
        {
            Quest_OnComplete(questList[questCounter]);
        }
        Node.OnTowerBuilt += Node_OnTowerBuilt;
        Quest.OnComplete += Quest_OnComplete;
        Shop.OnOpenShop += Shop_OnOpenShop;
        EnemyWaveSpawning.OnStartGame += EnemyWaveSpawning_OnStartGame;
    }

    private void EnemyWaveSpawning_OnStartGame()
    {
        if (questCounter == 4)
        {
            questList[4].Complete();
            tutorial.SetActive(false);
        }
        else
        {
            for (int i = questCounter; i < questList.Count; i++)
            {
                questList[i].Complete();
            }
            tutorial.SetActive(false);
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
        if (tower == null)
            return;
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
        if (questCounter < questList.Count)
        {
            progressBar.fillAmount = (float)questCounter/(float)questList.Count;
            title.text = questList[questCounter].title;
            description.text = questList[questCounter].description;
            rewardAmount.text = questList[questCounter].rewardAmount.ToString();
            rewardImage.sprite = questList[questCounter].rewardIcon;
            questImage.sprite = questList[questCounter].questIcon;
        }
    }

    private void OnDestroy()
    {
        Node.OnTowerBuilt -= Node_OnTowerBuilt;
        Quest.OnComplete -= Quest_OnComplete;
        Shop.OnOpenShop -= Shop_OnOpenShop;
        EnemyWaveSpawning.OnStartGame -= EnemyWaveSpawning_OnStartGame;
    }

    
}
