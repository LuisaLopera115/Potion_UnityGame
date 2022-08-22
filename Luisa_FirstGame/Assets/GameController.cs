using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  UnityEngine.EventSystems;

public class GameController : MonoBehaviour
{
    public static GameController instance = null;

    public GameObject firstGameObject, secondGameObject;
    private bool firstClick, secondClick, actOnce;

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

        }else if(firstGameObject != null && secondGameObject == null){
            return;
        }else if (firstGameObject == secondGameObject)
        {
            //firstGameObject.transform.GetComponent<SpriteRenderer>().color = Color.white;
            //secondGameObject.transform.GetComponent<SpriteRenderer>().color = Color.white;
            firstGameObject = null;
            secondGameObject = null;
            return;

        }else{

            // ACTIVE MOVE ANIMATION
            if(secondGameObject.transform.GetComponent<Container>().fullGlass || 
                    firstGameObject.transform.GetComponent<Container>().emptyGlass || 
                    firstGameObject.transform.GetComponent<Container>().potionCompleted 
                ){
                    firstGameObject = null;
                    secondGameObject = null;
                    return;
                }

               Debug.Log("vert liquid in the glass " + secondGameObject.gameObject.name);

                secondGameObject.transform.GetComponent<Container>().SafeLiquid(
                    firstGameObject.transform.GetComponent<Container>().UnSafeLiquid());

                firstGameObject = null;
                secondGameObject = null;
        }

    }
}
