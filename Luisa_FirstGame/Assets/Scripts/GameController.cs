using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance = null;

    public GameObject firstGameObject, secondGameObject;
    public Text WarnigComents;

    private float timeToAppearComments = 1f;
    private float timeWhenDisappearComments;

    void Start()
    {
        if (instance == null)
                 instance = this;

        WarnigComents.text = "";
        ResetFirstSecondObject();
    }

    // Update is called once per frame
    void Update()
    {
        if (WarnigComents.enabled && (Time.time >= timeWhenDisappearComments))
        {
            WarnigComents.enabled = false;
        }

        if(firstGameObject == null && secondGameObject == null){
            return;

        }else if(firstGameObject != null && secondGameObject == null){
            return;
        }else if (firstGameObject == secondGameObject)
        {
            ResetFirstSecondObject();
            return;

        }else{
            // ACTIVE MOVE ANIMATION
            if(secondGameObject.transform.GetComponent<Container>().fullGlass){
                WarningComment("FullGlass");
                ResetFirstSecondObject();
                return;
            }else if(firstGameObject.transform.GetComponent<Container>().emptyGlass){
                WarningComment("EmtyGlass");
                ResetFirstSecondObject();
                return;
            }else if (firstGameObject.transform.GetComponent<Container>().potionCompleted ){
                WarningComment("CompleteGlass");
                ResetFirstSecondObject();
                return;
            }   
                if (secondGameObject.transform.GetComponent<Container>().emptyGlass)
                {
                    secondGameObject.transform.GetComponent<Container>().SafeLiquid(
                    firstGameObject.transform.GetComponent<Container>().UnSafeLiquid());

                    ResetFirstSecondObject();
                    return;
                }

               //Debug.Log("vert liquid in the glass " + secondGameObject.gameObject.name);
                if (firstGameObject.transform.GetComponent<Container>().LastLiquidColor() == secondGameObject.transform.GetComponent<Container>().LastLiquidColor())
                {
                    secondGameObject.transform.GetComponent<Container>().SafeLiquid(
                    firstGameObject.transform.GetComponent<Container>().UnSafeLiquid());

                    ResetFirstSecondObject();
                }else{
                    WarningComment("NotSameColor");
                    ResetFirstSecondObject();
                }
                
        }
    }
    
    private void ResetFirstSecondObject(){
        firstGameObject = null;
        secondGameObject = null;
    }
    //Call to enable the text, which also sets the timer
    public void EnableText()
    {
        WarnigComents.enabled = true;
        timeWhenDisappearComments = Time.time + timeToAppearComments;
    }

    public void WarningComment(string typeOfComment){

        EnableText();

        switch (typeOfComment)
        {
            case "FullGlass":
                 WarnigComents.text = "NO PUEDES VERTIR LIQUIDO EN UN RECIPINTE QUE YA ESTA LLENO";
            break;

            case "EmtyGlass":
                 WarnigComents.text = "EL RECIPIENTE ESTA VACIO, NO PUEDES VERTIR NADA DE EL";
            break;

            case "CompleteGlass":
                 WarnigComents.text = "MUY BIEN. HAZ COMPLETADO UNA POSION";
            break;

            case "NotSameColor":
                 WarnigComents.text = "deben tener el mismo color";
            break;

            default: 
            break;
        }
    }
}
