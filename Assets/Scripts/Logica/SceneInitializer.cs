using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SceneInitializer : MonoBehaviour
{
    [Header("Dependencies")]
    public SceneSO[] scenes;

    [Header("Ready")]
    public UnityEvent onDependenciesLoaded;

    void Start(){
        StartCoroutine(LoadScenesDependencies());
    }

    private IEnumerator LoadScenesDependencies(){
        for (int i = 0; i < scenes.Length; i++)
        {
            SceneSO scene = scenes[i];
            if(SceneManager.GetSceneByName(scene.sceneName).isLoaded == false){
                var asyncOperation = SceneManager.LoadSceneAsync(scene.sceneName, LoadSceneMode.Additive);
                while (!asyncOperation.isDone)
                {
                    yield return null;
                }
            }
        }
        if(onDependenciesLoaded != null){
            onDependenciesLoaded.Invoke();
        }
    }


}
