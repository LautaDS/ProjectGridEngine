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

    public SpriteRenderer spriteRenderer;

    public void Initialize(ScriptableUnit scriptableUnit)
    {
        // Starting variables
        StartingPos = scriptableUnit.StartingPos;
        this.startingHP = scriptableUnit.startingHP;
        this.movement = scriptableUnit.movement;
        this.startingMana = scriptableUnit.startingMana;

        // Dynamic variables
        currentPos = StartingPos;
        currentHP = startingHP;
        currentMana = startingMana;

        // Setup for Unity components and such
        this.transform.position = new Vector3(StartingPos.x, StartingPos.y, 0);
        this.transform.rotation = Quaternion.identity;
        
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = scriptableUnit.sprite;
        spriteRenderer.sortingLayerName = "Grid";

        spriteRenderer.sortingOrder = 2;
    }

    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
