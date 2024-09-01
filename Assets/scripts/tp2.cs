using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tp2 : MonoBehaviour
{
    public Transform player, Destination;
    public GameObject playerg;
    public AudioManager AudioManager;

    void OnTriggerEnter(Collider other){
        AudioManager = FindObjectOfType<AudioManager>();
        if(other.CompareTag("Player")){
            Debug.Log(Destination.position);
            playerg.SetActive(false);
            player.position = Destination.position;
            playerg.SetActive(true);
            AudioManager.MasterBus.stopAllEvents(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            AudioManager.PlayBGThemeIn2();
            Debug.Log(player.position);
        }
    }
}
