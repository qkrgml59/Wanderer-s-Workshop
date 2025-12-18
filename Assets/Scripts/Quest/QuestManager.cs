using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using UnityEngine;
using static QuestSO;

public class QuestManager : MonoBehaviour
{
    public static QuestManager Instance;

    public List<QuestInstance> activeQuests = new();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AcceptQuest(QuestSO quest)
    {
        activeQuests.Add(new QuestInstance(quest));
        Debug.Log($"Äù½ºÆ® ¼ö¶ô: {quest.questName}");
    }

    public void CompleteQuest(QuestInstance quest)
    {
        if (!quest.isCompleted)
        {
            quest.isCompleted = true;
            PlayerStats.Instance.AddGold(quest.questSO.rewardGold);
            Debug.Log($"Äù½ºÆ® ¿Ï·á: {quest.questSO.questName}");
        }
    }

    public void OnGather(ItemSO item)
    {
        foreach (var quest in activeQuests)
            quest.OnGather(item);
    }

    public void OnCraft(ItemSO item)
    {
        foreach (var quest in activeQuests)
            quest.OnCraft(item);
    }
}
