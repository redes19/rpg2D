using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestGiver : MonoBehaviour
{
    public Quest quest;
    public GameObject questPannel;
    public TMP_Text[] QuestInfos;

    public string questCompletedMsg;

    public int xp = 50;

    public int po = 25;

    public GameObject[] ToHideAfterQuestCompleted;
    public GameObject[] ToHideShowQuestCompleted;


    public void HideObjectAfterQuest(){
        foreach (GameObject go in ToHideAfterQuestCompleted)
        {
            go.SetActive(false);
        }
    }

    public void ShowObjectAfterQuestTaken(){
        foreach (GameObject go in ToHideShowQuestCompleted)
        {
            go.SetActive(true);
        }
    }
}

