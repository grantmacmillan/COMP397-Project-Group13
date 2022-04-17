using System;
using UnityEngine;

[System.Serializable]
public class Achievement
{
    public static event Action<Achievement> OnUnlock;
    public Sprite image;
    public string title;
    public string description;
    public int amount;
    public bool isUnlocked;
    public AchievementType type;
    public enum AchievementType
    {
        Kill,
        Gold
    }

    public void Unlock()
    {
        isUnlocked = true;
        if (OnUnlock != null)
        {
            OnUnlock(this);
        }
    }
}
