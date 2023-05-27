using UnityEngine;
using UnityEngine.UI;


public class LogicaMenu : MonoBehaviour
{
    
    public Button button{get {return GetComponent<Button>();}}

    public RectTransform StartMenu;
 
    public RectTransform CargarFicheros;

    public RectTransform ChooseLevel;

    public RectTransform AlertaCrearLaberinto;

    // Start is called before the first frame update

    public void ConfiguracionMenuPlay()
    {
        StartMenu.gameObject.SetActive(false);
        ChooseLevel.gameObject.SetActive(true);
        //CargarFicheros.gameObject.SetActive(true);
    }

    public void ConfiguracionMenuCargar()
    {
        ChooseLevel.gameObject.SetActive(false);
        CargarFicheros.gameObject.SetActive(true);
    }

    public void ConfiguracionMenuVolver()
    {
        StartMenu.gameObject.SetActive(true);
        CargarFicheros.gameObject.SetActive(false);
    }

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
