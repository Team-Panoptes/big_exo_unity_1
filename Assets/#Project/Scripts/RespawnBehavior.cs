using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnBehavior : MonoBehaviour
{
    public float fallingLevel = -2f;

    private Vector3 startPosition;// Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        if (transform.position.y < fallingLevel)
        {
            Respawn();
        }
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            Respawn();
        }
    }

    private void Respawn()
    {
        transform.position = startPosition;
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
            rb.velocity = Vector3.zero;
    }
}
