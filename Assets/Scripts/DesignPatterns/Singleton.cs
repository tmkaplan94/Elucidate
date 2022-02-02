/*
 * Author: Tyler Kaplan
 * Contributors:
 * Description: Singleton ensures only one instance of an object or component.
 * 
 * This implementation of the Singleton design pattern uses lazy initialization,
 * ensuring system resources are only consumed when absolutely necessary.
 * It is not currently thread safe.
 * Class is templated, so that it can be used with any object/component.
 */

using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Component
{
    // private field; the one and only instance of type T
    private static T _instance;

    // public property has getter method
    public static T Instance
    {
        get
        {
            // if class does not have an _instance
            if (_instance == null)
            {
                // find out if object exists
                _instance = FindObjectOfType<T>();
                
                // if object does not exist
                if (_instance == null)
                {
                    // make object, rename it, and assign it to class _instance
                    GameObject obj = new GameObject();
                    obj.name = typeof(T).Name;
                    _instance = obj.AddComponent<T>();
                }
            }
            
            // return _instance in either scenario
            return _instance;
        }
    }
    
    // ensures only one _instance; can be overridden by a derived/child class
    public virtual void Awake()
    {
        // if an _instance doesn't already exist
        if (_instance == null)
        {
            // this object will become the sole _instance and persist across scenes
            _instance = this as T;
            DontDestroyOnLoad(gameObject);
        }
        // otherwise, an _instance already exists
        else
        {
            // destroy itself, there can only be one
            Destroy(gameObject);
        }
    }
}
