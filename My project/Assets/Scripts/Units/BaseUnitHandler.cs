﻿using Assets.Scripts.GridManager;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

namespace Assets.Scripts.Units
{
    public class BaseUnitHandler : MonoBehaviour, IUnitHandler
    {
        //Revisar que las clases PlayerUnit y EnemyUnit tengan EL MISMO comportamiento.
        private List<PlayerUnit> _playerUnits;
        private List<EnemyUnit> _enemyUnits;

        [SerializeField] private GameObject _baseunitPrefab;

        [SerializeField]List<ScriptableUnit> _startingUnits;

        // Use this for initialization
        void Start()
        {

        }

        void Awake()
        {
            _playerUnits = new List<PlayerUnit>();
            _enemyUnits = new List<EnemyUnit>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void SpawnStartingUnits()
        {
            foreach (var unit in _startingUnits)
            {
                if (unit != null)
                {
                    GameObject unitObject = Instantiate(_baseunitPrefab, this.transform);

                    if (unit.Faction == Faction.Enemy)
                    {
                        unitObject.name = unit.name;
                        EnemyUnit enemyUnit = unitObject.AddComponent<EnemyUnit>();
                        enemyUnit.Initialize(unit);
                        _enemyUnits.Add(enemyUnit);
                    }
                    else if (unit.Faction == Faction.Player)
                    {
                        unitObject.name = unit.name;
                        PlayerUnit playerUnit = unitObject.AddComponent<PlayerUnit>();
                        playerUnit.Initialize(unit);
                        _playerUnits.Add(playerUnit);
                    }
                }
            }
        }

        public void PositionUnit(BaseUnit unit, TileDetails tileToPositionTo)
        {
            var specificUnit = FindUnit(unit);
            if (specificUnit != null)
            {
                specificUnit.transform.position = new Vector3(tileToPositionTo.position.x, tileToPositionTo.position.y, this.transform.position.z);
                specificUnit.transform.rotation = Quaternion.identity;
            }
        }

        private BaseUnit FindUnit(BaseUnit unit)
        {
            if (unit is PlayerUnit playerUnit)
                return _playerUnits.Find(u => u == playerUnit);
            else if (unit is EnemyUnit enemyUnit)
                return _enemyUnits.Find(u => u == enemyUnit);
            return null;
        }

       public void PositionUnits(Dictionary<BaseUnit, TileDetails> unitsAndTiles)
        {
            foreach (var kvp in unitsAndTiles)
            {
                BaseUnit unitBase = kvp.Key;
                TileDetails tileDetails = kvp.Value;

                if (unitBase != null && tileDetails != null)
                {
                    PositionUnit(unitBase, tileDetails);
                }
            }
        } 
    }
}