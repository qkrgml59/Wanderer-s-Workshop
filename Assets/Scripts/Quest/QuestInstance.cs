using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static QuestSO;


[Serializable]
public class QuestInstance 
{
    public QuestSO quest;
    public int currentCount;
    public bool isCompleted;

    public QuestInstance(QuestSO quest)
    {
        this.quest = quest;
        currentCount = 0;
        isCompleted = false;
    }
    public void OnGather(ItemSO item)
    {
        if (isCompleted) return;
        if (quest.questType != QuestType.Gather) return;
        if (quest.targetItem != item) return;

        currentCount++;

        if (currentCount >= quest.targetCount)
        {
            isCompleted = true;
            Debug.Log($"퀘스트 완료: {quest.questName}");
        }
    }

    public void OnCraft(ItemSO item)
    {
        if (isCompleted) return;
        if (quest.questType != QuestType.Craft) return;
        if (quest.targetItem != item) return;

        currentCount++;

        if (currentCount >= quest.targetCount)
        {
            isCompleted = true;
            Debug.Log($"퀘스트 완료: {quest.questName}");
        }
    }
}
