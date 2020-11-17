using UnityEngine;

public class GridCell : MonoBehaviour
{
    private static readonly int MainTexture = Shader.PropertyToID("_MainTex");

    private int _x;
    private int _y;

    private Material _cachedMaterial;

    private bool _iscellTicked;

    public void SetData(int x, int y)
    {
        _x = x;
        _y = y;

        var meshRenderer = gameObject.GetComponent<MeshRenderer>();
        _cachedMaterial = meshRenderer.material;
    }

    public void SetCellTicked()
    {
        _cachedMaterial.SetTexture(MainTexture, SharedData.ins.cellTickedTexture);
        _iscellTicked = true;
        MatchChecker.CheckForMatch(_x, _y);
    }

    public void SetCellClear()
    {
        _cachedMaterial.SetTexture(MainTexture, SharedData.ins.cellClearTexture);
        _iscellTicked = false;
    }

    public bool IsCellticked() => _iscellTicked;
}