using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroBehaviour : MonoBehaviour
{
    void Awake(){
        string point = PlayerPrefs.GetString("Point", "Point_1");
        Vector3 teleportPosition =  GameObject.Find(point).transform.position;
        transform.position = teleportPosition;
        }

    // void Awake(){
    //     string point = PlayerPrefs.GetString("Point", "Point_1");
    //     GameObject pointObject = GameObject.Find(point);
    //     if (pointObject != null) {
    //         Vector3 teleportPosition = pointObject.transform.position;
    //         transform.position = teleportPosition;
    //     } else {
    //         Debug.LogError("Le GameObject avec le nom " + point + " n'existe pas dans la scène.");
    //     }

    //     // new Vector3(x,y,0); // pour la teleportation
    // }
}
