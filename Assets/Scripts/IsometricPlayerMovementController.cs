using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsometricPlayerMovementController : MonoBehaviour
{
    public float movementSpeed = 1f;

    private float horizontalInput;
    private float verticalInput;

    PhotonView photonView;
    IsometricCharacterRenderer isoRenderer;
    Rigidbody2D rbody;

    private void Start()
    {
        photonView = GetComponent<PhotonView>();
        rbody = GetComponent<Rigidbody2D>();
        isoRenderer = GetComponentInChildren<IsometricCharacterRenderer>();
    }

    void FixedUpdate() {
        if (photonView.IsMine) {
            horizontalInput = Input.GetAxisRaw("Horizontal");
            verticalInput = Input.GetAxisRaw("Vertical");

            Vector2 currentPos = rbody.position;
            Vector2 inputVector = new Vector2(horizontalInput, verticalInput);
            inputVector = Vector2.ClampMagnitude(inputVector, 1);
            Vector2 movement = inputVector * movementSpeed;
            Vector2 newPos = currentPos + movement * Time.fixedDeltaTime;

            photonView.RPC("SetDirectionFromIsoRenderer", RpcTarget.All, movement);
            //isoRenderer.SetDirection(movement);

            rbody.MovePosition(newPos);
        }
    }

    [PunRPC]
    void SetDirectionFromIsoRenderer(Vector2 direction) {
        isoRenderer.SetDirection(direction);
    }
}
