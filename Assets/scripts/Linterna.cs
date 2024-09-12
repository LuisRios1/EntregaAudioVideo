using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Linterna : MonoBehaviour
{
    public Light LuzLinterna;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(LuzLinterna.enabled == false)
        {
            if(Input.GetKeyDown(KeyCode.F))
            {
                LuzLinterna.enabled = true;
            }
        }

        else{
            if(Input.GetKeyDown(KeyCode.F))
            {
                LuzLinterna.enabled = false;
            }
        }
    }
}
