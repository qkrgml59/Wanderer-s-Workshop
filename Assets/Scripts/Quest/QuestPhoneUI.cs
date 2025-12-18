using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestPhoneUI : MonoBehaviour
{
    [Header("패널")]
    public GameObject phonePanel;

    [Header("퀘스트 UI 슬롯")]
    public QuestSlotUI[] questSlots; // 각 슬롯마다 텍스트를 표시

    private bool isOpen = false;

    private void Start()
    {
        phonePanel.SetActive(false);
        RefreshUI();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Toggle();
        }
    }

    public void Toggle()
    {
        isOpen = !isOpen;
        phonePanel.SetActive(isOpen);
        if (isOpen)
            RefreshUI();
    }

    // UI 업데이트 함수
    public void RefreshUI()
    {
        List<QuestInstance> quests = QuestManager.Instance.activeQuests;

        for (int i = 0; i < questSlots.Length; i++)
        {
            if (i < quests.Count)
            {
                questSlots[i].SetQuest(quests[i]);
                questSlots[i].gameObject.SetActive(true);
            }
            else
            {
                questSlots[i].gameObject.SetActive(false);
            }
        }
    }

    public void AcceptQuest(QuestSO quest)
    {
        QuestManager.Instance.activeQuests.Add(new QuestInstance(quest));
        RefreshUI();
    }

    public void CompleteQuest(QuestInstance quest)
    {
        if (!quest.isCompleted)
        {
            quest.isCompleted = true;
            PlayerStats.Instance.AddGold(quest.questSO.rewardGold);
            RefreshUI();
        }
    }
}


