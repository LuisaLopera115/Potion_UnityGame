using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drageable : MonoBehaviour
{
    public bool firstClick, SecondClick;
    
    
    void Update(){

        
    }

    private void OnMouseDown() {

        if(GameController.instance.firstGameObject == null){
            GameController.instance.firstGameObject = transform.gameObject;
            transform.GetComponent<SpriteRenderer>().color = Color.grey;

        }else if (GameController.instance.secondGameObject == null){
            GameController.instance.secondGameObject = transform.gameObject;
            transform.GetComponent<SpriteRenderer>().color = Color.cyan;
        }
    }
    
    private void OnCollisionEnter2D(Collision2D other) 
    {
        //Debug.Log("entra al condicional");
        if (true)
        {
            if (other.gameObject.tag == "Glass")
            {
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
}