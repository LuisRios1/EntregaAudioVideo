using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PMovemente : MonoBehaviour
{
    [Header("Movimiento")]
    public float moveSpeed;
    public float groundDrag;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    public GameOverScreen GameOverScreen;
    public Transform orientation;
    public Epilogue Epilogue;

    float horizontalInput;
    float verticalInput;

    public int sanity = 3;
    public bool active = true;
    public bool isMoving = false;

    Vector3 moveDirection;

    Rigidbody rb;


    // Update is called once per frame
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void Update()
    {
        if(!active){
            return;
        }
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 1f + 0.5f, whatIsGround);
        MyInput();
        SpeedControl();
        MovementeW();

        if(grounded){
            rb.drag = groundDrag;
        }
        else{
            rb.drag = 0;
        }
  
    }

    private void FixedUpdate(){
        if(!active){
            return;
        }
        MovePlayer();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        rb.AddForce(moveDirection.normalized* moveSpeed * 10f, ForceMode.Force);
        //Debug.Log(moveDirection);
    }

    private void SpeedControl(){

        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if(flatVel.magnitude > moveSpeed){
            Vector3 limitedVel =flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    private void MovementeW(){
        if(moveDirection != Vector3.zero){
            isMoving = true;
        }
        else{
            isMoving = false;
        }
            //Debug.Log(isMoving);
    }
        
    /*public void Sanity(){
        sanity--;
        if(sanity <= 0){
            GameOver();
        }
    }*/

    public void FinalCito(){
        active = false;
        rb.velocity = Vector3.zero;
        Epilogue.Fuchi();
    }
    
    public void GameOver(){
        active = false;
        rb.velocity = Vector3.zero;
        GameOverScreen.F();
    }



}
