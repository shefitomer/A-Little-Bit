using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BreadboardUI : MonoBehaviour
{
	public Transform itemsParent;
	Breadboard breadboard;
	BreadboardSlot[] slots;
	BreadboardSlot ConnectionSideA;
	public static int SLOTS_IN_ROW = 5; 

    // Start is called before the first frame update
    void Start()
    {
        breadboard = Breadboard.instance;
        slots = itemsParent.GetComponentsInChildren<BreadboardSlot>();
        BreadboardSlot[] row_slots = new BreadboardSlot[SLOTS_IN_ROW];
        int row_number = 0;
        for(int i = 0; i < slots.Length; i++)
        {
        	if(0 == i%SLOTS_IN_ROW && i != 0)
        	{
        		InitRow(row_slots);
        		row_slots = new BreadboardSlot[SLOTS_IN_ROW];
        	}
        	row_slots[i%SLOTS_IN_ROW] = slots[i];
        	slots[i].id = i;
        	slots[i].parent = this;
        }
    }

    public void InitRow(BreadboardSlot[] row_slots)
    {
        foreach (BreadboardSlot slot in row_slots)
        {
        	slot.row = row_slots;
        }
    }

    public void SlotClicked(BreadboardSlot slot, int id)
    {
    	Debug.Log("Clicked " + id + "(" + slot + ")");
        ChangeButtonColor(slot, new Color32(255, 0, 0, 150));
    	if(ConnectionSideA != null)
    	{
            ChangeButtonColor(slot, new Color32(255, 255, 255, 150));
            ChangeButtonColor(ConnectionSideA, new Color32(255, 255, 255, 150));
            if(Array.Exists(ConnectionSideA.row, ConnectionSideB => ConnectionSideB == slot))
            {
                Debug.Log("slot in the same row!");
                ConnectionSideA = null;
                return;
            }
    		slot.connection = ConnectionSideA;
    		ConnectionSideA.connection = slot;
            LineRenderer line = ConnectionSideA.ConnectCableTo(slot);
            slot.cable = line;
            ConnectionSideA = null;
    	}
    	else{
    		ConnectionSideA = slot;
    	}
    }

    void ChangeButtonColor(BreadboardSlot slot, Color32 new_color)
    {
		Button SlotButton = slot.GetComponentInChildren<Button>();
		ColorBlock cb = SlotButton.colors;
		cb.normalColor = new_color;
		SlotButton.colors = cb;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateUI()
    {
    	Debug.Log("Updating UI");
    }
}
