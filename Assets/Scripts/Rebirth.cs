﻿using UnityEngine;

public class Rebirth : MonoBehaviour {
    private HelperClass helperClassRef;
    [SerializeField] private GameObject rebirthInfoBox;

    [Header("Drag and Drop reference here")]
    public SoulCount SoulRef;
    public double modifierFactor = 1f;
    public int rebirthThreshold = 1000;
    // public int rebirthThresholdModifier = 10;

    public int Reborn {
        get => PlayerPrefs.GetInt("Rebirth", 0);
        set => PlayerPrefs.SetInt("Rebirth", value);
    }

    public string RebirthModifier {
        get => PlayerPrefs.GetString("RebirthModifier", "1");
        set => PlayerPrefs.SetString("RebirthModifier", value);
    }

    void Update() {
        Display();
    }

    private void Awake() {
        helperClassRef = GetComponentInParent<HelperClass>();
    }

    // private void CalculateRebirthThresholdModifer() {
    //     rebirthThreshold *= rebirthThresholdModifier;
    // }

    private void CalculateRebirthModifer() {
        double amountOfSouls = helperClassRef.StringToDouble(helperClassRef.soulRef.TotalSoulsOwned);
        if (rebirthThreshold < amountOfSouls) {
            Reborn++;
            IncreaseRebirthModifier(amountOfSouls);
            Display();
            ResetSession();
            rebirthInfoBox.SetActive(false);
        }
    }

    void ResetSession() {
        var souls = FindObjectOfType<SoulCount>();
        souls.Souls = 0;
        // int = -2 billion <-> + 2 billion
        // long = -2 billion * 2 billion <-> + 2 billion * 2 billion
        // double = inaccurate, allows for decimal numbers, and much higher numbers, but then very inaccurate
        // float = like double, but half as accurate
        // BigInt = int, but endless
        this.helperClassRef.DoubleToString(0, "Souls");
        this.helperClassRef.DoubleToString(0, "TotalSoulsOwned");
        this.helperClassRef.soulRef.UpgradeLevel = 0;
        this.helperClassRef.undeadRef.ResetUndeadChildCountLevel();
    }

    void IncreaseRebirthModifier(double amountOfSouls) {
        double modToAdd = amountOfSouls * this.modifierFactor / 1000;
        double currentMod = this.helperClassRef.StringToDouble(this.RebirthModifier);
        double totalModToAdd = currentMod + modToAdd;
        this.RebirthModifier = totalModToAdd.ToString();
        helperClassRef.DoubleToString(totalModToAdd, "RebirthModifier");
    }

    public void RebirthButton() {
        CalculateRebirthModifer();
    }

    public void OpenRebirthInfoButton() {
        rebirthInfoBox.SetActive(true);
    }

    public void CloseRebirthInfoButton() {
        rebirthInfoBox.SetActive(false);
    }

    private void Display() {
        helperClassRef.libraryRef.rebirthText.text = "Rebirth:" + Reborn;
        helperClassRef.libraryRef.bonusText.text = "Bonus:" + RebirthModifier;
        helperClassRef.libraryRef.rebirthThreshold.text =
            "Souls needed for rebirth:" + rebirthThreshold.ToString(format: "1 mil");
    }
}