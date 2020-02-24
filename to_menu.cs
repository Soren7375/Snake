using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class to_menu : MonoBehaviour {

    void Update()
    {
        if(Input.anyKeyDown)
            Application.LoadLevel(0);
    }
}
