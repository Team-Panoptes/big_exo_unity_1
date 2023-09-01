using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerControl))]
public class CameraFollow : MonoBehaviour
{
    private Transform cameraTransform;
    private PlayerControl playerControl;
    public float decalZ = -6f;

    [Range(0, 1f)]
    public float zThreshold = 0.5f;
    // Start is called before the first frame update

    void Start()
    {
        playerControl = GetComponent<PlayerControl>();
        cameraTransform = Camera.main.transform;
        Vector3 position = cameraTransform.position;
        position.z = transform.position.z + decalZ;
        cameraTransform.position = position;
    }

    void Update()
    {

        Vector3 position = cameraTransform.position;
        position.z = transform.position.z + decalZ;

        Vector3 direction = (position - cameraTransform.position).normalized;
        bool playerIsActive = Mathf.Abs(position.z - cameraTransform.transform.position.z) <= zThreshold;
        float speed = (playerIsActive ? playerControl.speed : playerControl.speed * 10);
        cameraTransform.position += direction * speed * Time.deltaTime;
        playerControl.enabled = playerIsActive;
    }
}
