using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseChest : BaseObject
{
    [SerializeField] InputContainer inputRef = null;
    [SerializeField] OutputContainer outputRef = null;
    // Start is called before the first frame update
    protected override void Start()
    {
        inputRef = GetComponent<InputContainer>();
        outputRef = GetComponent<OutputContainer>();
        base.Start();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
