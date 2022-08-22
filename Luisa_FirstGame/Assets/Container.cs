using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container : MonoBehaviour
{
    //public Container DeleteLiquidGlassSelected;
    public SpriteRenderer[] liquidColor  = new SpriteRenderer[3];
    private Color empyColr = Color.white;
    private int liquidLevelCounter;
    public bool fullGlass, emptyGlass, potionCompleted;
    
    void Start()
    {
        liquidLevelCounter = 0;
        for (int i = 0; i < liquidColor.Length; i++)
        {
           if (liquidColor[i].color != empyColr){
                 liquidLevel(true);
           }
        }
    }

    void Update()
    {
        
    }

    public void SafeLiquid(Color saveLiquid){

        if (liquidColor[liquidLevelCounter].color == Color.white)
        {
            emptyGlass = false;
            liquidLevel(true);
            liquidColor[liquidLevelCounter-1].color = saveLiquid;

            if (liquidLevelCounter == liquidColor.Length)
            {
                //Debug.Log(transform.gameObject.name +"  THIS GLASS IS FULL");
                fullGlass = true;
                CheckColors();
            }
        }
    }

    public Color UnSafeLiquid(){
        //Debug.Log(transform.gameObject.name + "     "+liquidLevelCounter.ToString());
        Color vertLiquid = liquidColor[liquidLevelCounter-1].color;
        fullGlass=false;
        liquidLevel(false);
        return vertLiquid;
    }
    
    public void liquidLevel(bool LessMore){
        if(LessMore){
            liquidLevelCounter ++;
        }
        else{
             liquidColor[liquidLevelCounter-1].color = Color.white;
                liquidLevelCounter --;
            
        }
        
        if (liquidLevelCounter == 0)
        {
            //Debug.Log(transform.gameObject.name +"  THIS GLASS IS EMPTY");
            emptyGlass = true;
        }

        // Debug.Log("the liquid level of " + transform.gameObject.name + " is "+
        //     liquidLevelCounter.ToString());
    }

    private void CheckColors()
    {
        int Counter = 0;
        for (int i = 0; i < liquidColor.Length; i++)
        {
            //Debug.Log(liquidColor[i].color);
            if (liquidColor[0].color == liquidColor[i].color){
                Counter++;
                Debug.Log("COUNTER "+ Counter.ToString()); 
            }
        }
            //Debug.Log(Counter.ToString() + liquidColor.Length.ToString());  
        if (Counter == liquidColor.Length)
        {
            potionCompleted = true;
            transform.GetComponent<SpriteRenderer>().color = Color.green;
        }
            
    }
}
