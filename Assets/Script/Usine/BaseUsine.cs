using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class BaseUsine : BaseObject
{
    // Start is called before the first frame update
    [SerializeField] BaseRecipe recipeRef = null;
    [SerializeField] FilterInputContainer inputRef = null;
    [SerializeField] OutputContainer outputRef = null;

    

    public Action craftItem = null;
 
    public FilterInputContainer InputRef => inputRef;

    public OutputContainer OutputRef => outputRef;

    private void Awake()
    {
        recipeRef = GetComponent<BaseRecipe>();
        inputRef = GetComponent<FilterInputContainer>();
        outputRef =  GetComponent<OutputContainer>();
  
    }

    protected override void Start()
    {
       base.Start();
        InitFilter();
    }
    protected override void OnEnable()
    {
        base.OnEnable();
        inputRef.addItemEvent += recipeRef.CheckCraft;

        //launchCraft = controls.InputTest.LaunchCraft;
        //launchCraft.Enable();
        //launchCraft.performed += recipeRef.InputCheckCraft;
        //launchCraft.performed += Test;
        //launchCraft.performed += (_context) => { outputRef.SearchAllOuput(); };
    }

    void InitFilter()
    {
        inputRef.WhiteList.Clear();
        foreach (ItemStruct _item in recipeRef.ItemNeededForCraft)
        {
            inputRef.WhiteList.Add(_item.Item);
        }
    }



}
