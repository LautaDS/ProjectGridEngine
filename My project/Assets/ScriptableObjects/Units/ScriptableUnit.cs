using Assets.Scripts.Units;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Unit",menuName ="ScriptableUnit")]
public class ScriptableUnit : ScriptableObject
{
    public Faction Faction;

    [SerializeField] public Vector2 StartingPos;

    [SerializeField] public int startingHP;

    [SerializeField] public int movement;

    [SerializeField] public int startingMana;

    [SerializeField] public Sprite sprite;
}
