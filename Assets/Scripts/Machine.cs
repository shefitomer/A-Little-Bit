using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machine
{
	protected GameObject prefab;
	protected GameObject GO;

	public string Name;

	public Vector2 position;

	public Machine(string name, GameObject prefab, Vector2 position)
	{
        GO = (GameObject)GameObject.Instantiate(prefab);
        GO.transform.position = position;
		BoxCollider2D collider = GO.AddComponent<BoxCollider2D>();
		collider.isTrigger = true;
	}

	public bool IsTouching(Vector2 position){	
		return GO.GetComponent<BoxCollider2D>().bounds.Contains(position);
	}

	public bool IsTouching(Collider2D collider){	
		return GO.GetComponent<BoxCollider2D>().IsTouching(collider);
	}

    virtual public void open()
    {
    	Debug.Log("Main Open");
    }
}
