using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;

public class SendDataRequests : MonoBehaviour
{
    // int frameCounter = 0;
    // readonly int COUNT = 1000;

    // reference to text component
    public TMP_Text textComponent;

    void Start()
    {
        textComponent.text = "";
        InvokeRepeating("getData", 1.0f, 30.0f);
    }

    // Update is called once per frame
    void Update()
    {
        // frameCounter++;
        // if (frameCounter == COUNT) {  
        //     StartCoroutine(GetSheetData());
        //     frameCounter = 0;
        // }
    }

    void getData() 
    {
        Debug.Log("retrieving data");
        StartCoroutine(GetAverageMoods());
    }

    IEnumerator GetAverageMoods()
    {
        Debug.Log("retriving average moods");
        UnityWebRequest dataReq = UnityWebRequest.Get("https://ineffablezoe.wixsite.com/moodetarium/_functions/averageMoods");
        yield return dataReq.SendWebRequest();
        if (dataReq.result == UnityWebRequest.Result.ConnectionError || dataReq.result == UnityWebRequest.Result.ProtocolError) 
        {
            Debug.Log("ERROR: " + dataReq.error);
        } 
        else 
        {
            string jsonResponseContents = dataReq.downloadHandler.text;
            Debug.Log(jsonResponseContents);
            textComponent.text = jsonResponseContents;
        }
    }
}
