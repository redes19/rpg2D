using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public int vie = 3;
    public int force = 1;
    public GameObject barreVie;
    float scaleX;

    public GameObject hero;
    Vector3 initialPos;

    HerofightScript hfs;

    void Start(){
        initialPos = transform.position;
        hfs = hero.GetComponent<HerofightScript>();
        scaleX=barreVie.transform.localScale.x/vie ;
    }

    public void SetLifeBar(){
        barreVie.transform.localScale  = new Vector3(scaleX * vie, 0.125f, 1); 
    }

    public void AtkHero(){
        StartCoroutine("PlayAtk");
    }

    IEnumerator PlayAtk(){
        iTween.MoveTo(gameObject, hero.transform.position, 0.3f);
        hfs.vie -= force;

        yield return new WaitForSeconds(0.3f);

        iTween.MoveTo(gameObject, initialPos, 0.6f);

        if(hfs.vie <= 0){
            yield return new WaitForSeconds(0.5f);
            hero.SetActive(false);

            print("Perdu!!!");
        }
        hfs.canfight = true;
    }

}
