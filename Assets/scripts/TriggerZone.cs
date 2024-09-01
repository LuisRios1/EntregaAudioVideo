using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZone : MonoBehaviour
{
    public Timer Timer;
    public Trauma Trauma;

    private void OnTriggerEnter(Collider other){
        
        if(other.transform.tag == "TriggerPencil")
        {   
            //Tiempo Negativo por Trauma
            Timer = FindObjectOfType<Timer>();
            Trauma = FindObjectOfType<Trauma>();
            Timer.currentTime -= 60;
            Trauma.HUDTrauma();
            Destroy(other.gameObject);
        }
    }
}
