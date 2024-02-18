using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anim : MonoBehaviour
{
    public GameObject coin;
    public float speed;
    public float maxHeight;
    public float minHeight;

    public void Update()
    {
        float y = Mathf.PingPong(Time.time * speed, 1) * maxHeight - minHeight;
        Vector3 pos = coin.transform.position;
        pos[1] = y;
        coin.transform.position = pos;

    }
}
