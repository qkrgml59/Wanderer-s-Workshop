using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestPhoneUI : MonoBehaviour
{
    public GameObject phoneUI;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            phoneUI.SetActive(!phoneUI.activeSelf);
        }
    }

    public void AcceptQuest(QuestSO quest)
    {
        QuestManager.Instance.activeQuests.Add(new QuestInstance(quest));
    }
}
