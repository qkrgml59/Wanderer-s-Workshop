using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

[CreateAssetMenu(fileName = "New Quest",menuName = "Survival Game/Event")]


public class QuestSO : ScriptableObject 
{

    public QuestType questType;

    // 제작 퀘스트용
    public ItemSO targetItem;
    public int requiredAmount;

    // 보상
    public int rewardGold;


    public enum QuestType
    {
        Gather,
        Craft
    }
}
