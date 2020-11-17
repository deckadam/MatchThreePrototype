using UnityEngine;

public static class GridCellGenerator
{
    public static GridCell[,] GenerateGridCells(float baseSize, GridData data, GridCell cellPrefab, float cellSizeMultiplier)
    {
        var value = data.GetValue();
        var result = new GridCell[value, value];
        var stepSize = baseSize / value;
        var offset = stepSize * (value - 1) / 2f;
        var size = 1f / value * Vector3.one * cellSizeMultiplier;
        var parent = SharedData.ins.cellParent;
        
        for (var i = 0; i < value; i++)
        {
            for (var j = 0; j < value; j++)
            {
                var position = GetCellPosition(i, j, stepSize, offset);

                var newCell = Object.Instantiate(cellPrefab, position, Quaternion.identity);
                newCell.transform.localScale = size;
                newCell.name = i + " " + j;
                newCell.SetData(i, j);
                newCell.transform.parent = parent;

                result[i, j] = newCell;
            }
        }

        return result;
    }

    private static Vector3 GetCellPosition(int i, int j, float stepSize, float offset)
    {
        var x = i * stepSize - offset;
        var z = j * stepSize - offset;
        return new Vector3(x, 0.01f, z);
    }
}