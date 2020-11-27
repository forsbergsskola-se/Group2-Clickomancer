﻿using System;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Library : MonoBehaviour {
    private HelperClass helperClassRef;

    [Header("Text reference for Soul text")]
    public TMP_Text soulText;
    public TMP_Text upgradeText;
    public TMP_Text soulsPerClickText;

    [Header("Text reference for Rebirth text")]
    public TMP_Text rebirthText;
    public TMP_Text bonusText;
    public TMP_Text rebirthThreshold;

    [Header("Text reference for Mana text")]
    public TMP_Text manaText;

    [Header("Text reference for Total Undead Production text")]
    public TMP_Text totalUndeadProductionText;

    [Header("Text reference for Zombie text")]
    public TMP_Text zombieStatusText;
    public TMP_Text zombiePurchaseCostsText;
    public TMP_Text zombieUpgradeCostsText;
    public TMP_Text zombieTotalProductionText;

    [Header("Text reference for Death Knight text")]
    public TMP_Text deathknightStatusText;
    public TMP_Text deathknightPurchaseCostsText;
    public TMP_Text deathknightUpgradeCostsText;
    public TMP_Text deathknightTotalProductionText;

    [Header("Text reference for Wraith text")]
    public TMP_Text wraithStatusText;
    public TMP_Text wraithPurchaseCostsText;
    public TMP_Text wraithUpgradeCostsText;
    public TMP_Text wraithTotalProductionText;

    [Header("Text reference for Lich text")]
    public TMP_Text lichStatusText;
    public TMP_Text lichPurchaseCostsText;
    public TMP_Text lichUpgradeCostsText;
    public TMP_Text lichTotalProductionText;

    [Header("Text reference for Monstrosity text")]
    public TMP_Text monstrosityStatusText;
    public TMP_Text monstrosityPurchaseCostsText;
    public TMP_Text monstrosityUpgradeCostsText;
    public TMP_Text monstrosityTotalProductionText;

    // alternatively a MonoBehaviour that is then hooked up.
    // GameObject Lich (Undead) ==> GameObject LichUI (UndeadUI)
    [Serializable]
    public class ClassTextElements {
        public Text StatusText;
        public Text PurchaseCostsText;
        public Text UpgradeCostsText;
        public Text TotalProductionText;
    }
    
    /*
     * NEW:
     * Lich
     *     Status Text
     *     Purchase Costs Text
     *     ...
     * Death Knight
     *     Status Text
     *     Purchase Costs Text
     *
     * OLD:
     * [Text reference for Lich text]
     * Lich Status Text
     * Lich Purchase Costs Text
     *
     * [Tex...
     */

    public ClassTextElements Deathknight;
    public ClassTextElements Lich;
    
    public ClassTextElements GetClassTextElements(string name) {
        switch (name) {
            case "Lich":
                return this.Lich;
            case "DeathKnight":
                return this.Deathknight;
        }
        throw new System.Exception();
    }
    
    private void Awake() {
        helperClassRef = GetComponentInParent<HelperClass>();
    }
}