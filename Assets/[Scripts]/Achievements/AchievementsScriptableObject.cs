using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/AchievementsScriptableObject", order = 1)]
public class AchievementsScriptableObject : ScriptableObject
{
    public List<Achievement> achievements;
}
