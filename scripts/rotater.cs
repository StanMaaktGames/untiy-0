using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotater : MonoBehaviour
{
    public float x;
    public float y;
    public float z; 

    void Update()
    {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);

        transform.position = new Vector3(x, y + Mathf.Sin(Time.time) / 4, z);
    }
}
