using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassCreator : MonoBehaviour
{
    public static GlassCreator instance;

    [SerializeField]
    private Transform parentLocation;
    [SerializeField]
    private GameObject glass;


    GameObject[] liquids;
    GameObject[] Galsses;


    [SerializeField]
    private int glassCant;
    [SerializeField]
    private Color[] liquidStyles;
    private List<Color> liquiToAsign;
    private int counter, glasscompleteCounter;

    // Start is called before the first frame update
    private void Awake() 
    {
        
        if(instance == null)
        {
            instance = this;
        }
        

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
        Debug.Log("MELOOOO");
        glasscompleteCounter++;
        if (glasscompleteCounter == glassCant)
        {
            Debug.Log("nivel completado");
        }
    }
}
