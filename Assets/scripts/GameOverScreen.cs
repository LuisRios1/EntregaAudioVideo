using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    public TextMeshProUGUI timeLeft;

    public TedCollider Ted;

    public AudioManager AudioManager;

    public GameObject Canva;

    public GameObject Canvasu;

    public Timer currentTime;

    public void F(){
        Ted = FindObjectOfType<TedCollider>();
        AudioManager = FindObjectOfType<AudioManager>();
        scoreText.text = Ted.Ted.ToString();
        gameObject.SetActive(true);
        Canva.SetActive(false);
        Canvasu.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        AudioManager.MasterBus.stopAllEvents(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        Cursor.visible = true;
    }

    public void RestarBut(){
        SceneManager.LoadScene("Level");
    }

    public void MainMenu(){
        SceneManager.LoadScene("MainMenu");
    }
}

