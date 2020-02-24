using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class speed : MonoBehaviour {

    public Text spd;
    public static int speed_value;
    void Update()
    {
         speed_value = int.Parse(spd.text);
    }
}
