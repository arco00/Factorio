using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choose : BaseButton
{
    [SerializeField] BaseObject objectToPlace = null;
    [SerializeField] PlaceObject placeObject = null;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        text.text = objectToPlace.name;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void Behaviour()
    {
        base.Behaviour();
        placeObject.SetObjectToPlace(objectToPlace);
    }
}
