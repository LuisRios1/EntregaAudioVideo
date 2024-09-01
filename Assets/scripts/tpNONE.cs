using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tpNONE : MonoBehaviour
{
    public Transform player, Destination;
    public GameObject playerg;
    public AudioManager AudioManager;
    public Timer Timer;

    void OnTriggerEnter(Collider other){
        AudioManager = FindObjectOfType<AudioManager>();
        Timer = FindObjectOfType<Timer>();
        if(other.CompareTag("Player")){
            Debug.Log(Destination.position);
            playerg.SetActive(false);
            player.position = Destination.position;
            playerg.SetActive(true);
            AudioManager.MasterBus.stopAllEvents(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            Timer.runningTimer = false;
            Debug.Log(player.position);
        }
    }
}
