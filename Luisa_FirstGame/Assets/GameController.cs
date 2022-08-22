using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  UnityEngine.EventSystems;

public class GameController : MonoBehaviour
{
    public static GameController instance = null;

    public GameObject firstGameObject, secondGameObject;
    private bool firstClick, secondClick;
    void Start()
    {
        if (instance == null)
                 instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(firstGameObject == null && secondGameObject == null){
            return;
        }
        if (firstGameObject == secondGameObject)
        {
            firstGameObject = null;
            secondGameObject = null;
        }else{

            // ACTIVE MOVE ANIMATION
            if( other.transform.GetComponent<Container>().fullGlass || 
                    transform.GetComponent<Container>().emptyGlass || 
                    transform.GetComponent<Container>().potionCompleted
                ){
                    return;
                }

               //Debug.Log("vert liquid in the glass " + other.gameObject.name);
                other.transform.GetComponent<Container>().SafeLiquid(
                    transform.GetComponent<Container>().UnSafeLiquid());
                //transform.GetComponent<Container>().UnSafeLiquid();
        }

    }
}
