using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    static T instance = null;
    public static T Instance => instance;

    protected virtual void Awake()
    {
        Init();
    }

    void Init()
    {
        if (instance)
        {
            Destroy(this);
            return;
        }
        instance = this as T;
        instance.name = $"[{GetType().Name}]";  // set le name with type name 
    }
}