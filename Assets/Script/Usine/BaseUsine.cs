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
    [SerializeField] FilterInputContainer stockageRef = null;
    [SerializeField] OutputContainer outputRef = null;
    [SerializeField] AllInputs controls = null;
    [SerializeField] InputAction launchCraft =null;
    

    public Action craftItem = null;
 
    public FilterInputContainer StockageRef => stockageRef;

    public OutputContainer OutputRef => outputRef;

    private void Awake()
    {
        recipeRef = GetComponent<BaseRecipe>();
        stockageRef = GetComponent<FilterInputContainer>();
        outputRef =  GetComponent<OutputContainer>();

        controls = new AllInputs();   
    }

    protected override void Start()
    {
       base.Start();
        //stockageRef.WhiteList=recipeRef.
    }
    private void OnEnable()
    {
        stockageRef.addItemEvent += recipeRef.CheckCraft;

        launchCraft = controls.InputTest.LaunchCraft;
        launchCraft.Enable();
        launchCraft.performed += recipeRef.InputCheckCraft;
        launchCraft.performed += Test;
        launchCraft.performed += (_context) => { outputRef.SearchAllOuput(); };
    }


    // Update is called once per frame
    void Update()
    {

    }
    void Test (InputAction.CallbackContext _context)
    {
        Debug.Log("test");
    }



}
