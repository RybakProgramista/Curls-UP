using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform playerT;
    private float offset;
    void Start()
    {
        offset = Mathf.Abs(transform.position.x - playerT.position.x);    
    }
    void Update()
    {
        transform.position = new Vector3(playerT.position.x + offset, 0f, -10f);    
    }
}
