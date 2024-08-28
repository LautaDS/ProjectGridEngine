using System;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

namespace Assets.Scripts.GridManager
{
    public class MapMediator : MonoBehaviour
    {
        [SerializeField] private GameManager gameManager;
        [SerializeField] private IMapHandler mapHandler;
        [SerializeField] private TextAsset csvFile;
        [SerializeField] private List<TileData> tileData;

        // Start is called before the first frame update
        void Start()
        {

        }

        private void Awake()
        {
            mapHandler = GetComponent<IMapHandler>();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
        }

        public void InstanciateGrid()
        {
            // Aca va la logica necesaria cuando se construya el proceso por el cual la informacion del mapa este guardada en un archivo.
            try
            {
                mapHandler.InstantiateGrid(csvFile, tileData);
                gameManager.UpdateGameState(GameState.SpawnUnits);
            }
            catch (Exception ex)
            {
                Debug.LogError($"An error occurred: {ex.Message}\nStack Trace: {ex.StackTrace}");
            }
        }

        //Algunos diran que esto no es responsabilidad del mediator, yo digo que me coma las bolas Kyle.
        public void InitialPositionUnits(List<BaseUnit> units)
        {
            foreach (var unit in units)
            {

            }
        }
    }
}
