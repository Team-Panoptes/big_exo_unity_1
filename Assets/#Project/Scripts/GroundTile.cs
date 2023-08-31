using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    [HideInInspector]
    public GroundCreator creator;
    public float decalWhenFlight = -3f;
    public float speed = 15f;
    // Start is called before the first frame update
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            creator.PlayerLeavingTile(this);
        }
    }

    public void FlightToPosition(Vector3 position)
    {
        StartCoroutine(_FlightToPosition(position));
    }

    private IEnumerator _FlightToPosition(Vector3 position)
    {
        transform.position += Vector3.up * decalWhenFlight;
        Vector3 start = transform.position;

        float distance = Vector3.Distance(position, start);
        float time = distance / speed;
        float t = 0;
        while (t <= time)
        {
            t += Time.deltaTime;
            transform.position = Vector3.Lerp(start, position, t / time);

            yield return null;
        }
    }
}
