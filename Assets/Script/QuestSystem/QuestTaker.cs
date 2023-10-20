using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestTaker : MonoBehaviour
{

    QuestGiver qg;

    HeroStats hs;

    void Start() {
        hs = GetComponent<HeroStats>();
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "AddQuest"){
            if(qg == null){
                qg = other.gameObject.GetComponent<QuestGiver>();
                int isQuestDone = PlayerPrefs.GetInt(qg.questName, 0);
                if(!qg.quest.isActive && isQuestDone == 0){ // quest non active 
                    qg.questPannel.SetActive(true);
                    qg.QuestInfos[0].SetText(qg.quest.title);
                    qg.QuestInfos[1].SetText(qg.quest.desc);
                    qg.QuestInfos[2].SetText("XP: " + qg.quest.xp + " | gold: " + qg.quest.gold);
                }
                else { // quest active
                    if(qg.quest.isCompleted){
                        qg.HideObjectAfterQuest();
                        qg.ShowObjectAfterQuestTaken();
                        print("Recompense = xp " + qg.xp + " | gold: " + qg.po);
                        GetComponent<HeroCollider>().ShowDialCanvasTxt(qg.questCompletedMsg);
                        hs.xp += qg.xp;
                        hs.po += qg.po;
                        qg.po = 0;
                        qg.xp = 0;
                        hs.LevelUp();
                        hs.SetGUIVals();
                        PlayerPrefs.SetInt(qg.questName, 1);
                    }
                }
            }
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.tag == "AddQuest"){
            qg.questPannel.SetActive(false);
            qg = null;
            GetComponent<HeroCollider>().HideDialCanvase();
            
        }
    }

    public void TakeQuest(){
        qg.quest.isActive = true;
        qg.questPannel.SetActive(false);
    }


}
