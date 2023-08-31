using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCreator : MonoBehaviour
{
    public int startTiles = 5;

    private Vector3 nextPosition = Vector3.zero;
    private List<GameObject> tiles = new();
    public GameObject[] tilePrebabs;
    // Start is called before the first frame update
    void Start()
    {
        for (int n = 0; n < startTiles; n++)
        {
            SpawnTileAtNextPosition();
        }
    }

    private void SpawnTileAtNextPosition()
    {
        SpawnTileAtPosition(nextPosition);
    }
    private void SpawnTileAtPosition(Vector3 position)
    {
        GameObject tile = ChooseOneTile();
        tile = Instantiate(tile, position, Quaternion.identity);
        tile.transform.SetParent(transform);
        tile.GetComponent<GroundTile>().creator = this;
        nextPosition = position + Vector3.forward * 10f * tile.transform.localScale.z;
        tiles.Add(tile);
    }

    private GameObject ChooseOneTile()
    {
        int index = Random.Range(0, tilePrebabs.Length);
        return tilePrebabs[index];
    }

    public void PlayerLeavingTile(GroundTile tile)
    {
        tile.FlightToPosition(nextPosition);
        nextPosition += Vector3.forward * 10f * tile.transform.localScale.z;

    }

}
