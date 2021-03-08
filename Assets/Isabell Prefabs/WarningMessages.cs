using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

/*
 * 
 * Creates a slate and adds error messages to it when needed.
 * Needs to be placed on an empty game object in the scene
 * Make sure JsonData script is on same gameobject as this script
 * 
 * updated for mixed reality toolkit
 * 
 */

public class WarningMessages : MonoBehaviour
{
    public JsonData jsonData;

    public GameObject slate_prefab;
    GameObject slate_v_fan;
    TextMeshPro slate_v_fan_text;

    //position used to adjust text warnings from camera
    float xPosition = 0.06f;
    float yPosition;
    float zPosition = 0.6f;


    // Tracks is error has already been called out
    bool heart_bpm_bool = false; //Range: 80-100 bpm
    bool p_suit_bool = false; //Range: 2-4 psid
    bool p_sub_bool = false; //Range: 2-4 psia
    bool v_fan_bool = false; //Range: 10,000-40,000 rpm
    bool p_o2_bool = false; //Range:750-950 psia
    bool rate_o2_bool = false; //Range: 0.5-1 psi/min
    bool cap_battery_bool = false; //Range: 0-30 amp-hr
    bool p_h2o_g_bool = false; //Range: 14-16 psia
    bool p_h2o_l_bool = false; //Range: 14-16 psia
    bool t_sub_bool = false; //Range: -20-60 degrees fahrenheit??
    bool p_sop_bool = false; //Range:750-950 psia
    bool rate_sop_bool = false; //Range: 0.5-1 psi/min
    bool t_battery_bool = false; //Range: 0-10 hrs
    bool t_oxygen_bool = false; //Range: 0-10 hrs
    bool t_water_bool = false; //Range: 0-10 hrs


    // Start is called before the first frame update
    void Start()
    {
        jsonData = this.GetComponent<JsonData>();
    }

    // Update is called once per frame
    void Update()
    {
        //Heart Rate : Range: 80-100 bpm : heart_bpm_bool : heart_bpm
        if (double.Parse(jsonData.suitData.heart_bpm) < 80.0 && heart_bpm_bool == false)
        {
            if (slate_v_fan == null)
            {
                yPosition = 0.01f;
                //create slate
                CreateSlate();
            }
            //create text
            #region Create Text
            GameObject text1 = new GameObject();
            TextMeshPro text1_text = text1.AddComponent<TextMeshPro>();
            text1_text.color = Color.white;
            text1_text.fontSize = 44.75f;
            text1.transform.position = new Vector3(GameObject.FindGameObjectWithTag("MainCamera").transform.position.x - xPosition, GameObject.FindGameObjectWithTag("MainCamera").transform.position.y+yPosition, GameObject.FindGameObjectWithTag("MainCamera").transform.position.z+zPosition);
            text1.transform.localScale = new Vector3(0.006449357f, 0.009f, 0.03332061f);
            text1.GetComponent<RectTransform>().sizeDelta = new Vector2(60, 5); //width and height
            text1_text.text = "Heart Rate Low: " + jsonData.suitData.heart_bpm;
            #endregion
            yPosition -= 0.035f;
            heart_bpm_bool = true;
        }
        if (double.Parse(jsonData.suitData.heart_bpm) > 100.0 && heart_bpm_bool == false)
        {
            if (slate_v_fan == null)
            {
                yPosition = 0.01f;
                //create slate
                CreateSlate();
            }
            //create text
            #region Create Text
            GameObject text1 = new GameObject();
            TextMeshPro text1_text = text1.AddComponent<TextMeshPro>();
            text1_text.color = Color.white;
            text1_text.fontSize = 44.75f;
            text1.transform.position = new Vector3(GameObject.FindGameObjectWithTag("MainCamera").transform.position.x - xPosition, GameObject.FindGameObjectWithTag("MainCamera").transform.position.y + yPosition, GameObject.FindGameObjectWithTag("MainCamera").transform.position.z + zPosition);
            text1.transform.localScale = new Vector3(0.006449357f, 0.009f, 0.03332061f);
            text1.GetComponent<RectTransform>().sizeDelta = new Vector2(60, 5); //width and height
            text1_text.text = "Heart Rate High: " + jsonData.suitData.heart_bpm;
            #endregion
            yPosition -= 0.035f;
            heart_bpm_bool = true;
        }


        //Suit Pressure : Range: 2-4 psid : p_suit_bool : p_suit
        if (double.Parse(jsonData.suitData.p_suit) < 2.0 && p_suit_bool == false)
        {
            if (slate_v_fan == null)
            {
                yPosition = 0.01f;
                //create slate
                CreateSlate();
            }
            //create text
            #region Create Text
            GameObject text1 = new GameObject();
            TextMeshPro text1_text = text1.AddComponent<TextMeshPro>();
            text1_text.color = Color.white;
            text1_text.fontSize = 44.75f;
            text1.transform.position = new Vector3(GameObject.FindGameObjectWithTag("MainCamera").transform.position.x - xPosition, GameObject.FindGameObjectWithTag("MainCamera").transform.position.y + yPosition, GameObject.FindGameObjectWithTag("MainCamera").transform.position.z + zPosition);
            text1.transform.localScale = new Vector3(0.006449357f, 0.009f, 0.03332061f);
            text1.GetComponent<RectTransform>().sizeDelta = new Vector2(60, 5); //width and height
            text1_text.text = "Suit Pressure Low: " + jsonData.suitData.p_suit;
            #endregion
            yPosition -= 0.035f;
            p_suit_bool = true;
        }
        if (double.Parse(jsonData.suitData.p_suit) > 4.0 && p_suit_bool == false)
        {
            if (slate_v_fan == null)
            {
                yPosition = 0.01f;
                //create slate
                CreateSlate();
            }
            //create text
            #region Create Text
            GameObject text1 = new GameObject();
            TextMeshPro text1_text = text1.AddComponent<TextMeshPro>();
            text1_text.color = Color.white;
            text1_text.fontSize = 44.75f;
            text1.transform.position = new Vector3(GameObject.FindGameObjectWithTag("MainCamera").transform.position.x - xPosition, GameObject.FindGameObjectWithTag("MainCamera").transform.position.y + yPosition, GameObject.FindGameObjectWithTag("MainCamera").transform.position.z + zPosition);
            text1.transform.localScale = new Vector3(0.006449357f, 0.009f, 0.03332061f);
            text1.GetComponent<RectTransform>().sizeDelta = new Vector2(60, 5); //width and height
            text1_text.text = "Suit Pressure High: " + jsonData.suitData.p_suit;
            #endregion
            yPosition -= 0.035f;
            p_suit_bool = true;
        }


        //Sub Pressure : Range: 2-4 psia : p_sub_bool : p_sub
        if (double.Parse(jsonData.suitData.p_sub) < 2.0 && p_sub_bool == false)
        {
            if (slate_v_fan == null)
            {
                yPosition = 0.01f;
                //create slate
                CreateSlate();
            }
            //create text
            #region Create Text
            GameObject text1 = new GameObject();
            TextMeshPro text1_text = text1.AddComponent<TextMeshPro>();
            text1_text.color = Color.white;
            text1_text.fontSize = 44.75f;
            text1.transform.position = new Vector3(GameObject.FindGameObjectWithTag("MainCamera").transform.position.x - xPosition, GameObject.FindGameObjectWithTag("MainCamera").transform.position.y + yPosition, GameObject.FindGameObjectWithTag("MainCamera").transform.position.z + zPosition);
            text1.transform.localScale = new Vector3(0.006449357f, 0.009f, 0.03332061f);
            text1.GetComponent<RectTransform>().sizeDelta = new Vector2(60, 5); //width and height
            text1_text.text = "Sub Pressure Low: " + jsonData.suitData.p_sub;
            #endregion
            yPosition -= 0.035f;
            p_sub_bool = true;
        }
        if (double.Parse(jsonData.suitData.p_sub) > 4.0 && p_sub_bool == false)
        {
            if (slate_v_fan == null)
            {
                yPosition = 0.01f;
                //create slate
                CreateSlate();
            }
            //create text
            #region Create Text
            GameObject text1 = new GameObject();
            TextMeshPro text1_text = text1.AddComponent<TextMeshPro>();
            text1_text.color = Color.white;
            text1_text.fontSize = 44.75f;
            text1.transform.position = new Vector3(GameObject.FindGameObjectWithTag("MainCamera").transform.position.x - xPosition, GameObject.FindGameObjectWithTag("MainCamera").transform.position.y + yPosition, GameObject.FindGameObjectWithTag("MainCamera").transform.position.z + zPosition);
            text1.transform.localScale = new Vector3(0.006449357f, 0.009f, 0.03332061f);
            text1.GetComponent<RectTransform>().sizeDelta = new Vector2(60, 5); //width and height
            text1_text.text = "Sub Pressure High: " + jsonData.suitData.p_sub;
            #endregion
            yPosition -= 0.035f;
            p_sub_bool = true;
        }


        //Fan Tachometer : Range: 10,000-40,000 rpm : v_fan_bool : v_fan
        if (double.Parse(jsonData.suitData.v_fan) < 10000.0 && v_fan_bool == false)
        {
            if (slate_v_fan == null)
            {
                yPosition = 0.01f;
                //create slate
                CreateSlate();
            }
            //create text
            #region Create Text
            GameObject text1 = new GameObject();
            TextMeshPro text1_text = text1.AddComponent<TextMeshPro>();
            text1_text.color = Color.white;
            text1_text.fontSize = 44.75f;
            text1.transform.position = new Vector3(GameObject.FindGameObjectWithTag("MainCamera").transform.position.x - xPosition, GameObject.FindGameObjectWithTag("MainCamera").transform.position.y + yPosition, GameObject.FindGameObjectWithTag("MainCamera").transform.position.z + zPosition);
            text1.transform.localScale = new Vector3(0.006449357f, 0.009f, 0.03332061f);
            text1.GetComponent<RectTransform>().sizeDelta = new Vector2(60, 5); //width and height
            text1_text.text = "Fan Speed Low: " + jsonData.suitData.v_fan;
            #endregion
            yPosition -= 0.035f;
            v_fan_bool = true;
        }
        if (double.Parse(jsonData.suitData.v_fan) > 40000.0 && v_fan_bool == false)
        {
            if (slate_v_fan == null)
            {
                yPosition = 0.01f;
                //create slate
                CreateSlate();
            }
            //create text
            #region Create Text
            GameObject text1 = new GameObject();
            TextMeshPro text1_text = text1.AddComponent<TextMeshPro>();
            text1_text.color = Color.white;
            text1_text.fontSize = 44.75f;
            text1.transform.position = new Vector3(GameObject.FindGameObjectWithTag("MainCamera").transform.position.x - xPosition, GameObject.FindGameObjectWithTag("MainCamera").transform.position.y + yPosition, GameObject.FindGameObjectWithTag("MainCamera").transform.position.z + zPosition);
            text1.transform.localScale = new Vector3(0.006449357f, 0.009f, 0.03332061f);
            text1.GetComponent<RectTransform>().sizeDelta = new Vector2(60, 5); //width and height
            text1_text.text = "Fan Speed High: " + jsonData.suitData.v_fan;
            #endregion
            yPosition -= 0.035f;
            v_fan_bool = true;
        }


        //O2 Pressure : Range:750-950 psia : p_o2_bool : p_o2
        if (double.Parse(jsonData.suitData.p_o2) < 750.0 && p_o2_bool == false)
        {
            if (slate_v_fan == null)
            {
                yPosition = 0.01f;
                //create slate
                CreateSlate();
            }
            //create text
            #region Create Text
            GameObject text1 = new GameObject();
            TextMeshPro text1_text = text1.AddComponent<TextMeshPro>();
            text1_text.color = Color.white;
            text1_text.fontSize = 44.75f;
            text1.transform.position = new Vector3(GameObject.FindGameObjectWithTag("MainCamera").transform.position.x - xPosition, GameObject.FindGameObjectWithTag("MainCamera").transform.position.y + yPosition, GameObject.FindGameObjectWithTag("MainCamera").transform.position.z + zPosition);
            text1.transform.localScale = new Vector3(0.006449357f, 0.009f, 0.03332061f);
            text1.GetComponent<RectTransform>().sizeDelta = new Vector2(60, 5); //width and height
            text1_text.text = "Oxygen Pressure Low: " + jsonData.suitData.p_o2;
            #endregion
            yPosition -= 0.035f;
            p_o2_bool = true;
        }
        if (double.Parse(jsonData.suitData.p_o2) > 950.0 && p_o2_bool == false)
        {
            if (slate_v_fan == null)
            {
                yPosition = 0.01f;
                //create slate
                CreateSlate();
            }
            //create text
            #region Create Text
            GameObject text1 = new GameObject();
            TextMeshPro text1_text = text1.AddComponent<TextMeshPro>();
            text1_text.color = Color.white;
            text1_text.fontSize = 44.75f;
            text1.transform.position = new Vector3(GameObject.FindGameObjectWithTag("MainCamera").transform.position.x - xPosition, GameObject.FindGameObjectWithTag("MainCamera").transform.position.y + yPosition, GameObject.FindGameObjectWithTag("MainCamera").transform.position.z + zPosition);
            text1.transform.localScale = new Vector3(0.006449357f, 0.009f, 0.03332061f);
            text1.GetComponent<RectTransform>().sizeDelta = new Vector2(60, 5); //width and height
            text1_text.text = "Oxygen Pressure High: " + jsonData.suitData.p_o2;
            #endregion
            yPosition -= 0.035f;
            p_o2_bool = true;
        }


        //O2 Rate : Range: 0.5-1 psi/min : rate_o2_bool : rate_o2
        if (double.Parse(jsonData.suitData.rate_o2) < 0.5 && rate_o2_bool == false)
        {
            if (slate_v_fan == null)
            {
                yPosition = 0.01f;
                //create slate
                CreateSlate();
            }
            //create text
            #region Create Text
            GameObject text1 = new GameObject();
            TextMeshPro text1_text = text1.AddComponent<TextMeshPro>();
            text1_text.color = Color.white;
            text1_text.fontSize = 44.75f;
            text1.transform.position = new Vector3(GameObject.FindGameObjectWithTag("MainCamera").transform.position.x - xPosition, GameObject.FindGameObjectWithTag("MainCamera").transform.position.y + yPosition, GameObject.FindGameObjectWithTag("MainCamera").transform.position.z + zPosition);
            text1.transform.localScale = new Vector3(0.006449357f, 0.009f, 0.03332061f);
            text1.GetComponent<RectTransform>().sizeDelta = new Vector2(60, 5); //width and height
            text1_text.text = "Oxygen Rate Low: " + jsonData.suitData.rate_o2;
            #endregion
            yPosition -= 0.035f;
            rate_o2_bool = true;
        }
        if (double.Parse(jsonData.suitData.rate_o2) > 1.0 && rate_o2_bool == false)
        {
            if (slate_v_fan == null)
            {
                yPosition = 0.01f;
                //create slate
                CreateSlate();
            }
            //create text
            #region Create Text
            GameObject text1 = new GameObject();
            TextMeshPro text1_text = text1.AddComponent<TextMeshPro>();
            text1_text.color = Color.white;
            text1_text.fontSize = 44.75f;
            text1.transform.position = new Vector3(GameObject.FindGameObjectWithTag("MainCamera").transform.position.x - xPosition, GameObject.FindGameObjectWithTag("MainCamera").transform.position.y + yPosition, GameObject.FindGameObjectWithTag("MainCamera").transform.position.z + zPosition);
            text1.transform.localScale = new Vector3(0.006449357f, 0.009f, 0.03332061f);
            text1.GetComponent<RectTransform>().sizeDelta = new Vector2(60, 5); //width and height
            text1_text.text = "Oxygen Rate High: " + jsonData.suitData.rate_o2;
            #endregion
            yPosition -= 0.035f;
            rate_o2_bool = true;
        }


        //Battery Capacity : Range: 0-30 amp-hr : cap_battery_bool : cap_battery
        if (double.Parse(jsonData.suitData.cap_battery) < 5.0 && cap_battery_bool == false)
        {
            if (slate_v_fan == null)
            {
                yPosition = 0.01f;
                //create slate
                CreateSlate();
            }
            //create text
            #region Create Text
            GameObject text1 = new GameObject();
            TextMeshPro text1_text = text1.AddComponent<TextMeshPro>();
            text1_text.color = Color.white;
            text1_text.fontSize = 44.75f;
            text1.transform.position = new Vector3(GameObject.FindGameObjectWithTag("MainCamera").transform.position.x - xPosition, GameObject.FindGameObjectWithTag("MainCamera").transform.position.y + yPosition, GameObject.FindGameObjectWithTag("MainCamera").transform.position.z + zPosition);
            text1.transform.localScale = new Vector3(0.006449357f, 0.009f, 0.03332061f);
            text1.GetComponent<RectTransform>().sizeDelta = new Vector2(60, 5); //width and height
            text1_text.text = "Battery Capacity Low: " + jsonData.suitData.cap_battery;
            #endregion
            yPosition -= 0.035f;
            cap_battery_bool = true;
        }
        if (double.Parse(jsonData.suitData.cap_battery) > 30.0 && cap_battery_bool == false)
        {
            if (slate_v_fan == null)
            {
                yPosition = 0.01f;
                //create slate
                CreateSlate();
            }
            //create text
            #region Create Text
            GameObject text1 = new GameObject();
            TextMeshPro text1_text = text1.AddComponent<TextMeshPro>();
            text1_text.color = Color.white;
            text1_text.fontSize = 44.75f;
            text1.transform.position = new Vector3(GameObject.FindGameObjectWithTag("MainCamera").transform.position.x - xPosition, GameObject.FindGameObjectWithTag("MainCamera").transform.position.y + yPosition, GameObject.FindGameObjectWithTag("MainCamera").transform.position.z + zPosition);
            text1.transform.localScale = new Vector3(0.006449357f, 0.009f, 0.03332061f);
            text1.GetComponent<RectTransform>().sizeDelta = new Vector2(60, 5); //width and height
            text1_text.text = "Battery Capacity High: " + jsonData.suitData.cap_battery;
            #endregion
            yPosition -= 0.035f;
            cap_battery_bool = true;
        }


        //H2O Gas Pressure : Range: 14-16 psia : p_h2o_g_bool : p_h2o_g
        if (double.Parse(jsonData.suitData.p_h2o_g) < 14.0 && p_h2o_g_bool == false)
        {
            if (slate_v_fan == null)
            {
                yPosition = 0.01f;
                //create slate
                CreateSlate();
            }
            //create text
            #region Create Text
            GameObject text1 = new GameObject();
            TextMeshPro text1_text = text1.AddComponent<TextMeshPro>();
            text1_text.color = Color.white;
            text1_text.fontSize = 44.75f;
            text1.transform.position = new Vector3(GameObject.FindGameObjectWithTag("MainCamera").transform.position.x - xPosition, GameObject.FindGameObjectWithTag("MainCamera").transform.position.y + yPosition, GameObject.FindGameObjectWithTag("MainCamera").transform.position.z + zPosition);
            text1.transform.localScale = new Vector3(0.006449357f, 0.009f, 0.03332061f);
            text1.GetComponent<RectTransform>().sizeDelta = new Vector2(60, 5); //width and height
            text1_text.text = "Water Vapor Pressure Low: " + jsonData.suitData.p_h2o_g;
            #endregion
            yPosition -= 0.035f;
            p_h2o_g_bool = true;
        }
        if (double.Parse(jsonData.suitData.p_h2o_g) > 16.0 && p_h2o_g_bool == false)
        {
            if (slate_v_fan == null)
            {
                yPosition = 0.01f;
                //create slate
                CreateSlate();
            }
            //create text
            #region Create Text
            GameObject text1 = new GameObject();
            TextMeshPro text1_text = text1.AddComponent<TextMeshPro>();
            text1_text.color = Color.white;
            text1_text.fontSize = 44.75f;
            text1.transform.position = new Vector3(GameObject.FindGameObjectWithTag("MainCamera").transform.position.x - xPosition, GameObject.FindGameObjectWithTag("MainCamera").transform.position.y + yPosition, GameObject.FindGameObjectWithTag("MainCamera").transform.position.z + zPosition);
            text1.transform.localScale = new Vector3(0.006449357f, 0.009f, 0.03332061f);
            text1.GetComponent<RectTransform>().sizeDelta = new Vector2(60, 5); //width and height
            text1_text.text = "Water Vapor Pressure High: " + jsonData.suitData.p_h2o_g;
            #endregion
            yPosition -= 0.035f;
            p_h2o_g_bool = true;
        }


        //H2O Liquid Pressure : Range: 14-16 psia : p_h2o_l_bool : p_h2o_l
        if (double.Parse(jsonData.suitData.p_h2o_l) < 14.0 && p_h2o_l_bool == false)
        {
            if (slate_v_fan == null)
            {
                yPosition = 0.01f;
                //create slate
                CreateSlate();
            }
            //create text
            #region Create Text
            GameObject text1 = new GameObject();
            TextMeshPro text1_text = text1.AddComponent<TextMeshPro>();
            text1_text.color = Color.white;
            text1_text.fontSize = 44.75f;
            text1.transform.position = new Vector3(GameObject.FindGameObjectWithTag("MainCamera").transform.position.x - xPosition, GameObject.FindGameObjectWithTag("MainCamera").transform.position.y + yPosition, GameObject.FindGameObjectWithTag("MainCamera").transform.position.z + zPosition);
            text1.transform.localScale = new Vector3(0.006449357f, 0.009f, 0.03332061f);
            text1.GetComponent<RectTransform>().sizeDelta = new Vector2(60, 5); //width and height
            text1_text.text = "Liquid Water Pressure Low: " + jsonData.suitData.p_h2o_l;
            #endregion
            yPosition -= 0.035f;
            p_h2o_l_bool = true;
        }
        if (double.Parse(jsonData.suitData.p_h2o_l) > 16.0 && p_h2o_l_bool == false)
        {
            if (slate_v_fan == null)
            {
                yPosition = 0.01f;
                //create slate
                CreateSlate();
            }
            //create text
            #region Create Text
            GameObject text1 = new GameObject();
            TextMeshPro text1_text = text1.AddComponent<TextMeshPro>();
            text1_text.color = Color.white;
            text1_text.fontSize = 44.75f;
            text1.transform.position = new Vector3(GameObject.FindGameObjectWithTag("MainCamera").transform.position.x - xPosition, GameObject.FindGameObjectWithTag("MainCamera").transform.position.y + yPosition, GameObject.FindGameObjectWithTag("MainCamera").transform.position.z + zPosition);
            text1.transform.localScale = new Vector3(0.006449357f, 0.009f, 0.03332061f);
            text1.GetComponent<RectTransform>().sizeDelta = new Vector2(60, 5); //width and height
            text1_text.text = "Liquid Water Pressure High: " + jsonData.suitData.p_h2o_l;
            #endregion
            yPosition -= 0.035f;
            p_h2o_l_bool = true;
        }


        //Temperature : Range -10 - 60 Fahrenheit : t_sub_bool : t_sub
        //found cases from -9 to 8 then an average of 50 degrees.
        if (double.Parse(jsonData.suitData.t_sub) < -10.0 && t_sub_bool == false)
        {
            if (slate_v_fan == null)
            {
                yPosition = 0.01f;
                //create slate
                CreateSlate();
            }
            //create text
            #region Create Text
            GameObject text1 = new GameObject();
            TextMeshPro text1_text = text1.AddComponent<TextMeshPro>();
            text1_text.color = Color.white;
            text1_text.fontSize = 44.75f;
            text1.transform.position = new Vector3(GameObject.FindGameObjectWithTag("MainCamera").transform.position.x - xPosition, GameObject.FindGameObjectWithTag("MainCamera").transform.position.y + yPosition, GameObject.FindGameObjectWithTag("MainCamera").transform.position.z + zPosition);
            text1.transform.localScale = new Vector3(0.006449357f, 0.009f, 0.03332061f);
            text1.GetComponent<RectTransform>().sizeDelta = new Vector2(60, 5); //width and height
            text1_text.text = "Temperature Low: " + jsonData.suitData.t_sub;
            #endregion
            yPosition -= 0.035f;
            t_sub_bool = true;
        }
        if (double.Parse(jsonData.suitData.t_sub) > 60.0 && t_sub_bool == false)
        {
            if (slate_v_fan == null)
            {
                yPosition = 0.01f;
                //create slate
                CreateSlate();
            }
            //create text
            #region Create Text
            GameObject text1 = new GameObject();
            TextMeshPro text1_text = text1.AddComponent<TextMeshPro>();
            text1_text.color = Color.white;
            text1_text.fontSize = 44.75f;
            text1.transform.position = new Vector3(GameObject.FindGameObjectWithTag("MainCamera").transform.position.x - xPosition, GameObject.FindGameObjectWithTag("MainCamera").transform.position.y + yPosition, GameObject.FindGameObjectWithTag("MainCamera").transform.position.z + zPosition);
            text1.transform.localScale = new Vector3(0.006449357f, 0.009f, 0.03332061f);
            text1.GetComponent<RectTransform>().sizeDelta = new Vector2(60, 5); //width and height
            text1_text.text = "Temperature High: " + jsonData.suitData.t_sub;
            #endregion
            yPosition -= 0.035f;
            t_sub_bool = true;
        }


        //SOP Pressure : Range:750-950 psia : p_sop_bool : p_sop
        if (double.Parse(jsonData.suitData.p_sop) < 750.0 && p_sop_bool == false)
        {
            if (slate_v_fan == null)
            {
                yPosition = 0.01f;
                //create slate
                CreateSlate();
            }
            //create text
            #region Create Text
            GameObject text1 = new GameObject();
            TextMeshPro text1_text = text1.AddComponent<TextMeshPro>();
            text1_text.color = Color.white;
            text1_text.fontSize = 44.75f;
            text1.transform.position = new Vector3(GameObject.FindGameObjectWithTag("MainCamera").transform.position.x - xPosition, GameObject.FindGameObjectWithTag("MainCamera").transform.position.y + yPosition, GameObject.FindGameObjectWithTag("MainCamera").transform.position.z + zPosition);
            text1.transform.localScale = new Vector3(0.006449357f, 0.009f, 0.03332061f);
            text1.GetComponent<RectTransform>().sizeDelta = new Vector2(60, 5); //width and height
            text1_text.text = "SOP Pressure Low: " + jsonData.suitData.p_sop;
            #endregion
            yPosition -= 0.035f;
            p_sop_bool = true;
        }
        if (double.Parse(jsonData.suitData.p_sop) > 950.0 && p_sop_bool == false)
        {
            if (slate_v_fan == null)
            {
                yPosition = 0.01f;
                //create slate
                CreateSlate();
            }
            //create text
            #region Create Text
            GameObject text1 = new GameObject();
            TextMeshPro text1_text = text1.AddComponent<TextMeshPro>();
            text1_text.color = Color.white;
            text1_text.fontSize = 44.75f;
            text1.transform.position = new Vector3(GameObject.FindGameObjectWithTag("MainCamera").transform.position.x - xPosition, GameObject.FindGameObjectWithTag("MainCamera").transform.position.y + yPosition, GameObject.FindGameObjectWithTag("MainCamera").transform.position.z + zPosition);
            text1.transform.localScale = new Vector3(0.006449357f, 0.009f, 0.03332061f);
            text1.GetComponent<RectTransform>().sizeDelta = new Vector2(60, 5); //width and height
            text1_text.text = "SOP Pressure High: " + jsonData.suitData.p_sop;
            #endregion
            yPosition -= 0.035f;
            p_sop_bool = true;
        }


        //SOP Rate : Range: 0.5-1 psi/min : rate_sop_bool : rate_sop
        if (double.Parse(jsonData.suitData.rate_sop) < 0.5 && rate_sop_bool == false)
        {
            if (slate_v_fan == null)
            {
                yPosition = 0.01f;
                //create slate
                CreateSlate();
            }
            //create text
            #region Create Text
            GameObject text1 = new GameObject();
            TextMeshPro text1_text = text1.AddComponent<TextMeshPro>();
            text1_text.color = Color.white;
            text1_text.fontSize = 44.75f;
            text1.transform.position = new Vector3(GameObject.FindGameObjectWithTag("MainCamera").transform.position.x - xPosition, GameObject.FindGameObjectWithTag("MainCamera").transform.position.y + yPosition, GameObject.FindGameObjectWithTag("MainCamera").transform.position.z + zPosition);
            text1.transform.localScale = new Vector3(0.006449357f, 0.009f, 0.03332061f);
            text1.GetComponent<RectTransform>().sizeDelta = new Vector2(60, 5); //width and height
            text1_text.text = "SOP Rate Low: " + jsonData.suitData.rate_sop;
            #endregion
            yPosition -= 0.035f;
            rate_sop_bool = true;
        }
        if (double.Parse(jsonData.suitData.rate_sop) > 1.0 && rate_sop_bool == false)
        {
            if (slate_v_fan == null)
            {
                yPosition = 0.01f;
                //create slate
                CreateSlate();
            }
            //create text
            #region Create Text
            GameObject text1 = new GameObject();
            TextMeshPro text1_text = text1.AddComponent<TextMeshPro>();
            text1_text.color = Color.white;
            text1_text.fontSize = 44.75f;
            text1.transform.position = new Vector3(GameObject.FindGameObjectWithTag("MainCamera").transform.position.x - xPosition, GameObject.FindGameObjectWithTag("MainCamera").transform.position.y + yPosition, GameObject.FindGameObjectWithTag("MainCamera").transform.position.z + zPosition);
            text1.transform.localScale = new Vector3(0.006449357f, 0.009f, 0.03332061f);
            text1.GetComponent<RectTransform>().sizeDelta = new Vector2(60, 5); //width and height
            text1_text.text = "SOP Rate High: " + jsonData.suitData.rate_sop;
            #endregion
            yPosition -= 0.035f;
            rate_sop_bool = true;
        }


        //get t_battery time to a comparable number 00:00:00
        string battery = jsonData.suitData.t_battery.Substring(0, 2) + jsonData.suitData.t_battery.Substring(3, 2) + jsonData.suitData.t_battery.Substring(6,2);
        //Battery Time Left : Range: 0-10 hrs : t_battery_bool : t_battery
        //2 hrs = 020,000
        if (double.Parse(battery) < 20000.0 && t_battery_bool == false)
        {
            if (slate_v_fan == null)
            {
                yPosition = 0.01f;
                //create slate
                CreateSlate();
            }
            //create text
            #region Create Text
            GameObject text1 = new GameObject();
            TextMeshPro text1_text = text1.AddComponent<TextMeshPro>();
            text1_text.color = Color.white;
            text1_text.fontSize = 44.75f;
            text1.transform.position = new Vector3(GameObject.FindGameObjectWithTag("MainCamera").transform.position.x - xPosition, GameObject.FindGameObjectWithTag("MainCamera").transform.position.y + yPosition, GameObject.FindGameObjectWithTag("MainCamera").transform.position.z + zPosition);
            text1.transform.localScale = new Vector3(0.006449357f, 0.009f, 0.03332061f);
            text1.GetComponent<RectTransform>().sizeDelta = new Vector2(60, 5); //width and height
            text1_text.text = "Battery Life Low: " + jsonData.suitData.t_battery;
            #endregion
            yPosition -= 0.035f;
            t_battery_bool = true;
        }


        //get t_battery time to a comparable number 00:00:00
        string oxygen = jsonData.suitData.t_oxygen.Substring(0, 2) + jsonData.suitData.t_oxygen.Substring(3, 2) + jsonData.suitData.t_oxygen.Substring(6, 2);
        //O2 Time Left : Range: 0-10 hrs : t_oxygen_bool : t_oxygen
        //2 hrs = 020,000
        if (double.Parse(oxygen) < 20000.0 && t_oxygen_bool == false)
        {
            if (slate_v_fan == null)
            {
                yPosition = 0.01f;
                //create slate
                CreateSlate();
            }
            //create text
            #region Create Text
            GameObject text1 = new GameObject();
            TextMeshPro text1_text = text1.AddComponent<TextMeshPro>();
            text1_text.color = Color.white;
            text1_text.fontSize = 44.75f;
            text1.transform.position = new Vector3(GameObject.FindGameObjectWithTag("MainCamera").transform.position.x - xPosition, GameObject.FindGameObjectWithTag("MainCamera").transform.position.y + yPosition, GameObject.FindGameObjectWithTag("MainCamera").transform.position.z + zPosition);
            text1.transform.localScale = new Vector3(0.006449357f, 0.009f, 0.03332061f);
            text1.GetComponent<RectTransform>().sizeDelta = new Vector2(60, 5); //width and height
            text1_text.text = "Oxygen Life Low: " + jsonData.suitData.t_oxygen;
            #endregion
            yPosition -= 0.035f;
            t_oxygen_bool = true;
        }


        //get t_battery time to a comparable number 00:00:00
        string water = jsonData.suitData.t_water.Substring(0, 2) + jsonData.suitData.t_water.Substring(3, 2) + jsonData.suitData.t_water.Substring(6, 2);
        //H2O Left : Range: 0-10 hrs : t_water_bool : t_water
        //2 hrs = 020,000
        if (double.Parse(water) < 20000.0 && t_water_bool == false)
        {
            if (slate_v_fan == null)
            {
                yPosition = 0.01f;
                //create slate
                CreateSlate();
            }
            //create text
            #region Create Text
            GameObject text1 = new GameObject();
            TextMeshPro text1_text = text1.AddComponent<TextMeshPro>();
            text1_text.color = Color.white;
            text1_text.fontSize = 44.75f;
            text1.transform.position = new Vector3(GameObject.FindGameObjectWithTag("MainCamera").transform.position.x - xPosition, GameObject.FindGameObjectWithTag("MainCamera").transform.position.y + yPosition, GameObject.FindGameObjectWithTag("MainCamera").transform.position.z + zPosition);
            text1.transform.localScale = new Vector3(0.006449357f, 0.009f, 0.03332061f);
            text1.GetComponent<RectTransform>().sizeDelta = new Vector2(60, 5); //width and height
            text1_text.text = "Water Life Low: " + jsonData.suitData.t_water;
            #endregion
            yPosition -= 0.035f;
            t_water_bool = true;
        }
    }

    void CreateSlate()
    {
        
        //var direction = headRay.direction;
        //var origin = headRay.origin;
        //var position = origin + direction * 2.0f;

        Vector3 position = new Vector3(GameObject.FindGameObjectWithTag("MainCamera").transform.position.x, GameObject.FindGameObjectWithTag("MainCamera").transform.position.y, GameObject.FindGameObjectWithTag("MainCamera").transform.position.z+.6f);

        slate_v_fan = (GameObject)Instantiate(slate_prefab, position, Quaternion.identity);
        GameObject slate_v_fan_text = slate_v_fan.transform.GetChild(0).GetChild(0).gameObject;
        slate_v_fan_text.GetComponent<TextMeshPro>().text = "Warning";
        slate_v_fan_text.GetComponent<TextMeshPro>().fontSize = 20;
    }
}
