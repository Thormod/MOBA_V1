/******************************************************
* Author: Thormod
* Date:   18/09/2016
* playerController.cs
*******************************************************/

using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour {

    /************* Private variables *****************/
    /* Player own rogidbody */
    private Rigidbody myRigidbody;
    /* Vector for movement input */
    private Vector3 movement_input;

    private Vector3 movement_velocity;

    private Camera mainCamera;

    private bool flag = true;
    /************* /Private variables ****************/

    /************* Public variables ******************/
    /* Player movement speed */
    public float movement_speed;

    /* Player Animations set */
    Animator anim;
 
    /************* /Public variables *****************/

    // Use this for initialization
    void Start(){
        myRigidbody = GetComponent<Rigidbody>();
        mainCamera = FindObjectOfType<Camera>();

        //Animator
        anim = GetComponent<Animator>();
    }
	// Update is called once per frame
	void Update () {

        float horizontal_movement = Input.GetAxisRaw("Horizontal");
        float vertical_movement = Input.GetAxisRaw("Vertical");
    
        movement_input = new Vector3(horizontal_movement,0f, vertical_movement);

        movement_velocity = movement_input * movement_speed;

        if (horizontal_movement != 0 || vertical_movement != 0){
            transform.rotation = Quaternion.LookRotation(movement_input);
        }

        
    }

     void FixedUpdate(){
        // Player movement
        myRigidbody.velocity = movement_velocity;
 
        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        Vector3 pointToLook = Vector3.zero;
        float rayLenght;

        // Set the look location of the player
        if (groundPlane.Raycast(cameraRay, out rayLenght)) { 
            // Set a point to the camera to look at
            pointToLook = cameraRay.GetPoint(rayLenght);
            Debug.DrawLine(cameraRay.origin, pointToLook, Color.blue);

            if (Input.GetMouseButtonDown(0)){
                transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
                anim.Play("Attack", -1, 0f);
            }
        }

        if (Input.GetKeyDown("w") || Input.GetKeyDown("s") || Input.GetKeyDown("a") || Input.GetKeyDown("d")) {
            anim.SetFloat("Speed", movement_speed);
            anim.Play("Walk", -1, 0f);
        }else{
            if (myRigidbody.velocity == Vector3.zero) {
                anim.SetFloat("Speed", 0f);
            }
        }
    }
}
