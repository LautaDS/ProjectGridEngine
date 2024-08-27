using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Assets.Scripts.GridManager
{
    public class DrawnMapHandler : MonoBehaviour, IMapHandler
    {
        [SerializeField] private Tilemap map;
        public Tilemap Map { get => map; private set => map = value; }
        // This is an initial dictionary of every type of TileBase on the map. And the associated info to that tile.
        // It's a setup variable

        private Dictionary<TileBase, TileDetails> dataFromTiles;
        private List<TileDetails> tileDetails;


        public void Awake()
        {
            dataFromTiles = new Dictionary<TileBase, TileDetails>();
            tileDetails = new List<TileDetails>();
        }

        public Tilemap GetMap()
        {
            return Map;
        }

        public List<TileDetails> GetMapInfo()
        {
            return tileDetails;
        }

        public List<TileDetails> GetNeighbourTiles(TileDetails tile)
        {
            if (tile == null) return null;

            List<TileDetails> neighbours = tileDetails
            .Where(t => t.position != tile.position && // Exclude the tile itself
                        (Mathf.Abs(t.position.x - tile.position.x) == 1 && t.position.y == tile.position.y) || // Left or right neighbor
                        (Mathf.Abs(t.position.y - tile.position.y) == 1 && t.position.x == tile.position.x)) // Top or bottom neighbor
            .ToList();

            return neighbours;
        }

        //Esto esta funcionando MAL.
        public TileDetails GetTileData(Vector2 position)
        {
            Vector3Int positionInMap = map.WorldToCell(position);
            TileBase tile = map.GetTile(positionInMap);

            var tileToReturn = tileDetails.Where(t => ReferenceEquals(t.tile, tile))
            .FirstOrDefault();

            if (tileToReturn == null)
            {
                print("No encontramos el tile que buscamos en nuestro tileDetails");
            }

            return tileToReturn;
        }

        public void InstantiateGrid(List<TileData> tileDatas)
        {
            // Setupeamos nuestra info de los tiles en dataFromTiles.
            foreach (var tileData in tileDatas)
            {
                foreach (var tile in tileData.tiles)
                {
                    dataFromTiles.Add(tile, new TileDetails(tileData));
                }
            }

            //Checkeamos cada tile en el mapa, y creamos una "referencia" a tileDetails, que va a contener al tileBase
            //y toda la data estatica Y dinamica de cada casillero.
            //BoundsInt bounds = map.cellBounds;
            //for (int x = bounds.x; x < bounds.x + bounds.size.x; x++)
            //{
            //    for (int y = bounds.y; y < bounds.y + bounds.size.y; y++)
            //    {
            //        Vector3Int cellPosition = new Vector3Int(x, y, 0);
            //        TileBase tile = map.GetTile(cellPosition);
            //        print(tile + " existe");
            //        if (tile != null)
            //        {
            //            tileDetails.Add(new TileDetails(tile, dataFromTiles[tile].movementCost,
            //                dataFromTiles[tile].isWalkable,
            //                new Vector2(cellPosition.x, cellPosition.y)));
            //        }
            //    }
            //}
        }

        public Dictionary<BaseUnit, TileDetails> GetTilesToPosition(List<BaseUnit> units)
        {
            Dictionary<BaseUnit, TileDetails> unitPlusItsTile = new Dictionary<BaseUnit, TileDetails>();

            foreach(var unit in units)
            {
                print("La posicion configurada de la unidad es: " + unit.currentPos.x + " " + unit.currentPos.y);
                Vector3Int cellPosition = new Vector3Int((int)unit.currentPos.x, (int)unit.currentPos.y, 0);
                print("Var cellPosition "+cellPosition);
                TileBase tile = map.GetTile(cellPosition);
                if(tile != null)
                {
                    // Busco la info generica del tipo de tile en dataFromTiles.
                    TileDetails tileDataForUnit = dataFromTiles.GetValueOrDefault(tile);
                    // Sobreescribo en el objeto el tile, para que no me de el primero del diccionario, sino el del mapa.
                    tileDataForUnit.tile = tile;
                    //Es mandatorio usar el parametro position de TileDetails, por que desde afuera del Handler, no tenemos acceso al Tilemap.
                    var position = map.CellToWorld(cellPosition);
                    print("Var position =" + position);
                    tileDataForUnit.position = position;
                    unitPlusItsTile.Add(unit,tileDataForUnit);
                }
            }

            return unitPlusItsTile;
        }
    }
}