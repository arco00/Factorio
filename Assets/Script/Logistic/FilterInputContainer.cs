using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FilterInputContainer : InputContainer
{
    [SerializeField] List<BaseItem> whiteListItems = new List<BaseItem>();

    public List<BaseItem> WhiteList => whiteListItems;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
