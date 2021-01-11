using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Auth;
using Firebase.Database;
using Firebase.Unity.Editor;
using Proyecto26;
using TMPro;

public class Lead {
    public string nome;
    public string telefone;
    public string estadocivil;
    public string renda;
    public string tipodetrabalho;
    public string regiao;

    public Lead(string nome, string telefone, string estadocivil, string renda, string tipodetrabalho, string regiao) {
        this.nome = nome;
        this.telefone = telefone;
        this.estadocivil = estadocivil;
        this.renda = renda;
        this.tipodetrabalho = tipodetrabalho;
        this.regiao = regiao;
    }
}


public class LeadFormatting : MonoBehaviour
{
    public TMP_InputField nomeInput;
    public TMP_InputField telefoneInput;
    public TMP_InputField rendaInput;
    public TMP_InputField regiaoInput;
    public TMP_Dropdown tipodeTrabalhodrop, estadocivildrop;
    public GameObject errorWindow;
    public TMP_Text errorText;
    
    

    public void FormatLeadThenSendEmail()
    {
        if(!CheckInputForErrors())
        {
            string leadBody = "Nome : "+nomeInput.text+"\r\nTelefone : "+telefoneInput.text+"\r\nEstado Civil : "+estadocivildrop.options[estadocivildrop.value].text+"\r\nRenda : "+rendaInput.text+"\r\nTipo de Trabalho : "+tipodeTrabalhodrop.options[tipodeTrabalhodrop.value].text+"\r\nRegião de Preferência : "+regiaoInput.text+"\r\n\r\n\r\nLead Criado à partir do aplicativo Achei Imóveis\r\nBoa sorte nas vendas :)";
            Debug.Log(leadBody);
            GetComponent<EmailFactory>().SendEmail(nomeInput.text, leadBody);
        }
    }

    bool CheckInputForErrors()
    {
        if(nomeInput.text==""|| telefoneInput.text =="" || rendaInput.text == "" || regiaoInput.text == "")
        {
            errorWindow.SetActive(true);
            errorText.text = "Todos os campos são obrigatórios (um ou mais campos estão vazios)";
            return true;
        }else  return false;
    }
    
    public void CloseErrorBox()
    {
        errorWindow.SetActive(false);
    }
}
