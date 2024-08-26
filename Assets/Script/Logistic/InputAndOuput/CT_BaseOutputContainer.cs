
using UnityEngine;


public abstract class CT_BaseOutputContainer : CT_BaseContainer
{
    
    [SerializeField] protected float outputTime = .2f;
    [SerializeField,Header("Debug Arrow")] protected bool canDrawArrow = false;
    [SerializeField] Vector3 arrowDir = Vector3.zero,arrowPos=Vector3.zero;
    [SerializeField] float arrowLenght = 0,arrowTime=0, arrowCurrentTime = 0;
    [SerializeField] Color arrowColor = Color.red;


    
    public float OutputTime=> outputTime;
    
    protected override void Start()
    {
        base.Start();
        InvokeRepeating(nameof(OutputBehaviour), outputTime, outputTime);
    }

    protected virtual void Update()
    {
        if (canDrawArrow&& Utile.Timer(ref arrowCurrentTime,ref arrowTime)) canDrawArrow = false;
        
    }

    protected virtual void OutputAtInput(ItemStruct _item, Vector2Int _loc)
    {
        if (!CanRemoveItem(_item)) return;
        objectRef.GridManager.PosTakenBy(_loc, out Object_BaseObject _result);
        //test if output is possible
        if (debug) Debug.Log(_result.GetComponent<CT_InputContainer>().CanAddItem(_item));
        if (_result.GetComponent<CT_InputContainer>().CanAddItem(_item) )
        {
            //Debug.Log("add");
            _result.GetComponent<CT_InputContainer>().AddItem(_item);
            RemoveItem(_item);
        }
    }

    protected virtual void OutputAtContainer(ItemStruct _item, Vector2Int _loc)
    {
        if (!CanRemoveItem(_item)) return;
        if (debug )Debug.Log("test tapis");
        objectRef.GridManager.PosTakenBy(_loc, out Object_BaseObject _result);
        if (!_result) return;
        CT_BaseContainer _container = _result.GetComponent<CT_BaseContainer>();
        if (!_container) return;
        CT_InputContainer _inputContainer = _container.GetComponent<CT_InputContainer>();
        if (_inputContainer) // put in the input container first 
        {
            if (_inputContainer.CanAddItem(_item))
            {
                _inputContainer.AddItem(_item);
                RemoveItem(_item);
                SetCanDrawArrow(transform.position, Utile.Vector2ToVector3(_loc));

            }
        }
        else  // if not input container put in the output container 
        {
            if (_container.CanAddItem(_item))
            {
                _container.GetComponent<CT_BaseOutputContainer>().AddItem(_item);
                RemoveItem(_item);
                SetCanDrawArrow(transform.position, Utile.Vector2ToVector3(_loc));

            }
        }
    }

    protected virtual void OutputBehaviour() //for children
    {

    }



    protected void SetCanDrawArrow(Vector3 _pos, Vector3 _dir, Color _color, float _lenght = 1,float _time = .1f)
    {
        canDrawArrow = true;
        arrowColor = _color ;
        arrowLenght = _lenght ;
        arrowDir= _dir ;
        arrowPos = _pos ;
        arrowTime = _time ;
        arrowCurrentTime = 0;
 
    }
    protected void SetCanDrawArrow(Vector3 _pos, Vector3 _dir,  float _lenght = 1, float _time = .1f)
    {
        canDrawArrow = true;
        arrowLenght = _lenght;
        arrowDir = _dir;
        arrowPos = _pos;
        arrowTime = _time;
        arrowCurrentTime = 0;

    }

    protected virtual void OnDrawGizmos()
    {
       
        if ( canDrawArrow) Utile.DrawArrow(arrowPos,arrowDir,arrowColor,arrowLenght);
     
    }
}

