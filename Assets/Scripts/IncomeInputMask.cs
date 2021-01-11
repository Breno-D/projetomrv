using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IncomeInputMask : MonoBehaviour
{
    public TMP_InputField inputField;
    string last = string.Empty;

    private void OnValidate()
    {
    inputField = GetComponent<TMP_InputField>();
    }

    public void Start()
    {
        inputField.onValueChanged.AddListener(delegate { OnValueChangeEvent(); });
    }

    // Invoked when the value of the text field changes.
    public void OnValueChangeEvent()
    {
        if(!inputField.text.Contains("."))
        {
            string output = string.Format("{0}.00", inputField.text);
            inputField.text = output;
        }

        last = inputField.text;
    }
}
