using UnityEngine;

public class Container : MonoBehaviour
{
    //public Container DeleteLiquidGlassSelected;
    public SpriteRenderer[] liquidColor;
    private Color empyColr = Color.white;
    private int liquidLevelCounter;
    public bool fullGlass, emptyGlass, potionCompleted;
    private int liquidCantThisGalss;    
    GlassCreator LevelManager;

    public int glassesComplete;

    void Start()
    {
        glassesComplete = 0;
        liquidCantThisGalss = GetComponentsInChildren<Transform>().Length -1;
        liquidColor = new SpriteRenderer[liquidCantThisGalss];
        for (int i = 0; i < liquidColor.Length; i++)
            liquidColor[i]=transform.GetComponentsInChildren<SpriteRenderer>()[liquidColor.Length-i];
        

        liquidLevelCounter = 0;

        for (int i = 0; i < liquidColor.Length; i++)
        {
           if (liquidColor[i].color != empyColr)liquidLevel(true);
                 
           if (liquidLevelCounter == 0) emptyGlass = true;
        }
    }

    public void SafeLiquid(Color saveLiquid){

        if (liquidColor[liquidLevelCounter].color == Color.white)
        {
            emptyGlass = false;
            liquidLevel(true);
            CheckLevel();
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
        CheckLevel();
        return vertLiquid;
    }
    public Color LastLiquidColor( ){
        return liquidColor[liquidLevelCounter-1].color;
    }
    public void liquidLevel(bool LessMore){

        if(LessMore){
            liquidLevelCounter ++;
        }
        else{
             liquidColor[liquidLevelCounter-1].color = Color.white;
                liquidLevelCounter --;
        }  
    }

    private void CheckLevel() {
        
        if (liquidLevelCounter == liquidColor.Length)
            {
                fullGlass = true;
                CheckColors();
            }
        if (liquidLevelCounter == 0)
        {
            emptyGlass = true;
        }
    }

    private void CheckColors()
    {
        int Counter = 0;
        for (int i = 0; i < liquidColor.Length; i++)
        {
            //Debug.Log(liquidColor[i].color);
            if (liquidColor[0].color == liquidColor[i].color){
                Counter++;
                //Debug.Log("COUNTER "+ Counter.ToString()); 
            }
        }
            //Debug.Log(Counter.ToString() + liquidColor.Length.ToString());  
        if (Counter == liquidColor.Length)
        {
            potionCompleted = true;
            transform.GetComponent<SpriteRenderer>().color = Color.green;
            GlassCreator.instance.CompletedGlases(transform.gameObject);

        } 
    }

    private void OnMouseDown() {

        if(GameController.instance.firstGameObject == null){
            GameController.instance.firstGameObject = transform.gameObject;

        }else if (GameController.instance.secondGameObject == null){
            GameController.instance.secondGameObject = transform.gameObject;
        }
    }
}
