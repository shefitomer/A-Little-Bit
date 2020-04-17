using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machines : MonoBehaviour
{

    List<Machine> AllMachines;

    public GameObject BasicBlockPrefab;

    // Start is called before the first frame update
    void Start()
    {
        AllMachines = new List<Machine>();
        AllMachines.Add(new Breadboard(BasicBlockPrefab, new Vector2(3f, 1.5f)));
    }

    public Machine GetMachineCollding(Vector2 position)
    {
        foreach (Machine m in AllMachines)
        {
            if(m.IsTouching(position))
            {
                return m;
            }
        }
        return null;
    }

    public Machine GetMachineCollding(Collider2D collider)
    {
        foreach (Machine m in AllMachines)
        {
            if(m.IsTouching(collider))
            {
                return m;
            }
        }
        return null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
