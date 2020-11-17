using UnityEngine;

public static class GridGenerator
{
    public static void GenerateGrid(GameObject gridPlane, GridData data)
    {
        var gridRenderer = gridPlane.GetComponent<MeshRenderer>();
        var gridMaterial = gridRenderer.material;
        SetGridMaterialData(gridMaterial, data);
    }

    private static void SetGridMaterialData(Material gridMaterial, GridData data)
    {
        var value = data.GetValue();
        gridMaterial.mainTextureScale = new Vector2(value, value);
    }
}