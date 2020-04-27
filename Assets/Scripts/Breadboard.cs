using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breadboard : Machine
{
    public static Breadboard instance;

    void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("More than one breadboard created!");
            return;
        }
        instance = this;
    }

    public Breadboard(GameObject prefab, Vector2 position) : base("Breadboard", prefab, position)
    {

    }

    override public void open()
    {
        Debug.Log("Main Open");
    }
}
