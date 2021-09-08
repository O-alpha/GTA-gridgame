using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridHolder : MonoBehaviour
{
    [SerializeField] private  int row = 5, col = 5;
    [SerializeField] Tiles tileprefab;
    [SerializeField] private Transform cam;
    private Dictionary<Vector2, Tiles> _tiles;
    // Start is called before the first frame update
    void Start()
    {
        GenerateGrid();
    }

    private void GenerateGrid()
    {
        _tiles = new Dictionary<Vector2, Tiles>();
        for(int i=0; i<row; i++)
        {
            for(int j=0; j<col; j++)
            {
                var Spawntile = Instantiate(tileprefab, new Vector3(i,j), Quaternion.identity);
                Spawntile.name = $"Tiles {i} {j}";

                var isOffset = (i%2 == 0 && j%2 != 0) || (i%2 != 0 && j%2 == 0);
                //Debug.Log(isOffset);
                Spawntile.Init(isOffset);

                _tiles[new Vector2(i, j)] = Spawntile;
            }
        }


        cam.transform.position = new Vector3((float)row/2 - 0.5f, (float)col/2 - 0.5f, -10); //+ve sign will lead to game object 
                                                                        //not being viewed  in game view.
    }

    public Tiles GetTileAtPosition(Vector2 pos) {
        if (_tiles.TryGetValue(pos, out var tile)) return tile;
        return null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
