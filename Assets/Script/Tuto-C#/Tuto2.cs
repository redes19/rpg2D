using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tuto2 : MonoBehaviour
{


    public GameObject cubObj;
    public Color couleur2;

    // Start is called before the first frame update
    void Start()
    {
        
        for(int i=0; i < 10; i++){
            for(int j = 0; j < 10; j ++){
                GameObject go = Instantiate(cubObj, new Vector3(i, 0, j), Quaternion.identity);
                if((j % 2) == 0){
                    go.GetComponent<MeshRenderer>().material.color = couleur2;
                    go.transform.position += Vector3.up; // === new vector3(0, 1, 0)
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
