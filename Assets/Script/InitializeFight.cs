using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeFight : MonoBehaviour
{
    public GameObject mob;

    EnemyScript es;

    public HerofightScript hfs;

    public void initFight(){
        mob.SetActive(true);
        es = mob.GetComponent<EnemyScript>();
        es.vie = 3;
        hfs.canfight = true;
        es.SetLifeBar();
    }
}
