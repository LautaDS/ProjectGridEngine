using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Assets.Scripts.GridManager
{
    public class TileDetails
    {
        public TileBase tile;
        public bool isOccupied = false;
        public Vector2 position;
        public int movementCost;
        public bool isWalkable;

        public TileDetails(TileBase baseDetails, int movementCost, bool isWalkable, Vector2 position)
        {
            tile = baseDetails;
            this.movementCost = movementCost;
            this.isWalkable = isWalkable;
            this.position = position;
        }

        public TileDetails()
        {

        }

        public TileDetails(TileData data)
        {
            movementCost= data.movementCost;
            isWalkable = data.isWalkable;
        }
    }
}