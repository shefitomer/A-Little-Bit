using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breadboard : Machine
{
    public static Breadboard instance;
    public GameObject MenuGO;

    private GameObject menu;

    void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("More than one breadboard created!");
            return;
        }
        instance = this;
    }

    public Breadboard(GameObject prefab, Vector2 position, GameObject MenuUI) : base("Breadboard", prefab, position)
    {
        this.menu = MenuUI;
    }

    override public void open()
    {
        Debug.Log("Main Open");
        GO = (GameObject)GameObject.Instantiate(menu);
        GO.AddComponent<BoxCollider2D>();
    }
}
