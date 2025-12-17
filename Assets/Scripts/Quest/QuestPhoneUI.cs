using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestPhoneUI : MonoBehaviour
{
    public GameObject phonePanel;

    private bool isOpen = false;

    private void Start()
    {
        phonePanel.SetActive(false);
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
    }

    public void AcceptQuest(QuestSO quest)
    {
        QuestManager.Instance.activeQuests.Add(new QuestInstance(quest));
    }

    public void CompleteQuest(QuestInstance quest)
    {
        if (!quest.isCompleted)
        {
            quest.isCompleted = true;
            PlayerStats.Instance.AddGold(quest.questSO.rewardGold);
        }
    }
}

