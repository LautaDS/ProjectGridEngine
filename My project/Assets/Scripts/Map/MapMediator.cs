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

        }

        public void InstanciateGrid()
        {
                mapHandler.InstantiateGrid(csvFile, tileData);
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
