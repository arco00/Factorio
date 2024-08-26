using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class UI_BaseButton : MonoBehaviour
{
    [SerializeField] protected Button button = null;
    [SerializeField] protected TextMeshProUGUI text = null;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        button=GetComponent<Button>();
        text=GetComponentInChildren<TextMeshProUGUI>();
        button.onClick.AddListener(Behaviour);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected virtual void Behaviour()
    {

    }
}
