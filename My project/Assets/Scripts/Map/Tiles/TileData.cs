using Assets.Scripts.GridManager;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "New Data Tile", menuName = "DataTile")]
public class TileData : ScriptableObject
{
    public Sprite sprite;
    public TypeTiles type;
    public int movementCost;
    public bool isWalkable;
}
