using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginManager : MonoBehaviour
{
    [SerializeField]
    private InputField inputUsername;

    public Canvas canvasLogin;

    public LevelEntranceSO levelEntranceSO;

    public Button loginButton;

    private int loginOneTime;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        canvasLogin.gameObject.SetActive(true);
    }

    public void OnSubmit()
    {
        levelEntranceSO.username = inputUsername.text;

    }

    public void Login()
    {
        if (inputUsername.text != "")
        {
            OnSubmit();
            canvasLogin.gameObject.SetActive(false);
            this.gameObject.SetActive(false);
            Debug.Log("Login");
        }
    
    }

    void Update() 
    {
        if (inputUsername.text == "")
        {
            loginButton.interactable = false;
        }
        else
        {
            loginButton.interactable = true;
        }
        
    }


}
