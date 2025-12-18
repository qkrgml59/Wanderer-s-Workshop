using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestSlotUI : MonoBehaviour
{
    public TextMeshProUGUI questNameText;
    public TextMeshProUGUI progressText;

    private QuestInstance quest;

    public void SetQuest(QuestInstance quest)
    {
        this.quest = quest;
        questNameText.text = quest.questSO.questName;
        progressText.text = $"{quest.currentCount}/{quest.questSO.targetCount}";
    }
}
