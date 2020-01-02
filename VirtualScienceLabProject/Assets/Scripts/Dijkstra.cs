﻿
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Dijkstra : MonoBehaviour {

    private GameObject set_act_obj;
    private GameObject set_de_obj;

    // Use this for initialization
    void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	// Controller Input abfangen
    private void OnTriggerEnter(Collider other)
    {
		// Überprüfen welcher Buchstabe geklickt wurde
        switch (gameObject.name)
        {
            case "S":
			// Wenn S geklickt und S auch geklickt werden darf
                if (Load_Publics.s_active && !Load_Publics.s_clicked)
                {
					// Einfärbung
                    gameObject.GetComponent<Renderer>().material.color = Color.green;
					// Aktivierung nächster Bausteine
                    setActive("A");
                    setActive("B");
                    setActive("G");
                    Load_Publics.s_clicked = true;
                    Load_Publics.last_clicked = "S";
                    GameObject.Find("RESET").GetComponent<Renderer>().material.color = Color.red;
                }
                break;
            case "A":
                if(Load_Publics.a_active && !Load_Publics.a_clicked)
                {
                    gameObject.GetComponent<Renderer>().material.color = Color.green;
                    switch (Load_Publics.last_clicked)
                    {
                        case "S":
                            deactivate("G");
                            setActive("C");
                            Load_Publics.counter += 5;
                            break;
                        case "B":
                            Load_Publics.counter += 1;
                            break;
                        case "C":
                            deactivate("D");
                            deactivate("E");
                            Load_Publics.counter += 3;
                            break;
                    }
                    Load_Publics.a_clicked = true;
                    Load_Publics.last_clicked = "A";
                }
                break;
            case "B":
                if (Load_Publics.b_active && !Load_Publics.b_clicked)
                {
                    gameObject.GetComponent<Renderer>().material.color = Color.green;
                    switch (Load_Publics.last_clicked)
                    {
                        case "S":
                            setActive("C");
                            deactivate("G");
                            Load_Publics.counter += 2;
                            break;
                        case "A":
                            Load_Publics.counter += 1;
                            break;
                        case "C":
                            deactivate("D");
                            deactivate("E");
                            Load_Publics.counter += 7;
                            break;

                    }
                    Load_Publics.b_clicked = true;
                    Load_Publics.last_clicked = "B";
                }
                break;
            case "G":
                if (Load_Publics.g_active && !Load_Publics.g_clicked)
                {
                    gameObject.GetComponent<Renderer>().material.color = Color.green;
                    switch (Load_Publics.last_clicked)
                    {
                        case "S":
                            setActive("D");
                            deactivate("A");
                            deactivate("B");
                            Load_Publics.counter += 4;
                            break;
                        case "D":
                            deactivate("C");
                            deactivate("E");
                            deactivate("F");
                            Load_Publics.counter += 2;
                            break;

                    }
                    Load_Publics.g_clicked = true;
                    Load_Publics.last_clicked = "G";
                }
                break;
            case "C":
                if (Load_Publics.c_active && !Load_Publics.c_clicked)
                {
                    gameObject.GetComponent<Renderer>().material.color = Color.green;
                    switch (Load_Publics.last_clicked)
                    {
                        case "A":
                            setActive("D");
                            setActive("E");
                            Load_Publics.counter += 3;
                            break;
                        case "B":
                            setActive("D");
                            setActive("E");
                            Load_Publics.counter += 7;
                            break;
                        case "D":
                            setActive("A");
                            setActive("B");
                            deactivate("F");
                            Load_Publics.counter += 7;
                            break;
                        case "E":
                            setActive("A");
                            setActive("B");
                            deactivate("Z");
                            Load_Publics.counter += 6;
                            break;

                    }
                    Load_Publics.c_clicked = true;
                    Load_Publics.last_clicked = "C";
                }
                break;
            case "D":
                if (Load_Publics.d_active && !Load_Publics.d_clicked)
                {
                    gameObject.GetComponent<Renderer>().material.color = Color.green;
                    switch (Load_Publics.last_clicked)
                    {
                        case "G":
                            setActive("C");
                            setActive("E");
                            setActive("F");
                            Load_Publics.counter += 2;
                            break;
                        case "C":
                            setActive("E");
                            setActive("F");
                            setActive("G");
                            deactivate("A");
                            deactivate("B");
                            Load_Publics.counter += 7;
                            break;
                        case "E":
                            setActive("F");
                            setActive("G");
                            deactivate("Z");
                            Load_Publics.counter += 12;
                            break;
                        case "F":
                            setActive("E");
                            setActive("C");
                            setActive("G");
                            deactivate("Z");
                            Load_Publics.counter += 7;
                            break;

                    }
                    Load_Publics.d_clicked = true;
                    Load_Publics.last_clicked = "D";
                }
                break;
            case "E":
                if (Load_Publics.e_active && !Load_Publics.e_clicked)
                {
                    gameObject.GetComponent<Renderer>().material.color = Color.green;
                    switch (Load_Publics.last_clicked)
                    {
                        case "C":
                            setActive("Z");
                            deactivate("A");
                            deactivate("B");
                            Load_Publics.counter += 6;
                            break;
                        case "D":
                            setActive("Z");
                            deactivate("F");
                            Load_Publics.counter += 12;
                            break;

                    }
                    Load_Publics.e_clicked = true;
                    Load_Publics.last_clicked = "E";
                }
                break;
            case "F":
                if (Load_Publics.f_active && !Load_Publics.f_clicked)
                {
                    gameObject.GetComponent<Renderer>().material.color = Color.green;
                    switch (Load_Publics.last_clicked)
                    {
                        case "D":
                            setActive("Z");
                            deactivate("E");
                            deactivate("G");
                            deactivate("C");
                            Load_Publics.counter += 7;
                            break;

                    }
                    Load_Publics.f_clicked = true;
                    Load_Publics.last_clicked = "F";
                }
                break;
            case "Z":
                if (Load_Publics.z_active && !Load_Publics.z_clicked)
                {
                    gameObject.GetComponent<Renderer>().material.color = Color.green;
                    switch (Load_Publics.last_clicked)
                    {
                        case "E":
                            deactivate("C");
                            deactivate("D");
                            Load_Publics.counter += 7;
                            break;
                        case "F":
                            Load_Publics.counter += 11;
                            break;
                    }
                    Load_Publics.z_clicked = true;
                    Load_Publics.last_clicked = "Z";
                }
                break;

            case "RESET":
                gameObject.GetComponent<Renderer>().material.color = Color.green;
                reset();
                break;

        }
        Sev_Seg_Counter counti = new Sev_Seg_Counter();
        counti.setSevSegCount(Load_Publics.counter, "Zähler");
        Debug.Log(Load_Publics.counter);
    }

	// Aktivierungsscript für Buchstaben
    private void setActive(string name)
    {
        Debug.Log("Active: " + name);
        switch (name)
        {
            case "S":
                if (!Load_Publics.s_clicked)
                {
                    set_act_obj = GameObject.Find(name);
                    Load_Publics.s_active = true;
                }
                break;
            case "A":
                if (!Load_Publics.a_clicked)
                {
                    set_act_obj = GameObject.Find(name);
                    Load_Publics.a_active = true;
                }
                break;
            case "B":
                if (!Load_Publics.b_clicked)
                {
                    set_act_obj = GameObject.Find(name);
                    Load_Publics.b_active = true;
                }
                break;
            case "G":
                if (!Load_Publics.g_clicked)
                {
                    set_act_obj = GameObject.Find(name);
                    Load_Publics.g_active = true;
                }
                break;
            case "C":
                if (!Load_Publics.c_clicked)
                {
                    set_act_obj = GameObject.Find(name);
                    Load_Publics.c_active = true;
                }
                break;
            case "D":
                if (!Load_Publics.d_clicked)
                {
                    set_act_obj = GameObject.Find(name);
                    Load_Publics.d_active = true;
                }
                break;
            case "E":
                if (!Load_Publics.e_clicked)
                {
                    set_act_obj = GameObject.Find(name);
                    Load_Publics.e_active = true;
                }
                break;
            case "F":
                if (!Load_Publics.f_clicked)
                {
                    set_act_obj = GameObject.Find(name);
                    Load_Publics.f_active = true;
                }
                break;
            case "Z":
                if (!Load_Publics.z_clicked)
                {
                    set_act_obj = GameObject.Find(name);
                    Load_Publics.z_active = true;
                }
                break;
        }
        if (set_act_obj != null)
        {
            set_act_obj.GetComponent<Renderer>().material.color = Color.yellow;
        }
    }
	
	// Deaktivierungsscript für Buchstaben
    private void deactivate(string name)
    {
        Debug.Log("Deactivate: " + name);
        switch (name)
        {
            case "S":
                if (!Load_Publics.s_clicked)
                {
                    set_de_obj = GameObject.Find(name);
                    Load_Publics.s_active = false;
                }
                break;
            case "A":
                if (!Load_Publics.a_clicked)
                {
                    set_de_obj = GameObject.Find(name);
                    Load_Publics.a_active = false;
                }
                break;
            case "B":
                if (!Load_Publics.b_clicked)
                {
                    set_de_obj = GameObject.Find(name);
                    Load_Publics.b_active = false;
                }
                break;
            case "G":
                if (!Load_Publics.g_clicked)
                {
                    set_de_obj = GameObject.Find(name);
                    Load_Publics.g_active = false;
                }
                break;
            case "C":
                if (!Load_Publics.c_clicked)
                {
                    set_de_obj = GameObject.Find(name);
                    Load_Publics.c_active = false;
                }
                break;
            case "D":
                if (!Load_Publics.d_clicked)
                {
                    set_de_obj = GameObject.Find(name);
                    Load_Publics.d_active = false;
                }
                break;
            case "E":
                if (!Load_Publics.e_clicked)
                {
                    set_de_obj = GameObject.Find(name);
                    Load_Publics.e_active = false;
                }
                break;
            case "F":
                if (!Load_Publics.f_clicked)
                {
                    set_de_obj = GameObject.Find(name);
                    Load_Publics.f_active = false;
                }
                break;
            case "Z":
                if (!Load_Publics.z_clicked)
                {
                    set_de_obj = GameObject.Find(name);
                    Load_Publics.z_active = false;
                }
                break;
        }
        if(set_de_obj != null)
        {
            set_de_obj.GetComponent<Renderer>().material.color = Color.white;
        }
    }

	// Zurücksetzen aller Buchstaben und Counter
    private void reset()
    {
        GameObject.Find("S").GetComponent<Renderer>().material.color = Color.white;
        GameObject.Find("A").GetComponent<Renderer>().material.color = Color.white;
        GameObject.Find("B").GetComponent<Renderer>().material.color = Color.white;
        GameObject.Find("G").GetComponent<Renderer>().material.color = Color.white;
        GameObject.Find("C").GetComponent<Renderer>().material.color = Color.white;
        GameObject.Find("D").GetComponent<Renderer>().material.color = Color.white;
        GameObject.Find("E").GetComponent<Renderer>().material.color = Color.white;
        GameObject.Find("F").GetComponent<Renderer>().material.color = Color.white;
        GameObject.Find("Z").GetComponent<Renderer>().material.color = Color.white;
        Load_Publics.s_active = true;
        Load_Publics.a_active = false;
        Load_Publics.b_active = false;
        Load_Publics.g_active = false;
        Load_Publics.c_active = false;
        Load_Publics.d_active = false;
        Load_Publics.e_active = false;
        Load_Publics.f_active = false;
        Load_Publics.z_active = false;
        Load_Publics.r_active = false;
        Load_Publics.s_clicked = false;
        Load_Publics.a_clicked = false;
        Load_Publics.b_clicked = false;
        Load_Publics.g_clicked = false;
        Load_Publics.c_clicked = false;
        Load_Publics.d_clicked = false;
        Load_Publics.e_clicked = false;
        Load_Publics.f_clicked = false;
        Load_Publics.z_clicked = false;
        Load_Publics.r_clicked = false;
        Load_Publics.counter = 0;
        Load_Publics.last_clicked = "";
    }

}