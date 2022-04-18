using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class AchievementMenu : MonoBehaviour
{
    public AchievementsScriptableObject achievements;

    public List<Image> images;

    public Image achImage;

    public TextMeshProUGUI header, title, description;
    // Start is called before the first frame update
    void Start()
    {
        SetupAchievements();
    }

    private void SetupAchievements()
    {
        for (int i = 0; i < images.Count; i++)
        {
            images[i].sprite = achievements.achievements[i].image;
            if (achievements.achievements[i].isUnlocked == false)
            {
                images[i].color = new Color(0.39f, 0.39f, 0.39f, 0.48f);
            }
            else
            {
                images[i].color = new Color(1, 1, 1, 1);
            }
        }
    }
    public void OnAchievementClick(int count)
    {
        achImage.sprite = achievements.achievements[count].image;
        if (achievements.achievements[count].isUnlocked == true)
        {
            header.text = "Unlocked";
            header.color = new Color(1, 0.83f, 0.11f);
            achImage.color = new Color(1, 1, 1, 1);
        }
        else
        {
            header.text = "Locked";
            header.color = new Color(0.39f, 0.39f, 0.39f);
            achImage.color = new Color(0.39f, 0.39f, 0.39f, 0.48f);
        }

        title.text = achievements.achievements[count].title;
        description.text = achievements.achievements[count].description;
    }

}
