using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private PlayerMovement playerMovement;

    [SerializeField]
    private float hairCollected, maxHair;
    void Start()
    {
        hairCollected = 2;
        maxHair = 30;
        playerMovement.setCanMove(true);
    }

    void Update()
    {
        float currSize = hairCollected / maxHair;
        transform.localScale = Vector3.one * currSize;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("hair"))
        {
            Destroy(collision.gameObject);
            hairCollected += 1;
        }
    }
}
