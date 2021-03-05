using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 
 * DO NOT CHANGE DATA
 * 
 * This class holds all of the suit data recieved by Telemetry Stream
 *			Data is put into this class by JsonData.cs and updated continuously 
 * 
 */

[System.Serializable]
public class SuitData
{
	//EVA TIME - duration of time from start
	public string timer = "";

	//Primary Oxygen - percentage of O2 left in primary
	public string ox_primary = "";

	//Secondary Oxygen - percentage of O2 left in secondary
	public string ox_secondary = "";

	//Heart Rate - in bpm
		//Range: 80-100 bpm
	public string heart_bpm = "";

	//Suit Pressure - Pressure in space suit
		//Range: 2-4 psid
	public string p_suit = "";

	//Sub Pressure - Pressure in External Environment
		//Range: 2-4 psia
	public string p_sub = "";

	//Fan Tachometer - Speed of cooling fan
		//Range: 10,000-40,000 psia
	public string v_fan = "";

	//O2 Pressure - pressure inside of O2 Tank
		//Range:750-950 psia
	public string p_o2 = "";

	//O2 Rate - Flowrate of Primary O2 pack
		//Range: 0.5-1 psi/min
	public string rate_o2 = "";

	//Battery Capacity - total capacity of battery
		//Range: 0-30 amp-hr
	public string cap_battery = "";

	//H2O Gas Pressure - Gas Pressure from H2O system
		//Range: 14-16 psia
	public string p_h2o_g = "";

	//H2O Liquid Pressure - Liquid pressure from H2O system
		//Range: 14-16 psia
	public string p_h2o_l = "";

	//Temperature - External Environmental Temp
	public string t_sub = "";

	//SOP Pressure - Pressure inside secondary O2 pack
		//Range:750-950 psia
	public string p_sop = "";

	//SOP Rate - Flowrate of secondary O2 pack
		//Range: 0.5-1 psi/min
	public string rate_sop = "";

	//Battery Time Left - remaning battery time
		//Range: 0-10 hrs
	public string t_battery = "";

	//O2 Time Left - Remaing O2 Time
		//Range: 0-10 hrs
	public string t_oxygen = "";

	//H2O Left - Remaining time water resource are available
		//Range: 0-10 hrs
	public string t_water = ""; 
}
