using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    public int speed;

    public int sensibility;

    public Rigidbody rb;
    public Transform groundDetector;

    public Transform cam;
    public Transform body;
    private float xrot = 0;

    public float maxXRot;

    public float normalSize;
    public float crouchSize;

    private bool isCrouched = false;


    private int currentSpeed;
   void Start(){
       Cursor.lockState = CursorLockMode.Confined;
   }

    public void Teleport(Vector3 position, Vector3 eulerAngles){
        transform.position = position;
        transform.eulerAngles = eulerAngles;
    }

    bool IsGrounded() {
    return Physics.Raycast(groundDetector.position, -Vector3.up,0.5f);
    }
   
    void Update ()
    {
        if(Time.timeScale == 0) return;

        currentSpeed = speed + (Input.GetKey(KeyCode.LeftShift) ? 5 : 0);
        Vector3 PlayerMovement = body.TransformDirection(new Vector3(Input.GetAxis("Horizontal"),0f,Input.GetAxis("Vertical"))) * currentSpeed;
        Vector2 PlayerCamMovement = new Vector2(Input.GetAxis("Mouse X"),Input.GetAxis("Mouse Y"));
        rb.velocity = new Vector3(PlayerMovement.x,rb.velocity.y,PlayerMovement.z);

        transform.Rotate(0f,PlayerCamMovement.x * sensibility,0f);
        xrot = Mathf.Clamp(xrot-PlayerCamMovement.y*sensibility,-maxXRot,maxXRot);
        cam.transform.localRotation = Quaternion.Euler(xrot,0f,0f);


        if(IsGrounded() &&Input.GetKeyDown(KeyCode.Space)){
            rb.AddForce(transform.up* (isCrouched ? 150 : 300) );
        }

        if(Input.GetKeyDown(KeyCode.LeftControl)){
            isCrouched = !isCrouched;
            body.localScale = new Vector3(body.localScale.x,isCrouched ? crouchSize : normalSize,body.localScale.z);
        }
    }

}
