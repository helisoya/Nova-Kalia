using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldMapCamera : MonoBehaviour
{
    [SerializeField] private Transform player;

    [SerializeField] private float x;
    [SerializeField] private float y;
    [SerializeField] private float z;

    void Update()
    {
        transform.position = player.position + new Vector3(x,y,z);
    }
}
