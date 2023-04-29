using System.Collections.Generic;
using System.Linq;
using UnityEditor;

[CustomEditor(typeof(SceneLoader), true)]
public class SceneLoaderEditor : Editor
{
    private SceneLoader _localSceneLoader;
    private List<string> _sceneNames = new List<string>();
    private int _sceneIndex = 0;

    private void OnEnable()
    {
        _localSceneLoader = (SceneLoader)target;

        var scenesGUIDs = AssetDatabase.FindAssets("t:Scene");
        var scenesPaths = scenesGUIDs.Select(AssetDatabase.GUIDToAssetPath);
        foreach (var item in scenesPaths)
        {
            _sceneNames.Add(item.Split('/').Last().Split('.').First());
        }

        for (int i = 0; i < _sceneNames.Count; i++)
        {
            if (_sceneNames[i] == _localSceneLoader.SceneName)
            {
                _sceneIndex = i;
                break;
            }
        }
    }

    public override void OnInspectorGUI()
    {
        EditorGUI.BeginChangeCheck();

        _sceneIndex = EditorGUILayout.Popup(_sceneIndex, _sceneNames.ToArray());
        _localSceneLoader.SceneName = _sceneNames[_sceneIndex];

        base.OnInspectorGUI();

        if (EditorGUI.EndChangeCheck())
            EditorUtility.SetDirty(_localSceneLoader);
    }
}
