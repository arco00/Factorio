using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class BaseUsine : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] BaseRecipe recipeRef = null;
    [SerializeField] BaseChest stockageRef = null;


    public event Action craftItem = null;
    public event Action addItemEvent = null;

    public Action CraftItem => craftItem;
    public Action AddItemEvent => addItemEvent;
    public BaseChest StockageRef => stockageRef;
 
    void Start()
    {
        recipeRef = GetComponent<BaseRecipe>();
        stockageRef = GetComponent<BaseChest>();
       
   
    }
    private void OnEnable()
    {
        addItemEvent += recipeRef.CheckCraft;
    }

    private void OnDisable()
    {
        addItemEvent -= ( recipeRef.CheckCraft);
    }

    // Update is called once per frame
    void Update()
    {
        recipeRef.CheckCraft();
    }

    

}
