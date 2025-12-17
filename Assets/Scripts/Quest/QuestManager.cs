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
        Instance = this;
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
