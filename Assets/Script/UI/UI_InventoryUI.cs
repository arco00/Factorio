using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_InventoryUI : UI_ObjectUI
{
    [SerializeField] CT_BaseContainer container=null;
    [SerializeField] GameObject textcontainer = null;
    // Start is called before the first frame update
    void Start()
    {
        container = GetComponent<CT_BaseContainer>();
        ShowInventory(); //on clic
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
    }

    void ShowInventory()
    {
        foreach (ItemStruct _items in container.ListItems)
        {
            GameObject _newtext = Instantiate(textcontainer);
            _newtext.transform.parent = toShow.transform;
            TextMeshProUGUI _TMP = _newtext.GetComponent<TextMeshProUGUI>();
            if (!_TMP) return;
            _TMP.text = ($"{_items.Item.NameItem}: {_items.Number}");
        }
    }
}
