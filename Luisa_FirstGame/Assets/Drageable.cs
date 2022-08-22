using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drageable : MonoBehaviour
{
    private bool drag;
    private Vector2 offset;
    private Vector2 initPos;
    
    private void Awake() {
        initPos = transform.position;
    }
    
    void Update(){

        
    }
    private void OnMouseDown() {
    }
    private   void OnMouseUp() {
    }

    void GetmousePos(){
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        //Debug.Log("entra al condicional");
        if (drag && !Vector2.Equals(transform.position, initPos))
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