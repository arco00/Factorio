using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoOutputContainer : BaseOutputContainer
{
    [SerializeField] protected Vector2Int outputLoc = new Vector2Int();
    
    public Vector2Int OutputLoc { get; set; }
    // Start is called before the first frame update
    protected override void  Start()
    {
        base.Start();
        Invoke(nameof(InitOutputloc), 0.1f);
        //outputContainer = objectRef.GetComponent<InputContainer>(); 
        //InvokeRepeating(nameof(OutputBehaviour), outputTime,outputTime);
    }

    void Update()
    {
        
    }

    protected override void OutputBehaviour()
    {
        Debug.Log("tapis");
        foreach (ItemStruct _item in listItems)
        {
            OutputAtContainer(new ItemStruct(_item.Item, 1), outputLoc);
        }
    }

    void InitOutputloc()
    {
        outputLoc = objectRef.GridManager.GetGridPos2D(transform.position + transform.right);
    }





}
