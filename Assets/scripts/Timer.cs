using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public bool runningTimer;
    public float currentTime;
    public float maxTime;
    
    
    public Image timerBar;
    public PMovemente PMovemente;
    public TextMeshProUGUI timerText;
    public TedCollider TedCollider;


    void Start(){
        currentTime = maxTime;
        runningTimer = true;
    }

    void Update(){
        if(runningTimer)
        {
            currentTime -=Time.deltaTime;
            timerText.text = System.Math.Round(currentTime,0).ToString();
            timerBar.fillAmount = currentTime/maxTime;
            PMovemente = FindObjectOfType<PMovemente>();
            //Debug.Log(currentTime);
            if(currentTime <= 0){
                runningTimer = false;
                PMovemente.GameOver();
                Debug.Log("Gameover");
            }
        }
        else{
            PMovemente = FindObjectOfType<PMovemente>();
            TedCollider = FindObjectOfType<TedCollider>();
            if(TedCollider.Ted == 5){
                PMovemente.FinalCito();
            }
        }

    }

    

}
