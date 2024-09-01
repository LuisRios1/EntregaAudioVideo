using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour
{
    public Transform player;
    public GameObject playerg;
    public PMovemente PMovemente;
    public TedCollider TedCollider;

    void Update(){
        TedCollider = FindObjectOfType<TedCollider>();
        if(TedCollider.Ted == 5){
            PMovemente.GameOver();
        }
    }

}

