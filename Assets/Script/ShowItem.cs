using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowItem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartShowItem(ItemStruct _item, Vector3 _loc)
    {
        //Debug.Log(_loc);
        Instantiate<BaseItem>(_item.Item, _loc, Quaternion.identity);
    }
    public void StopShowItem(BaseItem _item)
    {
        Destroy(_item);
    }
    public void TransitItem() //from a belt too another
    {

    }
    public void AcceptItem()
    {

    }
    
}
