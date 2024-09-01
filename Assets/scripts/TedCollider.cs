using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TedCollider : MonoBehaviour
{  
    public int Ted = 0;
    public TextMeshProUGUI tedText;
    public Timer Timer;

    private void OnTriggerEnter(Collider other){
        
        if(other.transform.tag == "Ted")
        {   
            //Puntuacion Teddy
            Ted++;
            tedText.text = Ted.ToString();
            //Tiempo Extra por Teddy
            Timer = FindObjectOfType<Timer>();
            Timer.currentTime += 30;
            Destroy(other.gameObject);
        }
    }
}
