using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;

public class SendDataRequests : MonoBehaviour
{
    // reference to text component
    // public TMP_Text textComponent;

    private Dictionary<string, float> moodDict;
    private PlanetManager planetManager;

    void Awake()
    {
        planetManager = GameObject.Find("Planets").GetComponent<PlanetManager>();
        // textComponent.text = "";
        InvokeRepeating("getData", 0, 30.0f);
    }

    void getData() 
    {
        Debug.Log("retrieving data");
        StartCoroutine(GetAverageMoods());
    }

    IEnumerator GetAverageMoods()
    {
        UnityWebRequest dataReq = UnityWebRequest.Get("https://ineffablezoe.wixsite.com/moodetarium/_functions/averageMoods");
        yield return dataReq.SendWebRequest();
        if (dataReq.result == UnityWebRequest.Result.ConnectionError || dataReq.result == UnityWebRequest.Result.ProtocolError) 
        {
            Debug.Log("ERROR: " + dataReq.error);
        } 
        else 
        {
            // textComponent.text = jsonResponseContents;
            moodDict =  DataHandler.parseResponse(dataReq.downloadHandler.text);
            planetManager.setPlanetColors(moodDict);
        }
    }
}
