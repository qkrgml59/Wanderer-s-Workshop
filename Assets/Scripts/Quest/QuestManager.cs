using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public static QuestManager Instance;

    [Header("진행중인 퀘스트")]
    public List<QuestInstance> activeQuests = new List<QuestInstance>();

    private void Awake()
    {
        Instance = this;
    }

    //퀘스트 수락

   public void AcceptQuest(QuestSO questData)
    {
        

        QuestInstance newQuest = new QuestInstance(questData);

        activeQuests.Add(newQuest);

        Debug.Log($"퀘스트 수락 : {questData.questName}");

        //UI 업데이트 추후 추가
    }

    public void OnGatherItem(ItemType gatheredItem)
    {
        foreach (var quest in activeQuests)
        {
            //목표 아이템이 맞으면 진행도 증가
            if (quest.data.targetItem == gatheredItem)
            {
                quest.currentAmount++;

                Debug.Log($"진행 업데이트: {quest.data.questName}{quest.currentAmount}/{quest.data.requiredAmount}");

                if(quest.currentAmount >= quest.data.requiredAmount)
                {
                    CompleteQuest(quest);
                }
            }
        }
    }

    private void CompleteQuest(QuestInstance quest)
    {
        quest.isCompleted = true;

        Debug.Log($"퀘스트 완료 : {quest.data.questName}");

        PlayerStats.Instance.AddGold(quest.data.rewardGold);
        PlayerStats.Instance.UpgradeGatherDamage(quest.data.rewardDamage);
        PlayerStats.Instance.UpgradeGatherDamage(quest.data.rewardGatherSpeed);

    }
}
