using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdlPNJScript : MonoBehaviour
{
    public Vector3 amount;

    public float time;

    // Start is called before the first frame update
    void Start()
    {
        // repiration
        iTween.ScaleTo(gameObject, iTween.Hash(
            "x", amount.x,
            "y", amount.y,
            "z", amount.z,
            "time", time,
            "looptype", iTween.LoopType.pingPong
        ));
    }

}
