using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

[CreateAssetMenu(fileName = "New Quest",menuName = "Survival Game/Event")]

public class QuestSO : ScriptableObject 
{
    [Header("퀘스트 기본 정보")]
    public string questID;          //퀘스트 고유 번호
    public string questName;        //퀘스트 이름
    [TextArea]
    public string description;      //설명

    [Header("목표 아이템 정보")]
    public ItemType targetItem;
    public int requiredAmount;         //목표 수량

    [Header("보상 정보")]
    public int rewardGold;              //골드 보상
    public float rewardGatherSpeed;     //채집 속도 강화량
    public float rewardDamage;          //채집 데미지 가오하량

    [Header("아이콘")]
    public Sprite Icon;


   


}
