using UnityEngine;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;

    //Triggered from unity ui event
    public void OnPointerDown()
    {
        var ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out var hit, float.MaxValue, 1 << 8))
        {
            hit.transform.GetComponent<GridCell>().SetCellTicked();
        }
    }
}