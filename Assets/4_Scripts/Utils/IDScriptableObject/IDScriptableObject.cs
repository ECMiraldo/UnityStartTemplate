using UnityEngine;
using NaughtyAttributes;
using System;

#if UNITY_EDITOR
using UnityEditor;
#endif

public abstract class IDScriptableObject : ScriptableObject 
{
    [field: ReadOnly, SerializeField] public string id { get; private set; }



#if UNITY_EDITOR
    // Ensures the ID is only generated once when the asset is created
    protected virtual void Awake()
    {
        if (string.IsNullOrEmpty(id))
        {
            id = Guid.NewGuid().ToString();
            EditorUtility.SetDirty(this); // Mark the object dirty so Unity saves the new ID
            AssetDatabase.SaveAssets();   // Ensure it's written to disk
        }
    }
#endif
}
