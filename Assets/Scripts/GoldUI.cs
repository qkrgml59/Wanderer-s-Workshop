using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class GoldUI : MonoBehaviour
{
    public TextMeshProUGUI goldText;

    void Update()
    {
        if (PlayerStats.Instance != null && goldText != null)
        {
            goldText.text = PlayerStats.Instance.gold.ToString();
        }
    }
}