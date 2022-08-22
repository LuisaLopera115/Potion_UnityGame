using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance = null;

    public GameObject firstGameObject, secondGameObject;
    public Text WarnigComents;

    void Start()
    {
        if (instance == null)
                 instance = this;

        WarnigComents.text = "";
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

    public void WarningComment(string typeOfComment){

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
        }
       
    }
}
