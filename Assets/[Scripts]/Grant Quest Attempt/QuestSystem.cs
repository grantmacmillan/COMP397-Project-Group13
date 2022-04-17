using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestSystem : Observer
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.DeleteAll();

        foreach (var poi in FindObjectOfType<PointOfIntrest>())
        {
            poi.RegisterObserver(this);
        }
    }

    public override void OnNotify(object value, NotificationType notificationType)
    {
        if (notificationType == NotificationType.QuestUnlocked)
        {
            string questKey = "quest-" + value;

            if (PlayerPrefs.GetInt(questKey)==1)
            {
                return;
            }

            PlayerPrefs.SetInt(questKey, 1);
            Debug.Log("Unlocked "+ value);
        }
    }
}

public enum NotificationType
{
    QuestUnlocked
}
