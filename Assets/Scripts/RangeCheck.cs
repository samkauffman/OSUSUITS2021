using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RangeCheck : MonoBehaviour
{
    //Change back to transform
    public GameObject Warnings;
    public GameObject prefabErrorMessage;
    public GameObject alertButton;
    public GameObject warningMessagesContainer;
    bool alert = false;

    GameObject[] alerts = new GameObject[18];
    //bool[] currentAlerts = new bool[18];



    //public TextMeshPro prefabErrorMessageText;
    int prefabCounter = 0;      //The number of current error messages
    float offset = 0.02f;       //The distance between error messages
    public TMP_Text currText;   //The text currently being edited
    Vector3 prefabOffset;       //The position offset of the prefabs

    JsonData jsonData;
    string timer;
    int ox_primary;   // PRIMARY OXYGEN - percentage 
    int ox_secondary; // SECONDARY OXYGEN - percentage
    int heart_bpm;    // HEAR RATE: 80 - 100
    float p_suit;     // SUIT PRESSURE: 2 - 4
    float p_sub;      // SUB PRESSURE: 2- 4
    float t_sub;      // TEMPERATURE - degrees farenheit
    int v_fan;        // FAN RPM: 10,000 - 40,000
    float p_o2;       // OXYGEN PRESSURE: 750 - 950
    float rate_o2;    // OXYGEN RATE: 0.5 - 1
    int battery;      // BATTERY CAPACITY: 0 - 30
    float p_h2o_g;    // GAS PRESSURE 14 - 16
    float p_h2o_l;    // LIQUID PRESSURE 14 - 16
    int p_sop;        // SOP PRESSURE: 750 - 950
    float rate_sop;   // SOP RATE: 0.5 - 1
    string t_battery; // TIME LEFT BATTERY 0 - 10
    string t_oxygen;  // TIME LEFT OXYGEN 0 - 10
    string t_water;   // TIME LEFT WATER 0 - 10


    void Start()
    {
        jsonData = GameObject.FindWithTag("Controller").GetComponent<JsonData>();
    }

    void Update()
    {
        // =====================================================================
        //Add to all alerts
        if (Input.GetKeyDown(KeyCode.F1))
        {
            alert = true;
            alerts[0] = prefabErrorMessage;
        }

        //if all alerts are gone
        if (Input.GetKeyDown(KeyCode.F2))
        {
            alert = false;
            Debug.Log("Alert Button Off");
            alertButton.SetActive(false);
        }

        if (alert && alertButton.activeSelf == false)
        {
            Debug.Log("Alert Button On");
            alertButton.SetActive(true);
        }



        //Switch this with if pressing the emergency button
        if (Input.GetKeyDown(KeyCode.F3) && alertButton.activeSelf == true && warningMessagesContainer.activeSelf == false)
        {
            warningMessagesContainer.SetActive(true);
        }

        //Switch with if pressing the emergency button to again
        if (Input.GetKeyDown(KeyCode.F4) && alertButton.activeSelf == true && warningMessagesContainer.activeSelf == true)
        {
            warningMessagesContainer.SetActive(false);
        }

        // ==============================================================================================


        if (Input.GetKeyDown(KeyCode.Space) && alertButton.activeSelf == true)
        {
            prefabCounter += 1;
            GameObject newAlert;
            prefabOffset = new Vector3(prefabErrorMessage.transform.position.x, (prefabErrorMessage.transform.position.y) - prefabCounter * offset, prefabErrorMessage.transform.position.z);
            newAlert = Instantiate(prefabErrorMessage, prefabOffset, Quaternion.identity).gameObject;
            alerts[prefabCounter] = newAlert;
            newAlert.GetComponentInChildren<TMP_Text>().text = prefabCounter.ToString();
            newAlert.transform.parent = Warnings.transform;
        }

        //Converting input string to their corresponding data type
        //Floats: 
        p_suit = float.Parse(jsonData.suitData.p_suit);
        p_sub = float.Parse(jsonData.suitData.p_sub);
        t_sub = float.Parse(jsonData.suitData.t_sub);
        p_o2 = float.Parse(jsonData.suitData.p_o2);
        rate_o2 = float.Parse(jsonData.suitData.rate_o2);
        p_h2o_g = float.Parse(jsonData.suitData.p_h2o_g);
        p_h2o_l = float.Parse(jsonData.suitData.p_h2o_l);
        rate_sop = float.Parse(jsonData.suitData.rate_sop);

        //Ints:
        ox_primary = int.Parse(jsonData.suitData.ox_primary);
        ox_secondary = int.Parse(jsonData.suitData.ox_secondary);
        heart_bpm = int.Parse(jsonData.suitData.heart_bpm);
        v_fan = int.Parse(jsonData.suitData.v_fan);
        battery = int.Parse(jsonData.suitData.cap_battery);
        p_sop = int.Parse(jsonData.suitData.p_sop);

        //Strings: (for now all input times)
        timer = jsonData.suitData.timer;
        t_battery = jsonData.suitData.t_battery;
        t_oxygen = jsonData.suitData.t_oxygen;
        t_water = jsonData.suitData.t_water;

        #region Suit Check


        // HEART RATE 80 - 100 bpm --------------->
        if (heart_bpm < 80)
        {
            string currAlert = "Alert: Low heart rate " + heart_bpm + "pbm";
            Debug.Log(currAlert);
            AddAlert("heart_bpm_error", currAlert);

        }
        else if (heart_bpm > 100)
        {
            //Debug.Log("Alert: High heart rate");
            string currAlert = "Alert: Low heart rate " + heart_bpm + "pbm";
            Debug.Log(currAlert);
            AddAlert("heart_bpm_error", currAlert);
        }
        else
        {
            //Normal range
            RemoveAlert("heart_bpm_error");
        }

        // Suit Pressure 2 - 4 ------------------->
        if (p_suit < 2)
        {
            string currAlert = "Alert: Low suit pressure " + p_suit;
            AddAlert("p_suit_error", currAlert);
        }

        else if (p_suit > 4)
        {
            string currAlert = "Alert: High suit pressure " + p_suit;
            AddAlert("p_suit_error", currAlert);
        }

        else
        {
            RemoveAlert("p_suit_error");
        }

        // Fan 10,000 - 40,000 ------------------->
        if (v_fan < 10000)
        {
            Debug.Log("Alert: Low fan velocity");
        }

        if (v_fan > 40000)
        {
            Debug.Log("Alert: High fan velocity");
        }

        // Oxygen pressure 750 - 950 ------------------->
        if (p_o2 < 750)
        {
            Debug.Log("Alert: Low oxygen pressure");
        }

        if (p_o2 > 950)
        {
            Debug.Log("Alert: High oxygen pressure");
        }

        // Oxygen rate 0.5 - 1 ------------------->
        if (rate_o2 < 0.5)
        {
            Debug.Log("Alert: Low oxygen rate");
        }

        if (rate_o2 > 1)
        {
            Debug.Log("Alert: High oxygen rate");
        }

        // battery capacity 0 - 30 ------------------->
        if (battery < 0)
        {
            Debug.Log("Alert: Low battery capacity");
        }

        if (battery > 30)
        {
            Debug.Log("Alert: High battery capacity");
        }

        // gas pressure 14 - 16 ------------------->
        if (p_h2o_g < 14)
        {
            Debug.Log("Alert: Low gas pressure");
        }

        if (p_h2o_g > 16)
        {
            Debug.Log("Alert: High gas pressure");
        }

        // liquid pressure 14 - 16 ------------------->
        if (p_h2o_l < 14)
        {
            Debug.Log("Alert: Low liquid pressure");
        }

        if (p_h2o_l > 16)
        {
            Debug.Log("Alert: High liquid pressure");
        }

        // SOP pressure 750 - 950 ------------------->
        if (p_sop < 750)
        {
            Debug.Log("Alert: Low sop pressure");
        }

        if (p_sop > 950)
        {
            Debug.Log("Alert: High sop pressure");
        }

        // SOP rate 0.5 - 1 ------------------------->
        if (rate_sop < 0.5)
        {
            Debug.Log("Alert: Low sop rate");
        }

        if (rate_sop > 1)
        {
            Debug.Log("Alert: High sop rate");
        }

        #endregion

    }//end of Update()

    void AddAlert(string nameOf, string messageOf)
    {
        GameObject toCheck = GameObject.Find(nameOf);
        if (toCheck == null)
        {
            alert = true;
            //All alerts except for the first one
            if (prefabCounter != 0)
            {
                prefabCounter++;
                GameObject newAlert;
                prefabOffset = new Vector3(prefabErrorMessage.transform.position.x, (prefabErrorMessage.transform.position.y) - prefabCounter * offset, prefabErrorMessage.transform.position.z);
                newAlert = Instantiate(prefabErrorMessage, prefabOffset, Quaternion.identity).gameObject;
                alerts[prefabCounter] = newAlert;
                newAlert.name = nameOf;
                newAlert.GetComponentInChildren<TMP_Text>().text = messageOf;
                newAlert.transform.parent = Warnings.transform;
            }
            else
            {
                //First alert
                prefabErrorMessage.GetComponentInChildren<TMP_Text>().text = messageOf;
                prefabErrorMessage.name = nameOf;
                prefabErrorMessage.transform.parent = Warnings.transform;
                prefabCounter++;
            }
        }
    }

    void RemoveAlert(string name)
    {
        int index = 0;
        GameObject currObject = alerts[index];
        GameObject toRemove;

        while (alerts[index] != null)
        {
            if (currObject.name != name)
            {
                index++;
                currObject = alerts[index];
            }

        }

        toRemove = currObject;
        Destroy(toRemove);
        prefabCounter -= 1;

        while (alerts[index + 1] != null)
        {
            GameObject nextAlert = alerts[index + 1];
            nextAlert.transform.position = new Vector3(nextAlert.transform.position.x, nextAlert.transform.position.y + offset, nextAlert.transform.position.z);
            index++;
        }


        if (alert && prefabCounter == 0)
        {
            alertButton.SetActive(false);
        }



        //Destroy(toRemove);
        //GameObject toRemove = GameObject.Find(name);
        //Destroy(toRemove);

        //int tmp;
        //while (alerts != null)
        //{
        //tmp = alerts;
        //    GameObject nextAlert = alerts[tmp + 1];
        //    nextAlert.transform.position = new Vector3(nextAlert.transform.position.x, nextAlert.transform.position.y + offset, nextAlert.transform.position.z);
        //    tmp++;
        //}
        //Destroy(toRemove);


        //prefabCounter -= 1;
        //Chek if afterlast removal, the alert list is empty
        //if (alert && prefabCounter == 0)
        //{
        //    alertButton.SetActive(false);
        //}
    }
}
