using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LogicaMenu : MonoBehaviour
{
    
    public Button button{get {return GetComponent<Button>();}}

    public RectTransform StartMenu;
 
    public RectTransform CargarFicheros;

    // Start is called before the first frame update
    void Start()
    {
        if(button.name == "ButtonPlay"){
            button.onClick.AddListener(ConfiguracionMenuPlay);
        }
        else if(button.name == "ButtonVolver")
        {
            button.onClick.AddListener(ConfiguracionMenuVolver);
        }
        
    }

    public void ConfiguracionMenuPlay()
    {
        StartMenu.gameObject.SetActive(false);
        CargarFicheros.gameObject.SetActive(true);

    }

    public void ConfiguracionMenuVolver()
    {
        StartMenu.gameObject.SetActive(true);
        CargarFicheros.gameObject.SetActive(false);
    }

}
