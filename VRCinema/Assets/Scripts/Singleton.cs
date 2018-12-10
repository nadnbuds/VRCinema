using UnityEngine;
using System.Collections;

public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance = null;
    private static object _lock = new object();
    private static bool appIsQuitting = false;

    public static T instance
    {
        get
        {
            if (appIsQuitting)
            {
                return null;
            }

            lock (_lock)
            {
                if (_instance == null)
                {
                    //Link to potential issue/solution: http://forum.unity3d.com/threads/findobjectoftype-not-detecting-an-object.48026/
                    _instance = (T)FindObjectOfType(typeof(T));
                }

                return _instance;
            }
        }
    }

    public void OnApplicationQuit()
    {
        appIsQuitting = true;
    }
}
