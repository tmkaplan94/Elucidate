using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    This code is essentially the exact same as Tyler's singleton, except with a scriptable object and 
    it requires the scriptable object to be in the resources file like other photon requirements.
*/
public abstract class SingletonScriptableObject<T> : ScriptableObject where T : ScriptableObject
{
    private static T _instance = null;

    public static T Instance
    {
        get
        {
            if(_instance == null)
            {
                T[] results = Resources.FindObjectsOfTypeAll<T>();
                if(results.Length == 0)
                {
                    Debug.LogError("SingletonScriptableObject Could not find type " + typeof(T).ToString());
                    return null;
                }
                if(results.Length > 1)
                {
                    Debug.LogError("SingletonScriptableObject there are multiple of type " + typeof(T).ToString());
                    return null;
                }
                _instance = results[0];
            }
            return _instance;
        }
    }
}