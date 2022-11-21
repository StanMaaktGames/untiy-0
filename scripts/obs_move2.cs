using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obs_move2 : MonoBehaviour
{
    public float startX = 5;
    public float range = 3;
    public float speed = 1;

    void Update() 
    {
        float x = Mathf.Sin(Time.time*speed) * range + startX + range;
        float y = transform.position.y;
        float z = transform.position.z;

        transform.position = new Vector3(x, y, z);
    }
}