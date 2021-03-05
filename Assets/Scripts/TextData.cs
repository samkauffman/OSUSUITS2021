using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/*
 * 
 * Text is updated to the newest data from the telemetry stream
 * 
 * each TextMeshPro must be specified in unity whereever the script is used.
 *          TextMeshPro objects are not defined in script.
 * 
 */


public class TextData : MonoBehaviour
{
    /*
     * UIA Data Variables
     *  
     */
    /*
   public TextMeshPro emu1_text;
   public TextMeshPro emu2_text;
   public TextMeshPro o2_supply_pressure1_text; 
   public TextMeshPro o2_supply_pressure2_text;
   public TextMeshPro ev1_supply_text;
   public TextMeshPro ev2_supply_text;
   public TextMeshPro ev1_waste_text;
   public TextMeshPro ev2_waste_text;
   public TextMeshPro emu1_O2_text;
   public TextMeshPro emu2_O2_text;
   public TextMeshPro oxygen_supp_out1_text;
   public TextMeshPro oxygen_supp_out2_text;
   public TextMeshPro O2_Vent_text;
   public TextMeshPro depress_pump_text;
   */


    /*
     * Suits Data Variables
     *  
     */
    public TextMeshPro timer_text;
    public TextMeshPro ox_primary_text;
    //public TextMeshPro ox_secondary_text;
    public TextMeshPro heart_bpm_text;
    public TextMeshPro p_sub_text;
    public TextMeshPro p_suit_text;
    public TextMeshPro t_sub_text;
    public TextMeshPro v_fan_text;
    public TextMeshPro p_o2_text;
    public TextMeshPro rate_o2_text;
    public TextMeshPro cap_battery_text;
    public TextMeshPro p_h2o_g_text;
    public TextMeshPro p_h2o_l_text;
    public TextMeshPro p_sop_text;
    public TextMeshPro rate_sop_text;
    public TextMeshPro t_battery_text;
    public TextMeshPro t_oxygen_text;
    public TextMeshPro t_water_text;


    public JsonData jsonData;


    // Start is called before the first frame update
    void Start()
    {
        //jsonData object is defined from the JsonData.cs file for getting the suitData and UIAData
        jsonData = GameObject.FindWithTag("Controller").GetComponent<JsonData>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
         * UIA Data
         * 
         * Data is collected from Telemetry stream in JsonData.cs 
         * Text is updated as the data streams in from Telemtry
         */
        /*
       emu1_text.text = "EMU1 = " + jsonData.uiaData.emu1;
       emu2_text.text = "EMU2 = " + jsonData.uiaData.emu2;
       o2_supply_pressure1_text.text = "EMU1 O2 PRESSURE = " + jsonData.uiaData.o2_supply_pressure1 + " psi";
       o2_supply_pressure2_text.text = "EMU2 O2 PRESSURE = " + jsonData.uiaData.o2_supply_pressure1 + " psi";
       ev1_supply_text.text = "EV1 SUPPLY = " + jsonData.uiaData.ev1_supply;
       ev2_supply_text.text = "EV2 SUPPLY = " + jsonData.uiaData.ev2_supply;
       ev1_waste_text.text = "EV1 WASTE = " + jsonData.uiaData.ev1_waste;
       ev2_waste_text.text = "EV2 WATSE = " + jsonData.uiaData.ev2_waste;
       emu1_O2_text.text = "EV1 O2 = " + jsonData.uiaData.emu1_O2;
       emu2_O2_text.text = "EV2 O2 = " + jsonData.uiaData.emu2_O2;
       oxygen_supp_out1_text.text = "oxygen_supp_out1 = " + jsonData.uiaData.oxygen_supp_out1;
       oxygen_supp_out2_text.text = "oxygen_supp_out2 = " + jsonData.uiaData.oxygen_supp_out2;
       O2_Vent_text.text = "O2 VENT = " + jsonData.uiaData.O2_vent;
       depress_pump_text.text = "DEPRESS PUMP = " + jsonData.uiaData.depress_pump;
       */

        /*
         * Suit Data
         * 
         * Data is collected from Telemetry stream in JsonData.cs 
         * Text is updated as the data streams in from Telemtry
         */
        timer_text.text = "EVA Time: " + jsonData.suitData.timer;
        ox_primary_text.text = "Primary Oxygen: " + jsonData.suitData.ox_primary + " %";
        //ox_secondary_text.text = "Secondary Oxygen = " + jsonData.suitData.ox_secondary + " %";
        heart_bpm_text.text = "Heart Rate: " + jsonData.suitData.heart_bpm + " bpm";
        p_sub_text.text = "Sub Pressure: " + jsonData.suitData.p_sub + " psia";
        p_suit_text.text = "Suit Pressure: " + jsonData.suitData.p_suit + " psia";
        t_sub_text.text = "Temperature: " + jsonData.suitData.t_sub + " deg F";
        v_fan_text.text = "Fan Speed: " + jsonData.suitData.v_fan + " rpm";
        p_o2_text.text = "Oxygen Pressure: " + jsonData.suitData.p_o2 + " psia";
        rate_o2_text.text = "Oxygen Rate: " + jsonData.suitData.rate_o2 + "psi/min";
        cap_battery_text.text = "Battery Capacity: " + jsonData.suitData.cap_battery + " amp-hr";
        p_h2o_g_text.text = "H2O Gas Pressure: " + jsonData.suitData.p_h2o_g + " psia";
        p_h2o_l_text.text = "H2O Liquid Pressure: " + jsonData.suitData.p_h2o_l + " psia";
        p_sop_text.text = "SOP Pressure: " + jsonData.suitData.p_sop + " psia";
        rate_sop_text.text = "SOP Rate: " + jsonData.suitData.rate_sop + " psi/min";
        t_battery_text.text = "Time Left Battery: " + jsonData.suitData.t_battery;
        t_oxygen_text.text = "Time Left Oxygen: " + jsonData.suitData.t_oxygen;
        t_water_text.text = "Time Left Water " + jsonData.suitData.t_water;
    }
}
