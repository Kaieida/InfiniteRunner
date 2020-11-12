using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    [SerializeField] private List<Tiles> spawnedTiles;
    [SerializeField] private List<Tiles> tilePrefabs;
    [SerializeField] private Transform _player;
    public Tiles FirstTile;

    // Start is called before the first frame update
    void Start()
    {
        spawnedTiles.Add(FirstTile);
    }

    // Update is called once per frame
    void Update()
    {
        if(_player.position.z + 500f > spawnedTiles[spawnedTiles.Count - 1].End.position.z)
        {
            SpawnTile();
        }
    }
    private void SpawnTile()
    {
        Tiles newTiles = Instantiate(tilePrefabs[Random.Range(0,tilePrefabs.Count)]);
        newTiles.transform.position = spawnedTiles[spawnedTiles.Count-1].End.position - newTiles.Begin.position;
        spawnedTiles.Add(newTiles);
    }
}
