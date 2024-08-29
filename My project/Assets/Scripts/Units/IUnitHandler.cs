﻿using Assets.Scripts.GridManager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Units
{
    public interface IUnitHandler
    {
        void SpawnStartingUnits();
        void PositionUnits(Dictionary<BaseUnit, TileDetails> unitsAndTiles);
    }
}