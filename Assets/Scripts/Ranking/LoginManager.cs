using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using Dan.Main;

public class LoginManager : MonoBehaviour
{
    [SerializeField]
    private InputField inputUsername;

    public LevelEntranceSO levelEntranceSO;

    public Button loginButton;

    private static LoginManager instance;

    public GameObject leaderBoardManager;

    private LeaderBoard leaderBoardManagerScript;

    private ErrorShow errorShow;

    
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start() 
    {
        errorShow = GetComponent<ErrorShow>();

        leaderBoardManagerScript = leaderBoardManager.GetComponent<LeaderBoard>();
        leaderBoardManagerScript.GetLeaderBoardNameList();
        leaderBoardManager.SetActive(false);

    }

    public void OnSubmit()
    {
        if(leaderBoardManagerScript.CheckUsernameRepeat(inputUsername.text))
            {
                errorShow.ShowError("Ya existe un usuario con ese nombre");

            }
            else
            {
                levelEntranceSO.username = inputUsername.text;
                leaderBoardManager.SetActive(true);
                this.gameObject.SetActive(false);
                Debug.Log("Login");    
            }  

    }

    public void Login()
    {
        if (inputUsername.text != "")
        {   
            OnSubmit();
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
