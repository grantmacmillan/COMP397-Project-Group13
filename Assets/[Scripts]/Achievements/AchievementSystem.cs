using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementSystem : MonoBehaviour
{
    public AchievementsScriptableObject achievements;

    public int enemyKillCount;

    public int goldEarned;
    // Start is called before the first frame update

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    void Start()
    {
        Enemy.OnEnemyKill += Enemy_OnEnemyKill;
        EnemyWaveSpawning.OnWaveCompleted += EnemyWaveSpawning_OnWaveCompleted;
        Quest.OnComplete += Quest_OnComplete;
    }

    private void Quest_OnComplete(Quest quest)
    {
        if (quest.rewardType == Quest.RewardType.Gold)
        {
            goldEarned += quest.rewardAmount;
        }
        foreach (Achievement achievement in achievements.achievements)
        {
            if (!achievement.isUnlocked && achievement.type == Achievement.AchievementType.Gold && achievement.amount <= goldEarned)
            {
                achievement.Unlock();
            }
        }
    }

    private void EnemyWaveSpawning_OnWaveCompleted(int gold)
    {
        goldEarned += gold;
        foreach (Achievement achievement in achievements.achievements)
        {
            if (!achievement.isUnlocked && achievement.type == Achievement.AchievementType.Gold && achievement.amount <= goldEarned)
            {
                achievement.Unlock();
            }
        }
    }

    private void Enemy_OnEnemyKill(Enemy enemy)
    {
        enemyKillCount++;
        goldEarned += enemy.goldAmount;
        foreach (Achievement achievement in achievements.achievements)
        {
            if (!achievement.isUnlocked && achievement.type == Achievement.AchievementType.Kill && achievement.amount <= enemyKillCount)
            {
                achievement.Unlock();
            }
            if (!achievement.isUnlocked && achievement.type == Achievement.AchievementType.Gold && achievement.amount <= goldEarned)
            {
                achievement.Unlock();
            }
        }
    }
}
