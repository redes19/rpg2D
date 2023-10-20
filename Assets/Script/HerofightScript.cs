using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HerofightScript : MonoBehaviour
{
    public int vie = 5;
    public int force = 2;
    public GameObject enemy;
    Vector3 initialPos;
    EnemyScript enemyScript;
    public bool canfight = true;
    public GameObject camFight;
    public GameObject baseEnnemy;
    public AudioClip audioclip;



    void Start(){
        initialPos = transform.position;

        enemyScript = enemy.GetComponent<EnemyScript>();
    }


    public void Atk1(){
        // iTween.MoveFrom(gameObject, enemy.transform.position, 1);

        if(canfight){
            StartCoroutine("PlayAtk");

            canfight = false;
        }
        
    }

    IEnumerator PlayAtk(){
        GetComponent<AudioSource>().PlayOneShot(audioclip);
        iTween.MoveTo(gameObject, enemy.transform.position, 0.4f); // Animation de mouvement vers l'ennemie
        enemyScript.vie -= force; // enlève la vie
        enemyScript.SetLifeBar(); // appel la fonction de la barre de l'ennemie 

        yield return new WaitForSeconds(0.45f);

        iTween.MoveTo(gameObject, initialPos, 0.8f);

        if(enemyScript.vie <= 0){
            yield return new WaitForSeconds(0.7f);
            enemy.SetActive(false);
            yield return new WaitForSeconds(0.7f);
            camFight.SetActive(false);
            baseEnnemy.SetActive(false);
            MobBehaviour mb = baseEnnemy.GetComponent<MobBehaviour>();
            if(mb.loot != null){
                mb.dropLoot();
            }
            HeroStats hs = GameObject.FindObjectOfType<HeroStats>().GetComponent<HeroStats>();
            hs.xp += 10;
            hs.LevelUp();
            hs.SetGUIVals(); // mettre a jour l'interface des lvl xp po
        } else {
            yield return new WaitForSeconds(0.8f);
            enemyScript.AtkHero();
        }
    }
}
