using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalBehavior : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerControl playerControl = other.GetComponent<PlayerControl>();
            if (playerControl != null)
            {
                playerControl.enabled = false;
            }
            CameraFollow cameraFollow = other.GetComponent<CameraFollow>();
            if (cameraFollow != null)
            {
                cameraFollow.enabled = false;
            }
        }
    }
}
