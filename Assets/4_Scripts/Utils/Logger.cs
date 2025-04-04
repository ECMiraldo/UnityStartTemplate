using UnityEngine;
using UnityUtils;
public class Logger : Singleton<Logger>
{
    [SerializeField] private bool logScenes = true;
    [SerializeField] private bool logPersistence = true;
    public static void LogScenes(string message)
    {
        if (instance.logScenes) Debug.Log(message);
    }

    public static void LogPersistence(string message)
    {
        if (instance.logPersistence) Debug.Log(message); 
    }
}
