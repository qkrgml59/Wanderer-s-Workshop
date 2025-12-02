using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class QuestInstance 
{
    [Header("퀘스트 데이터 원본(SO)")]
    public QuestSO data;                    //ScriptableObject 원본

    [Header("진행 상태")]
    public int currentAmount = 0;
    public bool isCompleted = false;

    public QuestInstance(QuestSO data)
    {
        this.data = data;
        currentAmount = 0;
        isCompleted = false;
    }
}
