using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardHandler : MonoBehaviour
{
	Character Player;
    Machines RoomMachines;

    // Start is called before the first frame update
    void Start()
    {
        Player = GetComponent<Map>().PlayingCharacter;
        RoomMachines = GetComponent<Machines>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Player.MoveOnXAxis(Player.WalkingSpeed);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Player.MoveOnXAxis(-Player.WalkingSpeed);
        }
        if (Input.GetKeyDown(KeyCode.Space)){
            Player.Jump();
        }
        if (Input.GetKeyDown(KeyCode.Return)){
            Machine CurrentMachine = RoomMachines.GetMachineCollding(Player.GO.GetComponent<BoxCollider2D>());
            if(CurrentMachine != null)
            {
                CurrentMachine.open();
            } 
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Vector3 TargetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Machine CurrentMachine = RoomMachines.GetMachineCollding(TargetPosition);
            if(CurrentMachine != null)
            {
                CurrentMachine.open();
            } 
        }
    }
}