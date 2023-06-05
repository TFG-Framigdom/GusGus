using UnityEngine;
using UnityEngine.UI;


public class LogicaMenu : MonoBehaviour
{
    
    public Button button{get {return GetComponent<Button>();}}

    public RectTransform ChooseLevel;

    public RectTransform AlertaCrearLaberinto;

    public void ConfiguracionMenuExit()
    {

        Application.Quit();
    }

    public void ConfiguracionAlertaCrearLaberinto()
    {
        ChooseLevel.gameObject.SetActive(false);
        AlertaCrearLaberinto.gameObject.SetActive(true);
        
    }

}
