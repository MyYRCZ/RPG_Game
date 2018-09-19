using UnityEngine;
using System.Collections;

public abstract class SingletonMono<T> : MonoBehaviour where T:class {

    private static T instance;

    public static T Instance
    {
        get { return instance; }
    }
    protected virtual void Awake()
    {
        instance=this as T;
    }
}
