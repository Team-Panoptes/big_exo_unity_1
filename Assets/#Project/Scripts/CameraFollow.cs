using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerControl))]
public class CameraFollow : MonoBehaviour
{
    private Transform cameraTransform;
    private float speed;
    public float decalZ = -6f;
    // Start is called before the first frame update

    void Start()
    {
        speed = GetComponent<PlayerControl>().speed;
        cameraTransform = Camera.main.transform;
        Vector3 position = cameraTransform.position;
        position.z = transform.position.z + decalZ;
        cameraTransform.position = position;
    }

    void Update()
    {
        Vector3 position = cameraTransform.position;
        position.z = transform.position.z + decalZ;
        //cameraTransform.position = position;
        Vector3 direction = (position - cameraTransform.position).normalized;
        cameraTransform.position += direction * speed * Time.deltaTime;
    }
}
