using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    PhotonManager photonManager;
    public Text RenderedUserName;
    public float movementSpeed = 7f;

    private void Start() {
        photonManager = GameObject.FindObjectOfType<PhotonManager>();
    }

    float horizontalInput;
    float verticalInput;

    void Update () {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        RenderedUserName.text = photonManager.GetComponent<ChatGui>().UserName;
    }

    void FixedUpdate () {
        float horizontalSpeed = horizontalInput * Time.fixedDeltaTime * movementSpeed;
        float verticalSpeed = verticalInput * Time.fixedDeltaTime * movementSpeed;

        transform.Translate(new Vector3(horizontalSpeed, 0f, 0f));
        transform.Translate(new Vector3(0f, verticalSpeed, 0f));
    }
}
