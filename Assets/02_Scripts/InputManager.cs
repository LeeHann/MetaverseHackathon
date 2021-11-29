using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;
//using Newtonsoft.Json;


public class InputManager : MonoBehaviour
{
    public InputField InputName;
    public InputField InputFieldAddress;
    public InputField InputFieldAccount;
    public InputField InputFieldCheckName;
    public Button ButtonCheck;
    public string nm;

    Button ButtonPay;

    public class Header
    {
        public string ApiNm = "InquireDepositorAccountNumber";
        public string Tsymd = "20211129";
        public string Trtm = "112428";
        public string Iscd = "001367";
        public string FintechApsno = "001";
        public string ApiSvcCd = "DrawingTransferA";
        public string IsTuno;
        public string AccessToken = "e65d3b76373e639a91f75913154795846691a57cea913d610e3e344b00eea17f";
    }

    public class Jsoner
    {
        public Header header;
        public string Bncd = "011";
        public string Acno;
    }

    void Start()
    {
        ButtonPay = GetComponentInChildren<Button>();
        ButtonPay.onClick.AddListener(() => gameObject.SetActive(false));
        ButtonCheck.onClick.AddListener(CheckName);

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(InputName.text);
            Debug.Log(InputFieldAddress.text);
            nm = InputFieldAccount.text;
            Debug.Log(InputFieldAccount.text);
            Debug.Log(InputFieldCheckName.text);
        }    
    }



    void CheckName()
    {
        Debug.Log("��ư ������!");

        Jsoner js = new Jsoner();
        Header hd = new Header();
        hd.IsTuno = Random.Range(5315, 6151354635).ToString();
        js.header = hd;
        js.Acno = nm;

        //string jdata = JsonConvert.SerializeObject(js);
        //Debug.Log(jdata);
    }

 

}
