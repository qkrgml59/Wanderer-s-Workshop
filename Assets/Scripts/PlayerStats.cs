using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats Instance;

    [Header("플레이어 스탯")]
    public int gold = 0;
    public float gatherSpeed = 1f;
    public float gatherDamage = 1f;

    private void Awake()
    {
        Instance = this;

    }

    //골드 증가
    public void AddGold(int amount)
    {
        gold += amount;
        Debug.Log("골드 증가" + gold);

    }

    //채집 속도
    public void UpgradeGatherSpeed(float amount)
    {
        gatherSpeed += amount;
        Debug.Log("채집 속도 증가: " + gatherSpeed);
    }


    //채집 데미지 

    public void UpgradeGatherDamage(float amount)
    {
        gatherDamage += amount;
        Debug.Log("채집 데미지 증가 : " + gatherDamage);
    }
}
