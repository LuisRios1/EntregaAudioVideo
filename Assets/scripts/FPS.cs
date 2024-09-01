using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS : MonoBehaviour
{

    public float sensX;
    public float sensY;

    public Transform orien;

    float xRotacion;
    float yRotacion; 

    public PMovemente active;


    // Start is called before the first frame update
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    private void Update()
    {
        active = FindObjectOfType<PMovemente>();
        //Debug.Log(active.active);
        if(active.active == false){
            return;
        }

        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime* sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime* sensY;

        yRotacion += mouseX;
        xRotacion -= mouseY;

        xRotacion = Mathf.Clamp(xRotacion, -90f, 90f);

        transform.rotation = Quaternion.Euler(xRotacion, yRotacion,0);
        orien.rotation = Quaternion.Euler(0, yRotacion,0);    
    }
}
