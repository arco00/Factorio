using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BaseChest : MonoBehaviour
{
    [SerializeField] List<BaseItem> listItems = new List<BaseItem>();
    [SerializeField] float maxItem = 30;
    // Start is called before the first frame update

    public List<BaseItem> ListItems => listItems;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool AddItem(BaseItem _item)
    {
        if (listItems.Count>=maxItem) { return false; }
        listItems.Add(_item);
        return true;
    }

    public bool RemoveItem(BaseItem _item)
    {
        if (listItems.Count < 1) { return false; }
        listItems.Remove(_item);
        return true;
    }
}
