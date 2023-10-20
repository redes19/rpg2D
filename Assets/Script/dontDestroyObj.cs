using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dontDestroyObj : MonoBehaviour
{

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

 
}
