using UnityEngine;

public class GridMaster : MonoBehaviour
{
    [SerializeField] private GameObject gridPlane;
    [SerializeField] private GridCell cellPrefab;
    [SerializeField] private float basePlaneSize;
    [SerializeField] private float cellSizeMultiplier;

    public static GridCell[,] GridCells;

    private void Start()
    {
        GenerateGrid();
    }

    //Also called from ui for re-generating grid
    public void GenerateGrid()
    {
        var data = SharedData.ins.data;
        GridGenerator.GenerateGrid(gridPlane, data);

        if (GridCells != null)
        {
            ClearGridClutter(GridCells);
        }

        GridCells = GridCellGenerator.GenerateGridCells(basePlaneSize, data, cellPrefab, cellSizeMultiplier);
    }

    private static void ClearGridClutter(GridCell[,] cellsToClear)
    {
        var columnLength = cellsToClear.GetLength(0);
        var rowLength = cellsToClear.GetLength(1);
        for (var i = 0; i < columnLength; i++)
        {
            for (var j = 0; j < rowLength; j++)
            {
                Destroy(cellsToClear[i, j].gameObject);
            }
        }
    }
}