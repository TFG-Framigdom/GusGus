using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsController : MonoBehaviour
{
    
    public LecturaFicheroItemsSO lecturaItems;

    
    // Start is called before the first frame update
    void Start()
    {
        if(this.gameObject.tag == "ItemTiempo")
        {
            if(lecturaItems.posicionItemTiempo == Vector3.zero || lecturaItems.posicionItemTiempo == null)
                this.gameObject.SetActive(false);
            else
                this.gameObject.SetActive(true);
                this.gameObject.transform.position = lecturaItems.posicionItemTiempo;
        }
        else if(this.gameObject.tag == "ItemVida"){
            if(lecturaItems.posicionItemVida == Vector3.zero || lecturaItems.posicionItemVida == null)
                this.gameObject.SetActive(false);
            else
                this.gameObject.SetActive(true);
                this.gameObject.transform.position = lecturaItems.posicionItemVida;
        }
        
    }

}
