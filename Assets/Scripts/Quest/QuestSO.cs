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
    [Header("퀘스트 정보")]
    public string questName;
    public string description;

    [Header("퀘스트 타입")]
    public QuestType questType;

    [Header("목표")]
    public ItemSO targetItem;
    public int targetCount;

    [Header("보상")]
    public int rewardGold;
}
