using Assets.Scripts.GridManager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CursorMediator : MonoBehaviour
{
    [SerializeField] private ICursor cursorHandler;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        cursorHandler = GetComponent<ICursor>();
    }

    public void UpdateCursorPosition(Tilemap grid)
    {
        cursorHandler.UpdateCursor(grid);
    }
}
