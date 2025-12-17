using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
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

    // 제작 성공 시 호출
    public void OnCraft(ItemSO craftedItem)
    {
        foreach (var quest in activeQuests)
        {
            if (quest.isCompleted) continue;
            if (quest.data.questType != QuestType.Craft) continue;

            if (quest.data.targetItem == craftedItem)
            {
                quest.currentAmount++;

                if (quest.currentAmount >= quest.data.requiredAmount)
                {
                    CompleteQuest(quest);
                }
            }
        }
    }

    void CompleteQuest(QuestInstance quest)
    {
        quest.isCompleted = true;
        PlayerStats.Instance.AddGold(quest.data.rewardGold);
    }
}
