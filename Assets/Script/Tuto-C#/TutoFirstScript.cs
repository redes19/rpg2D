using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutoFirstScript : MonoBehaviour
{
    [SerializeField] public string message = "Mon message !";

    public int nombre = 10;

    public float speed = 5.5f;

    public bool isTrue = false;

    public MeshRenderer mr;

    public Collider col;

    public Renderer rend;

    public Color couleur;


    // Start is called before the first frame update
    void Start()
    {
        print(message + " " + nombre + " " + isTrue);
        mr.enabled = false;
        col = gameObject.GetComponent<Collider>();
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        transform.Rotate(Vector3.right * Time.deltaTime * 30);
    }


    private void OnMouseDown() {
        rend.material.color = couleur;

        // ajout un rigidbody
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        // annule la graviter du rigidbody
        rb.useGravity = false;
    }

}
