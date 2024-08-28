using Assets.Scripts.GridManager;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts
{
    public class TLDKMapHandler : MonoBehaviour, IMapHandler
    {
        //Setup variables
        [SerializeField] private TileDetails tilePrefab;
        // Actual Map.
        private TileDetails[,] mapArray;

        // Use this for initialization
        void Awake()
        {
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void InstantiateGrid(TextAsset csvFile, List<TileData> tileData)
        {
            string[] lines = csvFile.text.Split(new char[] { '\n', '\r' }, System.StringSplitOptions.RemoveEmptyEntries);
            mapArray = DefineArray(lines);

            for (int i = 0; i < mapArray.GetLength(0); i++)
            {
                string[] values = lines[i].Split(new char[] { ',' }, System.StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < mapArray.GetLength(1); j++)
                {
                    if (j < values.Length)
                    {
                        string trimmedValue = values[j].Trim(); // Trim whitespace

                        if (int.TryParse(trimmedValue, out int parsedValue))
                            trimmedValue = "99";
                        var data = tileData.FirstOrDefault(td => (int)td.type == parsedValue);
                        var tileToAssign = SetUpTile(data, new Vector2Int(i, j));
                        mapArray[i, j] = tileToAssign;
                    }
                }
            }
        }

        private TileDetails SetUpTile(TileData data, Vector2Int position)
        {
            var tile = Instantiate<TileDetails>(tilePrefab, this.transform);
            tile.Init(data, position);
            return tile;
        }

        private TileDetails[,] DefineArray(string[] lines)
        {
            int rows = lines.Length;
            int maxCols = 0;
            foreach (var line in lines)
            {
                int cols = line.Split(',').Length;
                if (cols > maxCols)
                {
                    maxCols = cols;
                }
            }
            return new TileDetails[rows, maxCols];
        }
    }
}