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


public class LeadSender : MonoBehaviour
{
    public TMP_InputField nomeInput;
    public TMP_InputField telefoneInput;
    public TMP_InputField rendaInput;
    public TMP_InputField regiaoInput;
    public TMP_Dropdown tipodeTrabalhodrop, estadocivildrop;
    
    

    public void CriarNoBanco()
    {
        Lead novoLead = new Lead(nomeInput.text, telefoneInput.text, estadocivildrop.options[estadocivildrop.value].text, rendaInput.text,tipodeTrabalhodrop.options[tipodeTrabalhodrop.value].text, regiaoInput.text);
        string newLeadJson = JsonUtility.ToJson(novoLead);
        RestClient.Put("https://acheiimoveis-7f18d-default-rtdb.firebaseio.com/Leads/"+SystemInfo.deviceUniqueIdentifier+"/"+novoLead.nome+".json", newLeadJson);
    }

}
