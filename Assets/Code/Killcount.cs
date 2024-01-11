using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KillCount : MonoBehaviour
{
    public TextMeshProUGUI killCountText;
    private int killCount = 0;

    void Start()
    {
        UpdateKillCountText();
    }

    // Call this method whenever a kill happens
    public void IncreaseKillCount()
    {
        killCount++;
        UpdateKillCountText();
    }

    void UpdateKillCountText()
    {
        if (killCountText != null)
        {
            killCountText.text = "Kills: " + killCount;
        }
    }
}

