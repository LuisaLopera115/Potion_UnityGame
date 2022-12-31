using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassCreator : MonoBehaviour
{
    public static GlassCreator instance;

    GameObject[] liquids;
    GameObject[] Glasses;

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
        liquiToAsign = new List<Color>();

        StartGame();
    }

    public void GetLiquidInGlasses(){
       
        for (int i = 0; i < glassCant; i++)
        {
            for (int j = 0; j < glass.GetComponentsInChildren<Transform>().Length - 1; j++) liquiToAsign.Add(liquidStyles[counter]);

            counter++;
            Debug.Log("counter " + counter);
            if(counter == glass.GetComponentsInChildren<Transform>().Length - 1) counter = 0;
        }

        for (int i = 0; i < liquiToAsign.Count - 1; i++) {
            Color temp = liquiToAsign[i];
            int randomIndex = Random.Range(i, liquiToAsign.Count);
            liquiToAsign[i] = liquiToAsign[randomIndex];
            liquiToAsign[randomIndex] = temp;
        }


        for (int i = 0; i < liquids.Length; i++) 
        {
           liquids[i].GetComponent<SpriteRenderer>().color = liquiToAsign[i];
        }

        // add extra empty galases

        for (int i = 0; i < 2; i++)
        {
            GameObject _glass = Instantiate(glass);
            _glass.name = "Glass_" + i;
            _glass.transform.SetParent(parentLocation, false);
        }
    }

    public void CompletedGlases(GameObject Glass){
        glasscompleteCounter++;
        if (glasscompleteCounter == glassCant)
        {
            currentLevel += 5;
            ResetGame();
        }
    }

    public void StartGame(){
        
        CheckGameLevel();

        glasscompleteCounter = 0;
        counter = 0;

        for (int i = 0; i < glassCant; i++)
        {
            GameObject _glass = Instantiate(glass);
            _glass.name = "Glass_" + i;
            _glass.transform.SetParent(parentLocation, false);
        }
        liquids = GameObject.FindGameObjectsWithTag("Liquid");
        Glasses = GameObject.FindGameObjectsWithTag("Glass");

        //Debug.Log("glases in game  " + Glasses.Length.ToString());
        GetLiquidInGlasses();
    }

    public void CheckGameLevel(){
        if (currentLevel<=5){glassCant = 3; }
        if (currentLevel>5){glassCant = 10; Debug.Log("estas en un nivel superior a 5 con cantidad de embases = " + glassCant);}
        if (currentLevel>10)glassCant = 7;
        if (currentLevel>20)glassCant = 8;
        if (currentLevel>30)glassCant = 9;
        if (currentLevel>40)glassCant = 10;
        if (currentLevel>50)glassCant = 11;
    }

    public void ResetGame(){
        Glasses = GameObject.FindGameObjectsWithTag("Glass");
        foreach(GameObject Glass in Glasses) GameObject.Destroy(Glass);

        liquiToAsign.Clear();
        glassCant = 0;
        System.Array.Clear(Glasses, 0, Glasses.Length);
        Glasses = GameObject.FindGameObjectsWithTag("Glass");
        Debug.Log("glases in game  " + Glasses.Length.ToString());
        //StartGame();
    }
}
