using Assets.Scripts.GridManager;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Assets.Scripts.Units
{
    public class BaseUnitHandler : MonoBehaviour, IUnitHandler
    {
        //Revisar que las clases PlayerUnit y EnemyUnit tengan EL MISMO comportamiento.
        private List<PlayerUnit> _playerUnits;
        private List<EnemyUnit> _enemyUnits;

        [SerializeField] private GameObject _baseunitPrefab;
        private Vector2 Offset;
        // Use this for initialization
        void Start()
        {

        }

        void Awake()
        {
            Offset.x = 1f;
            Offset.y = 1f;
            _playerUnits = new List<PlayerUnit>();
            _enemyUnits = new List<EnemyUnit>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void SpawnStartingUnits(List<ScriptableUnit> _startingUnits)
        {
            foreach (var unit in _startingUnits)
            {
                if (unit != null)
                {
                    GameObject unitObject = Instantiate(_baseunitPrefab);

                    //var tileToPositionUnit = gridInfo.First(t => t.position == unit.StartingPos);
                    //unitObject.transform.position = tileToPositionUnit.position + Offset;

                    if (unit.Faction == Faction.Enemy)
                    {
                        unitObject.name = "Enemy";
                        EnemyUnit enemyUnit = unitObject.AddComponent<EnemyUnit>();
                        enemyUnit.Initialize(unit);
                        _enemyUnits.Add(enemyUnit);
                    }
                    else if (unit.Faction == Faction.Player)
                    {
                        unitObject.name = "Hero";
                        PlayerUnit playerUnit = unitObject.AddComponent<PlayerUnit>();
                        playerUnit.Initialize(unit);
                        _playerUnits.Add(playerUnit);
                    }
                }
            }
        }

        public List<BaseUnit> GetAllUnits()
        {
            return _playerUnits.Concat<BaseUnit>(_enemyUnits).ToList();
        }

        public BaseUnit GetRandomUnit()
        {
            var allUnits = _playerUnits.Concat<BaseUnit>(_enemyUnits).ToList();
            if (allUnits.Count == 0)
            {
                return null;
            }
            var random = new System.Random();
            int randomIndex = random.Next(allUnits.Count);
            return allUnits[randomIndex];
        }

        public int AmountInstanciated()
        {
            return _playerUnits.Count + _enemyUnits.Count;
        }

        public void PositionUnit(BaseUnit unit, TileDetails tileToPositionTo)
        {
            var specificUnit = FindUnit(unit);
            if (specificUnit != null)
                specificUnit.transform.position = tileToPositionTo.position;
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