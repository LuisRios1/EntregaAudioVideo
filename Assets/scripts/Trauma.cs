using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Trauma : MonoBehaviour
{
    public float intensity = 0;
    PostProcessVolume _volume;
    Vignette _vignette;


    void Start(){
        _volume = GetComponent<PostProcessVolume>();
        _volume.profile.TryGetSettings<Vignette>(out _vignette);

        if(!_vignette){
            print("error, vignete empty");
        }
        else{
            _vignette.enabled.Override(false);
        }
    }

    public void HUDTrauma(){
        StartCoroutine(TakenTrauma());
    }

    public IEnumerator TakenTrauma(){
        intensity = 0.45f;
        _vignette.enabled.Override(true);
        _vignette.intensity.Override(0.45f);

        yield return new WaitForSeconds(0.4f);

        while(intensity > 0){
            intensity -= 0.01f;

            if(intensity < 0) intensity = 0;

            _vignette.intensity.Override(intensity);

            yield return new WaitForSeconds(0.4f);
        }

        _vignette.enabled.Override(false);
        yield break;
    }
}
