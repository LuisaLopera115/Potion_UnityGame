using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassCreator : MonoBehaviour
{
    public static GlassCreator instance;

    GameObject[] liquids;
    GameObject[] Galsses;

    [SerializeField]
    private Transform parentLocation;
    [SerializeField]
    private GameObject glass;
    private int glassCant;
    [SerializeField]
    private Color[] liquidStyles;
    private List<Color> liquiToAsign;

    private int counter, glasscompleteCounter, currentLevel;

    // Start is called before the first frame update
    private void Awake() 
    {
        if(instance == null)
        {
            instance = this;
        }

        currentLevel = 1;
        StartGame();
    }

    public void GetLiquidInGlasses(){

        liquids = GameObject.FindGameObjectsWithTag("Liquid");
        Galsses = GameObject.FindGameObjectsWithTag("Glass");

       
        for (int i = 0; i < glassCant; i++)
        {
            for (int j = 0; j < glass.GetComponentsInChildren<Transform>().Length - 1; j++) liquiToAsign.Add(liquidStyles[counter]);

            counter++;
            if(counter == glass.GetComponentsInChildren<Transform>().Length - 1) counter = 0;
        }

        for (int i = 0; i < liquiToAsign.Count; i++) {
            Color temp = liquiToAsign[i];
            int randomIndex = Random.Range(i, liquiToAsign.Count);
            liquiToAsign[i] = liquiToAsign[randomIndex];
            liquiToAsign[randomIndex] = temp;
        }

        for (int i = 0; i < liquids.Length-(glass.GetComponentsInChildren<Transform>().Length - 1); i++) 
        {
           liquids[i].GetComponent<SpriteRenderer>().color = liquiToAsign[i];
        }
    }

    public void CompletedGlases(GameObject Glass){
        glasscompleteCounter++;
        if (glasscompleteCounter == glassCant)
        {
            currentLevel += 5;
            StartGame();
        }
    }

    public void StartGame(){
        
        CheckGameLevel();

        glasscompleteCounter = 0;
        counter = 0;
        liquiToAsign = new List<Color>();

        for (int i = 0; i < glassCant; i++)
        {
            GameObject _glass = Instantiate(glass);
            _glass.name = "Glass_" + i;
            _glass.transform.SetParent(parentLocation, false);
        }
        liquids = GameObject.FindGameObjectsWithTag("Liquid");
        Galsses = GameObject.FindGameObjectsWithTag("Glass");

        GetLiquidInGlasses();
    }

    public void CheckGameLevel(){
        if (currentLevel<=5){glassCant = 5; Debug.Log("estas en un nivel inferior a 5");}
        if (currentLevel>5)glassCant = 10;
        if (currentLevel>10)glassCant = 7;
        if (currentLevel>20)glassCant = 8;
        if (currentLevel>30)glassCant = 9;
        if (currentLevel>40)glassCant = 10;
        if (currentLevel>50)glassCant = 11;
    }
}
