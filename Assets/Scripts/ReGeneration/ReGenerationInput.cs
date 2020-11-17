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
        SharedData.ins.data.SetValue(result);
    }
}