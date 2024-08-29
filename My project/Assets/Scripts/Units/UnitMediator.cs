using Assets.Scripts.GridManager;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Units
{
    public class UnitMediator : MonoBehaviour
    {
        [SerializeField] IUnitHandler unitHandler;
        // El scriptObj con la lista de unidades con las que comenzamos
        
        public void Awake()
        {
            // Esta linea es util para recordar el concepto de Resources: _units = Resources.LoadAll<ScriptableUnit>("Units").ToList();
            unitHandler = GetComponent<IUnitHandler>();
        }


        public void SpawnStartingEnemies()
        {
            unitHandler.SpawnStartingUnits();
        }

        public void PositionUnits(Dictionary<BaseUnit,TileDetails> unitsAndTiles)
        {
            unitHandler.PositionUnits(unitsAndTiles);
        }

    }
}