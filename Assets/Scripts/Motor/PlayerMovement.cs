using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 7f;

    float horizontalInput;
    float verticalInput;

    void Update () {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate () {
        float horizontalSpeed = horizontalInput * Time.fixedDeltaTime * movementSpeed;
        float verticalSpeed = verticalInput * Time.fixedDeltaTime * movementSpeed;

        transform.Translate(new Vector3(horizontalSpeed, 0f, 0f));
        transform.Translate(new Vector3(0f, verticalSpeed, 0f));
    }
}
