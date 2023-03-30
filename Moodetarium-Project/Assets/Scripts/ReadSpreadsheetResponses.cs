using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;

namespace DataAcquisitionSpace {
public class ReadSpreadsheetResponses : MonoBehaviour
{
    int frameCounter = 0;
    readonly int COUNT = 1000;

    // reference to text component
    public TMP_Text textComponent;

    // Start is called before the first frame update
    void Start()
    {
            textComponent.text = "";
            InvokeRepeating("GetSheetData", 1.0f, 30.0f);
    }

    // Update is called once per frame
    void Update()
    {
        frameCounter++;
        if (frameCounter == COUNT) {  
            StartCoroutine(GetSheetData());
            frameCounter = 0;
        }
    }

    IEnumerator GetSheetData()
    {
        // IF THIS IS EVER PUT ON GITHUB THE API KEY NEEDS TO BE REMOVED
        UnityWebRequest sheetDataReq = UnityWebRequest.Get("https://ineffablezoe.wixsite.com/moodetarium/_functions/averageMoods");
        yield return sheetDataReq.SendWebRequest();
        if (sheetDataReq.result == UnityWebRequest.Result.ConnectionError || sheetDataReq.result == UnityWebRequest.Result.ProtocolError) 
        {
            Debug.Log("ERROR: " + sheetDataReq.error);
        } 
        else 
        {
            string jsonResponseContents = sheetDataReq.downloadHandler.text;
            SpreadsheetData data = new SpreadsheetData(jsonResponseContents);
            Debug.Log(data.ToString());
            textComponent.text = data.ToString();
        }
    }
}
}
