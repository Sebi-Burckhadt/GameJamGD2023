using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public bool isPlayer1;
    Vector3 newPosition;
    Vector3 v1;
    Vector3 v2;
    public float speed = 10;
    public float rotationSpeed = 10f;
    public GameObject playerGraphics;


    float x1;
    float z1;
    float x2;
    float z2;
    private void Start()
    {
        newPosition = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isPlayer1)
        {
            PlayerOneMovement();
        }
        else
        {
            PlayerTwoMovement();
            
        }
        transform.position = newPosition;
    }

    public void PlayerOneMovement()
    {
        x1 = Input.GetAxis("Horizontal1");
        z1 = Input.GetAxis("Vertical1");
        newPosition.x += x1 * speed * Time.deltaTime;
        newPosition.z += z1 * speed * Time.deltaTime;
        v1 = new Vector3(x1, 0f, z1);
        if (x1 != 0 || z1 != 0)
        {
            playerGraphics.transform.localRotation = Quaternion.RotateTowards(playerGraphics.transform.rotation, Quaternion.LookRotation(v1), rotationSpeed);
        }
    }

    public void PlayerTwoMovement()
    {
        x2 = Input.GetAxis("Horizontal2");
        z2 = Input.GetAxis("Vertical2");
        newPosition.x += x2 * speed * Time.deltaTime;
        newPosition.z += z2 * speed * Time.deltaTime;

        v2 = new Vector3(x2, 0f, z2);
        if (x2 != 0 || z2 != 0)
        {
            playerGraphics.transform.localRotation = Quaternion.RotateTowards(playerGraphics.transform.rotation, Quaternion.LookRotation(v2), rotationSpeed);
        }
    }

}
