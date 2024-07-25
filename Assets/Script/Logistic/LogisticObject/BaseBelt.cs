using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BaseBelt : BaseObject
{
    
    [SerializeField] MonoOutputContainer outputRef = null;
    [SerializeField] InputContainer inputRef = null;
    //[SerializeField] protected List<Vector2Int> listOutputLoc = new List<Vector2Int>();

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        //stockageRef.WhiteList=recipeRef.
        outputRef=GetComponent<MonoOutputContainer>();
        inputRef=GetComponent<InputContainer>();
        //listOutputLoc = Utile.GetNeighbor(new Vector2Int(0, 0), size);

       // InvokeRepeating(nameof(Rotate), 1, 1);// test rote concluant 

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void Rotate()
    {
        transform.eulerAngles += new Vector3(0, 0, -90);
        outputRef.OutputLoc = gridManager.GetGridPos2D(transform.position + transform.right) ;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position+ transform.right);
        //Gizmos.DrawSphere(new Vector3(outputRef.OutputLoc.x,outputRef.OutputLoc.y,0), 1);
    }

}
