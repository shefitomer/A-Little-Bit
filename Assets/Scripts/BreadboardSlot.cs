using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreadboardSlot : MonoBehaviour
{
	public int id;
	public BreadboardUI parent;
    public BreadboardSlot[] row;
    public BreadboardSlot connection;
    public LineRenderer cable;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public LineRenderer ConnectCableTo(BreadboardSlot slot)
    {
    	gameObject.AddComponent<LineRenderer>();
    	LineRenderer line = this.GetComponent<LineRenderer>();
    	line.SetPosition(0, this.transform.position);
    	line.SetPosition(1, slot.transform.position);
    	line.sortingOrder = 4; line.sortingLayerName = "UI"; 
    	line.SetWidth(1f, 1f);
    	this.cable = line;
    	return line;
    }

    public void OnButtonPress()
    {
    	parent.SlotClicked(this, id);
    }
}
