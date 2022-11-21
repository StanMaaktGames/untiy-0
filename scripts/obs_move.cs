using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obs_move : MonoBehaviour
{
    public float startZ = 5;
    public float range = 3;
    public float speed = 1;

    void Update() 
    {
        float x = transform.position.x;
        float y = transform.position.y;
        float z = Mathf.Sin(Time.time*speed) * range + startZ + range;

        transform.position = new Vector3(x, y, z);
    }

}
