using System.Collections.Generic;
using UnityEngine;

public class TileReader : MonoBehaviour
{
    public GameObject Controller;
    char[][][] Map;
    // Start is called before the first frame update
    void Start()
    {
        Map = Controller.GetComponent<Puzzle1>().Map;
    }
    Vector2[] Read()
    {
        List<Vector2> EmptyTiles = new List<Vector2>();
        Vector2 pos = new Vector2(Map[0].Length * 0.6f, Map[0][0].Length * 0.6f);
        foreach (var col in Map[0])
        {
            foreach (var tile in col)
            {
                if (tile == 'O')
                {
                    EmptyTiles.Add(pos);
                }
                pos.y -= 1.2f;
            }
            pos.x -= 1.2f;
        }
        return EmptyTiles.ToArray();
    }
}
