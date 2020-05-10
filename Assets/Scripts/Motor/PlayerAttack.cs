using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerAttack : MonoBehaviourPun
{
    public float fireRate = 0.5f;
    public float cooldown = 0;
    public float damage = 25f;

    Transform followMousePosition;

    private void Awake() {
        followMousePosition = GetComponentInChildren<FollowMousePosition>().transform;
    }

    void Update()
    {
        cooldown -= Time.deltaTime;

        if (Input.GetButtonDown("Fire1")) {
            Shoot();
        }
    }

    void Shoot() {
        Debug.Log("Shooting");

        if (cooldown > 0)
            return;

        Vector2 inicioDisparo = new Vector2(transform.position.x, transform.position.y);
        Quaternion rotacionDisparo = followMousePosition.rotation;

        PhotonNetwork.Instantiate("Bullet", inicioDisparo, rotacionDisparo);

        cooldown = fireRate;
    }
}
