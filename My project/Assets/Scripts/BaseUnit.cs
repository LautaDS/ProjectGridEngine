using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.U2D;


public class BaseUnit : MonoBehaviour
{
    private Vector2 StartingPos;
    public Vector2 currentPos;

    private int startingHP;
    public int currentHP;

    private int movement;

    private int startingMana;
    public int currentMana;

    public Sprite sprite;
    public SpriteRenderer spriteRenderer;

    public void Initialize(ScriptableUnit scriptableUnit)
    {
        StartingPos = scriptableUnit.StartingPos;
        this.startingHP = scriptableUnit.startingHP;
        this.movement = scriptableUnit.movement;
        this.startingMana = scriptableUnit.startingMana;
        sprite = scriptableUnit.sprite;

        currentPos = StartingPos;
        currentHP = startingHP;
        currentMana = startingMana;

        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sortingLayerName = "Grid";

        spriteRenderer.sortingOrder = 1;
    }

    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
