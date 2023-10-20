using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HeroStats : MonoBehaviour
{
    public TMP_Text lvlTxt;
    public TMP_Text xpTxt;
    public TMP_Text poTxt;
    public int lvl;
    public int xp;
    public int po;
    public int nextLvlXp = 100;
    public int armorResistance = 1;
    public GameObject imageArmor;

    void Start(){
        lvl = PlayerPrefs.GetInt("level", + 1);
        xp = PlayerPrefs.GetInt("xp", + 0);
        po = PlayerPrefs.GetInt("gold", + 0);
        nextLvlXp = PlayerPrefs.GetInt("nextLvlXp", + 20);
        SetGUIVals();
    }

    public void LevelUp(){
        if(xp >= nextLvlXp){
            xp -= nextLvlXp;
            nextLvlXp += 15;
            lvl++;
            LevelUp();
            int statsPoints = PlayerPrefs.GetInt("statsPoints", 0);
            PlayerPrefs.SetInt("statsPoints", statsPoints + 2);
        }

    }

    public void SetGUIVals(){
        lvlTxt.text = "Level "+ lvl;
        xpTxt.text = "XP: " + xp + "/" + nextLvlXp;
        poTxt.text = "Gold: " + po;
        SaveHeroStats();
    }

    public void SaveHeroStats(){
        PlayerPrefs.SetInt("level", + lvl);
        PlayerPrefs.SetInt("xp", + xp);
        PlayerPrefs.SetInt("gold", + po);
        PlayerPrefs.SetInt("nextLvlXp", + nextLvlXp);
       
    }

    public  void ImproveArmor(){
        if(po >= 30){
            po -= 30;
            armorResistance ++;
            SetGUIVals();
            if(po < 30){
                imageArmor.SetActive(false);
            }
        }
    }

}
