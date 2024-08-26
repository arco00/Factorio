using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class BaseUsine : Object_BaseObject
{
    // Start is called before the first frame update
    [SerializeField] BaseRecipe recipeRef = null;
    [SerializeField] CT_FilterInputContainer inputRef = null;
    [SerializeField] CT_MultiOutputContainer outputRef = null;

    

    public Action craftItem = null;
 
    public CT_FilterInputContainer InputRef => inputRef;

    public CT_MultiOutputContainer OutputRef => outputRef;

    private void Awake()
    {
        recipeRef = GetComponent<BaseRecipe>();
        inputRef = GetComponent<CT_FilterInputContainer>();
        outputRef =  GetComponent<CT_MultiOutputContainer>();
  
    }

    protected override void Start()
    {
       base.Start();
        InitFilter();
    }
    protected override void OnEnable()
    {
        base.OnEnable();
        inputRef.OnAddItemEvent += (_items) =>  recipeRef.CheckCraft(); 

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
