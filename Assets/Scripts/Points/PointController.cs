using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PointController : MonoBehaviour
{

    public int puntos;
    public Text puntosText;

    private string puntosPrefs = "Puntos";

    float tiempoTranscurrido = 0f;

    public RectTransform finalizarPartida;

    bool puntosActivos = true;

    void Awake() {
        CargarPuntos();
    }
    
    void Update() {
        tiempoTranscurrido += Time.deltaTime; 
        if(finalizarPartida.gameObject.activeSelf == false && puntosActivos == true){
            if (tiempoTranscurrido >= 1f) 
            {
                tiempoTranscurrido = 0f; 
                puntos += 1; 
            }
        }
       
        puntosText.text = "Puntos: " + puntos;   
        
    }

    void OnDestroy() {
        GuardarPuntos();
    }

    public void SumarPuntos(int puntosASumar) {
        puntos += puntosASumar;
    }

    public void GuardarPuntos() {
        if(SceneManager.GetActiveScene().name == "GamePlayLevel3Finish")
        {
            ResetPoint();
        }
        else
        {
            PlayerPrefs.SetInt(puntosPrefs, puntos);
        }
        
    }	

    private void CargarPuntos(){
        if(SceneManager.GetActiveScene().name == "GamePlay")
        {
            ResetPoint();
            puntos = PlayerPrefs.GetInt(puntosPrefs, 0);

        }
        else
        {
            puntos = PlayerPrefs.GetInt(puntosPrefs, 0);
        }
        
    }

    public void ResetPoint(){
        puntos = 0;
        PlayerPrefs.SetInt(puntosPrefs, puntos);
    }
    
    public void StopPoint(){
        puntosActivos = false;
    }

    public void ResumePoint(){
        puntosActivos = true;
    }

    
}
