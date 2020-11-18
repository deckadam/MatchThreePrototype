using UnityEngine;
using UnityEngine.UI;

public class ReGenerationInput : MonoBehaviour
{
    private InputField _inputField;

    private void Start()
    {
        _inputField = GetComponent<InputField>();
        _inputField.text = SharedData.ins.data.GetValue().ToString();
    }

    public void OnValueChanged()
    {
        var newData = _inputField.text;
        int.TryParse(newData, out var result);

        result = Mathf.Clamp(result, 1, SharedData.ins.maxGridCountForSafety);
        _inputField.text = result.ToString();

        SharedData.ins.data.SetValue(result);
    }
}