using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Assets.Scripts.GridManager
{
    public interface IMapHandler
    {
        void InstantiateGrid(TextAsset csvFile, List<TileData> tileData);
    }
}