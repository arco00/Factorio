using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choose : BaseButton
{
    [SerializeField] BaseObject objectToPlace = null;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        text.text = objectToPlace.name;
        
    }

    protected override void Behaviour()
    {
        base.Behaviour();
        InputManager.Instance.SetObjectToPlace(objectToPlace);
    }
}
