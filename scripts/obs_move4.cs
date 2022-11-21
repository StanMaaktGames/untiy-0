using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obs_move4 : MonoBehaviour
{
    public float startY = 5;
    public float range = 3;
    public float speed = 1;

    void Update() 
    {
        float x = transform.position.x;
        float y = Mathf.Sin(Time.time*speed) * range + startY + range;
        float z = transform.position.z;

        transform.position = new Vector3(x, y, z);
    }
}
