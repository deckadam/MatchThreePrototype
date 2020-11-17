using System;
using System.Collections.Generic;

public static class MatchChecker
{
    public static Action<int> OnScoreChanged;

    private static int _totalMatchCount;

    private static int TotalMatchCount
    {
        get => _totalMatchCount;

        set
        {
            _totalMatchCount = value;
            OnScoreChanged?.Invoke(value);
        }
    }

    public static void CheckForMatch(int i, int j)
    {
        var value = SharedData.ins.data.GetValue();
        var checkMaster = new bool[value, value];

        var foundList = new List<GridCell>();

        var cells = GridMaster.GridCells;

        CheckTheNeighbours(i, j, checkMaster, foundList, cells);

        if (foundList.Count < 3) return;

        TotalMatchCount++;
        foreach (var matchingCell in foundList)
        {
            matchingCell.SetCellClear();
        }

        foundList.Clear();
    }

    private static void CheckTheNeighbours(int i, int j, bool[,] checkMaster, List<GridCell> foundList, GridCell[,] cells)
    {
        //Is cell ticked if not pass
        if (!cells[i, j].IsCellticked()) return;

        //Is cell already checked if not pass
        if (checkMaster[i, j]) return;

        //Set cell checked
        checkMaster[i, j] = true;

        //If not add to found list
        foundList.Add(cells[i, j]);

        //Check neighbours for additional ticks
        CheckTheNeighbours(i + 1, j, checkMaster, foundList, cells);
        CheckTheNeighbours(i - 1, j, checkMaster, foundList, cells);
        CheckTheNeighbours(i, j + 1, checkMaster, foundList, cells);
        CheckTheNeighbours(i, j - 1, checkMaster, foundList, cells);
    }
}