using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Assets.Scripts.GridManager
{
    public interface IMapHandler
    {
        public Tilemap GetMap();
        List<TileDetails> GetMapInfo();
        Dictionary<BaseUnit, TileDetails> GetTilesToPosition(List<BaseUnit> units);
        void InstantiateGrid(List<TileData> tileDatas);
        List<TileDetails> GetNeighbourTiles(TileDetails tile);
        TileDetails GetTileData(Vector2 position);
    }
}