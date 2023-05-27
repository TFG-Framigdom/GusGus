using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnlaceDirecto : MonoBehaviour
{
    private string url; // La URL de la página web que deseas abrir

    private void Start()
    {
        url = "https://github.com/TFG-Framigdom/GusGus";
        // Abre la página web al hacer clic en el objeto al que se asocia este script
        UnityEngine.EventSystems.EventTrigger trigger = gameObject.AddComponent<UnityEngine.EventSystems.EventTrigger>();
        UnityEngine.EventSystems.EventTrigger.Entry entry = new UnityEngine.EventSystems.EventTrigger.Entry();
        entry.eventID = UnityEngine.EventSystems.EventTriggerType.PointerClick;
        entry.callback.AddListener((data) => { Application.OpenURL(url); });
        trigger.triggers.Add(entry);
    }
}
