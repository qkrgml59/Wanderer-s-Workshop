using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class QuestInstance 
{
    public QuestSO data;
    public int currentAmount;
    public bool isCompleted;

    public QuestInstance(QuestSO data)
    {
        this.data = data;
    }
}
