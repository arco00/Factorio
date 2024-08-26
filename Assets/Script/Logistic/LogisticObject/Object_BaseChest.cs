using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_BaseChest : Object_BaseObject
{
    
    [SerializeField] CT_MultiOutputContainer outputRef = null;
    // Start is called before the first frame update
    protected override void Start()
    {
        
        outputRef = GetComponent<CT_MultiOutputContainer>();
        base.Start(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
