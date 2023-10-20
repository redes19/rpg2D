using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class HeroCollider : MonoBehaviour
{

    // POUR LES PANNEAUX !!!

    public GameObject dialWorldSpace;
    public TMP_Text dialTxt;
    Collider2D otherObj;

    // disparition items 1er méthode
    // public GameObject items;
    // Collider2D otherItems;

    public QuestGiver[] quests;

    public GameObject camFight;

    HeroStats hs;

    public GameObject shop;

    void Start(){
        hs = GetComponent<HeroStats>();
    }

    void OnTriggerEnter2D(Collider2D other) {
        
        if(other.gameObject.tag == "sign"){
            otherObj = other;

            print(other.gameObject.name);
            SignBehaviour sb = other.gameObject.GetComponent<SignBehaviour>();

            sb.ui.SetActive(true);
        }

        // disparition items 1er méthode
        // if(other.gameObject.tag == "items"){
        //     otherItems = other;
        //     ItemsBehaviour ib = other.gameObject.GetComponent<ItemsBehaviour>();
        //     print(other.gameObject.name);
        //     ib.ui.SetActive(true);
        // }

        // disparition items 2eme méthode
        if(other.gameObject.tag == "items"){
            otherObj = other;
            otherObj.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }

        if(other.gameObject.tag == "exit"){
            string point = other.gameObject.GetComponent<ExitBehaviour>().teleportPoint;
            PlayerPrefs.SetString("Point", point);
            SceneManager.LoadScene(other.gameObject.name);

            // PlayerPrefs.SetFloat("posX", other.gameObject.GetComponent<ExitBehaviour>().teleportPositions.X);

            // PlayerPrefs.SetFloat("posY", other.gameObject.GetComponent<ExitBehaviour>().teleportPositions.Y);
        }

        if(other.gameObject.tag == "mob" && !camFight.activeInHierarchy){
            print("combat");
            camFight.SetActive(true);
            InitializeFight initF = camFight.GetComponent<InitializeFight>();
            initF.hfs.baseEnnemy = other.gameObject;
            initF.initFight();
        }

        if(other.gameObject.tag == "coin"){
            Destroy(other.gameObject);
            hs.po += Random.Range(3,10);
            hs.SetGUIVals();
        }

        if(other.gameObject.tag == "shop"){
            shop.SetActive(true);
        }

    }

    void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.tag == "sign"){
            SignBehaviour sb = other.gameObject.
            GetComponent<SignBehaviour>();
            sb.ui.SetActive(false);
            Invoke("HideDialPannel", 1);
            otherObj = null;
        }

        // disparition items 1er méthode
        // if(other.gameObject.tag == "items"){
        //     ItemsBehaviour ib = other.gameObject.GetComponent<ItemsBehaviour>();
        //     ib.ui.SetActive(false);
        //     otherItems = null;
        // }

        // disparition items 2eme méthode
        if(other.gameObject.tag == "items"){
            otherObj.gameObject.transform.GetChild(0).gameObject.SetActive(false);
            otherObj = null;
        }

        if(other.gameObject.tag == "shop"){
            shop.SetActive(false );
        }

    }

    public void HideDialPannel(){
        dialWorldSpace.SetActive(false);
    }

    void Update() {
        if(Input.GetKeyUp(KeyCode.E) && otherObj != null){
            ShowDial();
        }

        if(Input.GetKeyUp(KeyCode.A) && otherDial != null){
            PNJDial();
        }

        // disparition items 1er méthode
        // if(Input.GetKeyUp(KeyCode.P) && otherItems != null){
        //     ShowItems();
        //     items.gameObject.SetActive(false);
        // }

        // disparition items 2eme méthode
        if(Input.GetKeyUp(KeyCode.P) && otherObj != null){
            if(otherObj.gameObject.tag == quests[0].quest.objType){ // === otherObj.gameObject.tag == "items"
                otherObj.gameObject.transform.GetChild(0).gameObject.SetActive(false);
                otherObj.gameObject.SetActive(false);
                otherObj = null;
                quests[0].quest.IncrementCount();
            }

            // exemple autre quest 
            // if(otherObj.gameObject.tag == quests[1].quest.objType){
            //     quests[1].quest.IncrementCount();
            // }
        }

    }

    // disparition items 1er méthode
    // public void ShowItems(){
    //     ItemsBehaviour ib = otherItems.gameObject.GetComponent<ItemsBehaviour>();
    //     ib.ui.SetActive(false);
    //     items.SetActive(true);
    // }

    public void ShowDial(){
    if (otherObj != null) {
        SignBehaviour sb = otherObj.gameObject.GetComponent<SignBehaviour>();
        sb.ui.SetActive(false);
        dialWorldSpace.SetActive(true);
        dialTxt.SetText(sb.signTexte);
    }
}


    // POUR LES PNJ !!!

    public GameObject dialCanvas;
    public TMP_Text txtCanvas;
    Collision2D otherDial;

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "garde"){
            otherDial = other;
            PNJSimpleDial pnj = other.gameObject.GetComponent<PNJSimpleDial>();
            print(other.gameObject.name);
            pnj.ui.SetActive(true);

        }
    }

    private void OnCollisionExit2D(Collision2D other) {
        if(other.gameObject.tag == "garde"){
            PNJSimpleDial pnj = other.gameObject.GetComponent<PNJSimpleDial>();
            pnj.ui.SetActive(false);
            otherDial = null;
            HideDialCanvase();
        }
    }

    void PNJDial(){
    if (otherDial != null) {
        PNJSimpleDial pnj = otherDial.gameObject.GetComponent<PNJSimpleDial>();
        pnj.ui.SetActive(false);
        ShowDialCanvasTxt(pnj.simpleDial);
    }
}

    public void ShowDialCanvasTxt(string msg){
        dialCanvas.SetActive(true);
        txtCanvas.SetText(msg);
    }

    public void HideDialCanvase(){
        dialCanvas.SetActive(false);
    }

}
