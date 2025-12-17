using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static QuestSO;


[Serializable]
public class QuestInstance 
{
    public QuestSO questSO;
    public int currentCount;
    public bool isCompleted;

    public QuestInstance(QuestSO quest)
    {
        this.questSO = quest;
        currentCount = 0;
        isCompleted = false;
    }
    public void OnGather(ItemSO item)
    {
        if (isCompleted) return;
        if (questSO.questType != QuestType.Gather) return;
        if (questSO.targetItem != item) return;

        currentCount++;

        if (currentCount >= questSO.targetCount)
        {
            isCompleted = true;
            Debug.Log($"퀘스트 완료: {questSO.questName}");
        }
    }

    public void OnCraft(ItemSO item)
    {
        if (isCompleted) return;
        if (questSO.questType != QuestType.Craft) return;
        if (questSO.targetItem != item) return;

        currentCount++;

        if (currentCount >= questSO.targetCount)
        {
            isCompleted = true;
            Debug.Log($"퀘스트 완료: {questSO.questName}");
        }
    }
}
