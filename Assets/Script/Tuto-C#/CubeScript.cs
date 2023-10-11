using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScript : MonoBehaviour
{

    public Color baseColor;
    public Color overColor;
    Material mat;
    public GameObject cube;
    GameObject selectedCube = null;

    private void Start(){
        mat = GetComponent<MeshRenderer>().material;
        baseColor = mat.color;
    }

    private void OnMouseOver() {
        selectedCube = this.gameObject;
        mat.color = overColor;    
    }

    private void OnMouseExit() {
        selectedCube = null;
        mat.color = baseColor;
    }

    private void OnMouseUp() {
        Vector3 pos = this.transform.position + Vector3.up;
        GameObject go = Instantiate(cube, pos, Quaternion.identity);
        go.GetComponent<MeshRenderer>().material.color = new Color(0.1f, 0.8f, 01f);
    }

    private void Update() {
        if(Input.GetMouseButton(1)){
            Destroy(selectedCube);
        }
    }
}
