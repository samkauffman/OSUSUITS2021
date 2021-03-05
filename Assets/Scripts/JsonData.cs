using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Net;

/*
 * 
 * Telemetry Stream is collected, converted to a Json file, then put into an object
 * 
 * SuitData and UIAData each are their own object with their own class
 * 
 */

[System.Serializable]
public class JsonData : MonoBehaviour
{
    public SuitData suitData;
    public UIAData uiaData;

    private float timer = 0.0f;

    void Update()
    {
        timer += Time.deltaTime;
        //Telemetry Stream updates constantly so we are loading the data every frame
        //Instead, load every second
        if (timer > 1) {
            timer--;
            LoadData_Suit();
        }
    }

    void LoadData_Suit()
    {
		try
		{
            string jsonSuitData; //carrier string
            //load data from url to json string
            WebClient client = new WebClient();
            jsonSuitData = client.DownloadString("http://localhost:3000/api/simulation/state");
            //loads json string to SuitData class
            suitData = JsonUtility.FromJson<SuitData>(jsonSuitData);


            string jsonUIAData; //carrier string
            //load data from url to json string
            WebClient client2 = new WebClient();
            jsonUIAData = client2.DownloadString("http://localhost:3000/api/simulation/uiastate");
            //loads json string to uiaData class
            uiaData = JsonUtility.FromJson<UIAData>(jsonUIAData);
        }
		catch (System.Exception ex)
		{
            Debug.Log(ex.Message);
		}
    }
}
