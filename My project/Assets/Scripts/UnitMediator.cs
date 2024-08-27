﻿using Assets.Scripts.GridManager;
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
        [SerializeField]private List<ScriptableUnit> _startingUnits;
        
        public void Awake()
        {
            // Esta linea es util para recordar el concepto de Resources: _units = Resources.LoadAll<ScriptableUnit>("Units").ToList();
            unitHandler = GetComponent<IUnitHandler>();
        }


        public List<BaseUnit> SpawnStartingEnemies()
        {
            unitHandler.SpawnStartingUnits(_startingUnits);
            return unitHandler.GetAllUnits();
        }

        public void PositionUnits(Dictionary<BaseUnit,TileDetails> unitsAndTiles)
        {
            unitHandler.PositionUnits(unitsAndTiles);
        }

        public BaseUnit GetRandomUnitThatWasInstanciated()
        {
            return unitHandler.GetRandomUnit();
        }

        public int GetAmountOfUnitsInstanciated()
        {
            return unitHandler.AmountInstanciated();
        }
    }
}