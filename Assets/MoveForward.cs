using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed = 1f;

    void Update()
    {
        transform.position += -transform.right * Time.deltaTime * speed;
    }
}
