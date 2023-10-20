using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class IncreaseStats : MonoBehaviour
{
    public int statsPoints;
    public TMP_Text forceTxt;
    public TMP_Text magieTxt;

    void Start(){
        SetTxt();
        RefreshStatsPoints();
    }

    public void RefreshStatsPoints(){
        statsPoints = PlayerPrefs.GetInt("statsPoints", 0);
    }

    public void IncreaseselectStat(string statName)
    {
        if(statsPoints > 0){
            statsPoints --;
            PlayerPrefs.SetInt("statsPoints", statsPoints);
            // sauvegarde des stats
            PlayerPrefs.SetInt(statName, PlayerPrefs.GetInt(statName, 1)+1);
            SetTxt();
        }
        
    }

    public void SetTxt(){
        forceTxt.text = "Force: " + PlayerPrefs.GetInt("force", 1);
        magieTxt.text = "Magie: " + PlayerPrefs.GetInt("magie", 1);
    }
}
