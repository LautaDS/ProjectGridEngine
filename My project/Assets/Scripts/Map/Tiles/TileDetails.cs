using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Assets.Scripts.GridManager
{
    public class TileDetails : MonoBehaviour
    {
        public TypeTiles type;
        public bool isOccupied = false;
        public Vector2Int position;
        public int movementCost;
        public bool isWalkable;

        public void Init(TileData data, Vector2Int position)
        {
            isOccupied = false;
            this.position = position;
            this.transform.position = new Vector3(this.position.x, this.position.y, 0);
            this.transform.rotation = Quaternion.identity;
            this.gameObject.name = "Tile"+position.x+position.y;

            type = data.type;
            movementCost = data.movementCost;
            isWalkable = data.isWalkable;
            var spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.sortingLayerName = "Grid";
            spriteRenderer.sprite = data.sprite;
            spriteRenderer.sortingOrder = 1;
        }
    }
}