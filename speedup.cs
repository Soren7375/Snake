﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class speedup : MonoBehaviour {

    public Text speed;
    void OnMouseDown()
    {
        int sp = int.Parse(speed.text);
        if (sp < 5)
            sp++;
        speed.text = sp.ToString();

    }
}
