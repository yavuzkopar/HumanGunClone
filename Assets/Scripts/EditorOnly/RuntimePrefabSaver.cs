using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RuntimePrefabSaver : MonoBehaviour
{
#if UNITY_EDITOR
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            SaveAsPrefab(Selection.activeTransform.gameObject);
        }
    }
    public void SaveAsPrefab(GameObject prefabToSave)
    {
        string localPath = "Assets/Prefabs/" + prefabToSave.name + ".prefab";

        localPath = AssetDatabase.GenerateUniqueAssetPath(localPath);
        PrefabUtility.SaveAsPrefabAssetAndConnect(prefabToSave, localPath, InteractionMode.UserAction);
    }
#endif
}
