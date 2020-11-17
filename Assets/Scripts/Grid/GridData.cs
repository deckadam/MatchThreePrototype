using UnityEngine;

[CreateAssetMenu(fileName = "Grid cell/row count", menuName = "Grid data", order = 0)]
public class GridData : ScriptableObject
{
    [SerializeField] private int value;

    public int GetValue()
    {
        return value;
    }

    public void SetValue(int newValue)
    {
        value = newValue;
    }
}