using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	private Character Player;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void LateUpdate()
    {
    	if(Player == null)
    	{
    		Player = GameObject.Find("Scripts").GetComponent<Map>().PlayingCharacter;
    	}
    	else
    	{
    		transform.position = new Vector3(Player.GO.transform.position.x,
    										 Mathf.Max(Player.GO.transform.position.y, 4.1f),
    										 -10);
    	}
    }
}
