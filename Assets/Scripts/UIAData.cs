using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 
 * DO NOT CHANGE DATA
 * 
 * This class holds all of the UIA data recieved by Telemetry Stream
 *			Data is put into this class by JsonData.cs and updated continuously 
 * 
 */

[System.Serializable]
public class UIAData 
{
    public string emu1 = "";

    public string emu2 = "";

    public string o2_supply_pressure1 = "";

    public string o2_supply_pressure2 = "";

    public string ev1_supply = "";

    public string ev2_supply = "";

    public string ev1_waste = "";

    public string ev2_waste = "";

    public string emu1_O2 = "";

    public string emu2_O2 = "";

    public string oxygen_supp_out1 = "";

    public string oxygen_supp_out2 = "";

    public string O2_vent = "";

    public string depress_pump = "";

}
