﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppController : MonoBehaviour
{
    void Update(){
        if (Input.GetKeyDown(KeyCode.Escape)) 
            Application.Quit(); 
    }
}
