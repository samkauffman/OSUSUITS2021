using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConvertingJSON : MonoBehaviour
{

    public TextAsset JSONTextFile;
    public GameObject outputText;
    TextMesh text;
    string _id;

    [System.Serializable]
    public class SuitDATA
    {
        public static string _id;
        public string time;
        public string timer;
        public string started_at;
        public string heart_bpm;
        public string p_sub;
        public string p_suit;
        public string t_sub;
        public string v_fan;
        public string p_o2;
        public string rate_o2;
        public string batteryPercent;
        public string battery_out;
        public string cap_battery;
        public string t_battery;
        public string p_h2o_g;
        public string p_h2o_l;
        public string p_sop;
        public string rate_sop;
        public string t_oxygenPrimary;
        public string t_oxygenSec;
        public string ox_primary;
        public string ox_secondary;
        public string t_oxygen;
        public string cap_water;
        public string t_water;
        public string __v;
    }
   
    [System.Serializable]

    public class AstronautList
    {
        public SuitDATA[] astronaut;
    }


    public AstronautList mySUIT = new AstronautList();

    // Start is called before the first frame update
    void Start()
    {
        mySUIT = JsonUtility.FromJson<AstronautList>(JSONTextFile.text);
        text = outputText.GetComponent<TextMesh>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "ID: " + _id;
    }
}
