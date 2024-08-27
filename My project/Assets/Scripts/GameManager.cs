using Assets.Scripts;
using Assets.Scripts.GridManager;
using Assets.Scripts.Units;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] UnitMediator unitManager;
    [SerializeField] MapMediator mapManager;
    [SerializeField] CursorMediator cursorMediator;
    private GameState _gameState;

    public static event Action<GameState> OnGameStateChanged;
    // Start is called before the first frame update
    void Awake()
    {
    }

    private void Start()
    {
        UpdateGameState(GameState.InstanceGrid);
    }

    // Update is called once per frame
    void Update()
    {
        cursorMediator.UpdateCursorPosition(mapManager.GetTilemap());
        if (Input.GetMouseButtonDown(0))
        {
            var amount = unitManager.GetAmountOfUnitsInstanciated();
            print(amount.ToString());
            var unitsz = unitManager.GetRandomUnitThatWasInstanciated();
            print("A random unit of the ones instanciated are in the position " + unitsz.currentPos);
        }
    }

    public void UpdateGameState(GameState newState)
    {
        _gameState = newState;

        switch (newState)
        {
            case GameState.InstanceGrid:
                InstanciateGrid();
                break;
            case GameState.SpawnUnits:
                InstanciateUnits();
                break;
            case GameState.PlayerTurn:
                break;
            case GameState.EnemyTurn:
                break;
            case GameState.VictoryState:
                break;
            case GameState.LoseState:
                break;
        }

        OnGameStateChanged?.Invoke(newState);

    }

    private void InstanciateUnits()
    {
        var units = unitManager.SpawnStartingEnemies();
        var unitsAndTheirTiles = mapManager.GetTilesForUnits(units);
        unitManager.PositionUnits(unitsAndTheirTiles);
        UpdateGameState(GameState.PlayerTurn);
    }

    private void InstanciateGrid()
    {
        mapManager.InstanciateGrid();
    }
}

public enum GameState
{
    InstanceGrid,
    SpawnUnits,
    PlayerTurn,
    EnemyTurn,
    VictoryState,
    LoseState
}
