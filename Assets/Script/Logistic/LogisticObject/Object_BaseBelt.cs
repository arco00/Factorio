using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Object_BaseBelt : Object_BaseObject
{
    
    [SerializeField] CT_MonoOutputContainer outputRef = null;
    [SerializeField]ShowItem showItem = null;
    [SerializeField] List<BaseItem> itemsOnBelt = new List<BaseItem>();
    //[SerializeField] protected List<Vector2Int> listOutputLoc = new List<Vector2Int>();

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        //stockageRef.WhiteList=recipeRef.
        outputRef=GetComponent<CT_MonoOutputContainer>();
        showItem = GetComponent<ShowItem>();
        //listOutputLoc = Utile.GetNeighbor(new Vector2Int(0, 0), size);
        // InvokeRepeating(nameof(Rotate), 1, 1);// test rotate concluant 
        InitEvent();
        InvokeRepeating(nameof(MoveItem), outputRef.OutputTime, outputRef.OutputTime);
    }


    void MoveItem()
    {
        foreach (var _item in itemsOnBelt) 
        {
            Vector3 _loc= new Vector3 (outputRef.OutputLoc.x* outputRef.OutputTime, outputRef.OutputLoc.y * outputRef.OutputTime,0);
            _item.transform.position += _loc ;
        }
    }
    void Rotate()
    {
        transform.eulerAngles += new Vector3(0, 0, -90);
        outputRef.OutputLoc = GridManager.GetGridPos2D(transform.position + transform.right) ;
    }

    private void OnDrawGizmos()
    {
        //Gizmos.DrawLine(transform.position, transform.position+ transform.right);
        //Gizmos.DrawSphere(new Vector3(outputRef.OutputLoc.x,outputRef.OutputLoc.y,0), 1);
    }

    void InitEvent()
    {
        outputRef.OnAddItemEvent += (_item) =>
        {
            showItem.StartShowItem(_item, GridManager.Grid.CellToWorld(Utile.Vector2ToVector3(outputRef.OutputLoc/ -2+location)) );
            itemsOnBelt.Add(_item.Item);
        };
        outputRef.OnRemoveItemEvent += (_item) =>
        {
            if (itemsOnBelt.Count <= 0) return;
            showItem.StopShowItem(itemsOnBelt[0]);
            itemsOnBelt.RemoveAt(0);
        };

    }

}
