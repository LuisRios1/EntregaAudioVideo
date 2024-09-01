using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class AudioManager : MonoBehaviour
{
    [SerializeField] EventReference FootstepEvent;
    [SerializeField] EventReference BGTheme;
    [SerializeField] EventReference BGThemeIn;
    [SerializeField] EventReference BGThemeIn2;
    [SerializeField] EventReference BGThemeIn3;
    [SerializeField] float rate;
    [SerializeField] GameObject player;

    public FMOD.Studio.Bus MasterBus;
    public PMovemente PMovemente;

    float time;

    private void Start(){
        MasterBus = RuntimeManager.GetBus("Bus:/");
        //Debug.Log(MasterBus.ToString());
        PlayBGTheme();
    }

    public void PlayBGTheme(){
        RuntimeManager.PlayOneShotAttached(BGTheme, player);
    }

    public void PlayBGThemeIn(){
        RuntimeManager.PlayOneShotAttached(BGThemeIn, player);
    }

    public void PlayBGThemeIn2(){
        RuntimeManager.PlayOneShotAttached(BGThemeIn2, player);
    }

    public void PlayBGThemeIn3(){
        RuntimeManager.PlayOneShotAttached(BGThemeIn3, player);
    }

    public void PlayFootstep()
    {
        RuntimeManager.PlayOneShotAttached(FootstepEvent, player);
    }

    void Update(){
        time += Time.deltaTime;
        if(PMovemente.isMoving){
            if(time >= rate){
                PlayFootstep();
                time = 0;
            }
        }
    }
}
