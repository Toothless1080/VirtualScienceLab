﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		// Drehung berechnen und umsetzen
        float rot_speed = Load_Publics.RemapTemp((float)Load_Publics.Temperatur, Load_Publics.Temp_Min, Load_Publics.Temp_Max, Load_Publics.Map_Temp_Min, Load_Publics.Map_Temp_Max);
        transform.Rotate(new Vector3(15, 30, 45) * rot_speed);
    }
}