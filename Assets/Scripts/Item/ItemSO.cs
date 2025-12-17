using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;


[CreateAssetMenu(fileName = "New Item", menuName = "Survival Game/Item")]
public class ItemSO : ScriptableObject
{   // Start is called before the first frame update

    [Header("아이템 이름")]
    public string itemName;

    [Header("아이템 타입")]
    public ItemType itemType;

    [Header("아이템 기본 스택 가능 수")]
    public int maxStack = 99;

    [Header("아이콘 이미지")]
    public Sprite icon;

    [Header("설치 아이템")]
    public bool isPlaceable;                 // 설치 가능 여부
    public GameObject placePrefab;           // 설치될 프리팹

    public bool canUse;             //아이템 사용 가능 여부

    public enum ItemType
    {
        Block,
        Seed,
        Food,
        Other
    }

}
