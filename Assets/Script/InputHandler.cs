using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{

    public GameObject panelStat;

    public IncreaseStats increaseS;
    
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape)){
            increaseS.RefreshStatsPoints();
            Time.timeScale = 0;
            panelStat.SetActive(true);
        }
    }

    public void SetTimesScaleOn(){
        Time.timeScale = 1;
    }
}
