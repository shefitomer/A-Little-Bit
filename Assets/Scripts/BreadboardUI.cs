﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreadboardUI : MonoBehaviour
{
	Breadboard breadboard;
    // Start is called before the first frame update
    void Start()
    {
        breadboard = Breadboard.instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateUI()
    {
    	Debug.Log("Updating UI");
    }
}
