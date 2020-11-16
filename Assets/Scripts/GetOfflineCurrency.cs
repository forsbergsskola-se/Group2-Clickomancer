﻿using System;
using UnityEngine;
using TMPro;

public class GetOfflineCurrency : MonoBehaviour {
    [Header("Drag and Drop references here")]
    public SoulCount soulsRef;

    public Undead zombieRef;

    [Header("Text reference for Offline Time")]
    public TextMeshProUGUI offlineTimeText;

    public string offlineTimeTextString;

    [Header("Text reference for Offline Produced Souls text")]
    public TextMeshProUGUI offlineProductionText;

    public string offlineProductionTextString;

    public string OfflineTime {
        get => PlayerPrefs.GetString("SoulsEarnedOffline", "0000-00-00");
        private set => PlayerPrefs.SetString("SoulsEarnedOffline", value.ToString());
    }
    
    public int FirstTimePlaying {
        get => PlayerPrefs.GetInt("FirstTimePlaying", 1);
        private set => PlayerPrefs.SetInt("FirstTimePlaying", value);
    }

    private void Awake() {
        if (FirstTimePlaying != 1)
        {
            CalculateOfflineProduction();
        }
        FirstTimePlaying = 0;
    }

    private void OnApplicationQuit() {
        OfflineTime = DateTime.Now.ToString();
    }

    private void CalculateOfflineProduction() {
        var currentTime = DateTime.Now;
        var offlineTime = Convert.ToDateTime(OfflineTime);
        var interval = currentTime - offlineTime;

        var totalProduction = zombieRef.CalculateTotalProduction();

        double totalOfflineProduction =
            (float) interval.TotalSeconds * totalProduction;
        soulsRef.Souls += totalOfflineProduction;
        soulsRef.TotalSoulsOwned += totalOfflineProduction;

        offlineTimeText.text =
            $"{offlineTimeTextString} {interval.Days}d, {interval.Hours}h, {interval.Minutes}m, {(int) interval.TotalSeconds}s!";
        offlineProductionText.text = $"{offlineProductionTextString} {totalOfflineProduction}!";
    }
}