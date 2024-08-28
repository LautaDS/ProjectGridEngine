using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Assets.Scripts.Cursor
{
    public class MouseCursor : MonoBehaviour, ICursor
    {
        // En realidad esto no iria en el Mediator? Considerando que en todos los tipos de cursores, siempre va a existir?
        // Por lo tanto el rol del Handler es solo manejar el input?
        [SerializeField] private GameObject mouseIndicator, cellIndicator;
        private Vector3 Offset;

        public void Awake()
        {
            Offset.x = 0.5f;
            Offset.y = 0.5f;
        }

        public void UpdateCursor(Tilemap grid) 
        {
            // Acordate de llevartelo al area de input despues
            Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int gridPosition = grid.WorldToCell(cursorPosition);
            mouseIndicator.transform.position = cursorPosition;

            
            cellIndicator.transform.position = grid.CellToWorld(gridPosition);
            //Offset para correrlo de la esquina del tile en el que esta parado, al centro.
            //cellIndicator.transform.position = AddOffset(cellIndicator.transform.position);
        }

        private Vector3 AddOffset(Vector3 cellIndicatorPos)
        {
            return cellIndicatorPos += Offset;
        }
    }
}