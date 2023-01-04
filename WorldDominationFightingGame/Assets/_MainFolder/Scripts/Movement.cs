using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float repelForce = 50;
    public bool canMove;
    public string horizontal;
    public string vertical;
    //public bool isPlayer1;
    Vector3 newPosition;
    Vector3 v1;
    Vector3 v2;
    public float speed = 10;
    public float rotationSpeed = 10f;
    public GameObject playerGraphics;
    //CharacterController charController;

    float x1;
    float z1;
    float x2;
    float z2;
    Movement movementScript;
    private void Start()
    {
        canMove = true;
            newPosition = transform.position;
        
        
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (canMove)
        {
            PlayerMovement();
        }
        
        
        //transform.position = newPosition;
    }

    public void PlayerMovement()
    {
        x1 = Input.GetAxis(horizontal);
        z1 = Input.GetAxis(vertical);

        //assuming we only using the single camera:
        var camera = Camera.main;

        //camera forward and right vectors:
        var forward = camera.transform.forward;
        var right = camera.transform.right;


        //camera forward and right vectors:
        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();

        var desiredMoveDirection = forward * z1 + right * x1;
        //charController.Move(desiredMoveDirection * speed * Time.deltaTime);
        transform.Translate(desiredMoveDirection * speed * Time.deltaTime);

        //newPosition.x += x1 * speed * Time.deltaTime;
        //newPosition.z += z1 * speed * Time.deltaTime;

        //transform.rotation = Quaternion.LookRotation(desiredMoveDirection);

        v1 = new Vector3(x1, 0f, z1);
        if (x1 != 0 || z1 != 0)
        {
            playerGraphics.transform.localRotation = Quaternion.RotateTowards(playerGraphics.transform.rotation, Quaternion.LookRotation(v1), rotationSpeed);
        }
    }

    private void OnTriggerStay(Collider collision)
    {
        // Check if the colliding objects have the "Player" tag
        if (collision.gameObject.CompareTag("Player"))
        {
            // Apply a force to the other collider
            Rigidbody otherRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            movementScript = collision.gameObject.GetComponent<Movement>();
            movementScript.canMove = false;
            otherRigidbody.isKinematic = false;
            Vector3 forceDirection = otherRigidbody.transform.position - transform.position;
            otherRigidbody.AddForce(forceDirection * repelForce, ForceMode.Impulse);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Rigidbody otherRigidbody = other.gameObject.GetComponent<Rigidbody>();
            otherRigidbody.isKinematic = true;
            movementScript = other.gameObject.GetComponent<Movement>();
            movementScript.canMove = true;
        }
    }
}
