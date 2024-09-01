using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class Epilogue : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    
    public TextMeshProUGUI timeLeft;

    public TedCollider Ted;

    public AudioManager AudioManager;

    public GameObject Canva;

    public Timer Timer;

    public void Fuchi(){
        Ted = FindObjectOfType<TedCollider>();
        Timer = FindObjectOfType<Timer>();
        AudioManager = FindObjectOfType<AudioManager>();
        timeLeft.text = System.Math.Round(Timer.currentTime,0).ToString();
        scoreText.text = Ted.Ted.ToString();
        gameObject.SetActive(true);
        Canva.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        AudioManager.MasterBus.stopAllEvents(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        Cursor.visible = true;
    }

    public void Quit(){
        Application.Quit();
    }

    public void MainMenu(){
        SceneManager.LoadScene("MainMenu");
    }
}
