using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTapis : BaseObject
{
    //[SerializeField] Vector3Int inputLoc = new Vector3Int(0,1,0);
    [SerializeField] Vector3Int outputLoc=new Vector3Int(0,-1,0);
    [SerializeField] BaseContainer stockageRef = null;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        //stockageRef.WhiteList=recipeRef.
        stockageRef=GetComponent<BaseContainer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (TestOutput())
        {

        }
    }

    bool TestOutput()
    {
        
        //tester si le trus à l'outpur a un container 
        return true;
    }
}
