
using UnityEngine;

public class CT_MonoOutputContainer : CT_BaseOutputContainer
{
    [SerializeField,Header("Mono Output")] protected Vector2Int outputLoc = new Vector2Int();
    
    public Vector2Int OutputLoc { get; set; }
    // Start is called before the first frame update
    protected override void  Start()
    {
        base.Start();
        Invoke(nameof(InitOutputloc), 0.1f);
        //outputContainer = objectRef.GetComponent<InputContainer>(); 
        //InvokeRepeating(nameof(OutputBehaviour), outputTime,outputTime);
    }

  

    protected override void OutputBehaviour()
    {
        if (debug) Debug.Log("tapis");
        if (currentItemNumber <= 0) return;
        //foreach (ItemStruct _item in listItems)
        //{
        //    OutputAtContainer(new ItemStruct(_item.Item, 1), outputLoc);
        //}
        int _size = listItems.Count;
        if (_size <= 0) return;
        for (int i = 0; i < _size; i++)
        {
            OutputAtContainer(new ItemStruct(listItems[i].Item, 1), outputLoc);
        }
    }

    void InitOutputloc()
    {
        outputLoc = objectRef.GridManager.GetGridPos2D(transform.position + transform.right);
    }

  





}
