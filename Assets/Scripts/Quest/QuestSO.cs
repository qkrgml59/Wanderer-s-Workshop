using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public enum QuestType
{
    Gather,
    Craft
}

[CreateAssetMenu(menuName = "Quest/QuestSO")]
public class QuestSO : ScriptableObject
{
    public string questName;       // 퀘스트 이름
    public QuestType questType;    // Gather / Craft

    public ItemSO targetItem;      // 목표 아이템
    public int targetCount;        // 목표 개수
}
