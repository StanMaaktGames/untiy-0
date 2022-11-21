using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spinningObstacle : MonoBehaviour
{
public float speed = 30;

    void Update()
    {
        transform.Rotate(new Vector3(speed, 0.0f, 0.0f) * Time.deltaTime);
    }
}
