using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text.RegularExpressions;

 public class PhoneInputMask : MonoBehaviour
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
 
     public void OnValueChangeEvent()
     {
        if(inputField.text.Contains("(") && !inputField.text.Contains(")"))
        {
            inputField.text = inputField.text.Remove(0,1);
            last = string.Empty;
        }

        if(inputField.text.Length==2 && !last.Contains(")") && !last.Contains("(") && last!=string.Empty)
        {
            string output = string.Format("({0})", inputField.text);
            inputField.text = output;
            inputField.MoveTextEnd(false);
        }

        if(inputField.text.Length==9 && !last.Contains("-"))
        {
            string output = string.Format("{0}-", inputField.text);
            inputField.text = output;
            inputField.MoveTextEnd(false);
        }

        if(inputField.text.Length==11)
        {
            System.Text.RegularExpressions.Match match = System.Text.RegularExpressions.Regex.Match(inputField.text, @"(\d{2})(\d{5})(\d{4})");
            if ( match.Success )
            {
                string output = string.Format("({0}) {1}-{2}", match.Groups[1], match.Groups[2], match.Groups[3]);
                inputField.text = output;
            }
        }

        last = inputField.text;
     }
 }