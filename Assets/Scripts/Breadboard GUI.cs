using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreadboardGUI : MonoBehaviour
{
    // Start is called before the first frame update
    void OnGUI()
    {
        // GUI.Box(new Rect(10, 10, 100, 90), "Breadboard");

    	GUI.Window(0, new Rect(10, 10, 80, 80), window, "Test");
    }

    void window(int id)
    {
        if (GUI.Button(new Rect(10, 10, 80, 20), "Test"))
        {
            Debug.Log("Pressed 1");
        }
        
        if (GUI.Button(new Rect(20, 70, 80, 20), "Test"))
        {
            Debug.Log("Pressed 2");
        }
    }
}
