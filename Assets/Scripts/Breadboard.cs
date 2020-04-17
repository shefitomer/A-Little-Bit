using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breadboard : Machine
{
    public Breadboard(GameObject prefab, Vector2 position) : base("Breadboard", prefab, position)
    {

    }

    override public void open()
    {
        Debug.Log("Main Open");
        this.GO.AddComponent<BreadboardGUI>();
    }
}
