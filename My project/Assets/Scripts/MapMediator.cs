using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

namespace Assets.Scripts.GridManager
{
    public class MapMediator : MonoBehaviour
    {
        [SerializeField] private GameManager gameManager;
        [SerializeField] private IMapHandler mapHandler;
        // Esto contiene la informacion default de cada TIPO de Tile. [Pasto, montaña, agua, pared]
        [SerializeField] private List<TileData> tileDatas;

        // Start is called before the first frame update
        void Start()
        {

        }

        private void Awake()
        {

            mapHandler = GetComponent<IMapHandler>();
        }

        public Tilemap GetTilemap()
        {
            return mapHandler.GetMap();
        }

        public Dictionary<BaseUnit, TileDetails> GetTilesForUnits(List<BaseUnit> units)
        {
            return mapHandler.GetTilesToPosition(units);
        }


        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                var tile = mapHandler.GetTileData(mousePosition);
                int tileMovementCost = tile.movementCost;

                print("Seleccionamos el area " + mousePosition + " y ahi elegimos un " + tile + "Su costo de movimiento es " + tileMovementCost);
            }
        }

        public void InstanciateGrid()
        {
            // Aca va la logica necesaria cuando se construya el proceso por el cual la informacion del mapa este guardada en un archivo.
            mapHandler.InstantiateGrid(tileDatas);
            gameManager.UpdateGameState(GameState.SpawnUnits);
        }

        //Algunos diran que esto no es responsabilidad del mediator, yo digo que me coma las bolas Kyle.
        public void InitialPositionUnits(List<BaseUnit> units)
        {
            foreach (var unit in units) 
            {
                var tile = mapHandler.GetTileData(unit.currentPos);
                print("Estamos setteando la posicion de la unit en referencia al tile que su posicion es " + tile.position);
                if(tile != null)
                    unit.transform.position = tile.position;
            }
        }

        

        public List<TileBase> GetNeighbourTilesOfUnit(BaseUnit unit)
        {
            return null;
        }

    }
}
