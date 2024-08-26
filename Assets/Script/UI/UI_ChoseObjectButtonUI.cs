using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_ChoseObjectButtonUI : UI_BaseButton
{
    [SerializeField] Object_BaseObject objectToPlace = null;
    [SerializeField] Player_Brain player = null;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        text.text = objectToPlace.name;
        player =FindAnyObjectByType<Player_Brain>();
        
    }

    protected override void Behaviour()
    {
        base.Behaviour();
        player.Interact.SetObjectToPlace(objectToPlace);
    }
}
