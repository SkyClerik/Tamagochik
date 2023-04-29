using Data.Resources;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ResourcesData))]
public class ResourcesDataEditor : Editor
{
    private ResourcesData _resourcesData;

    [SerializeField]
    private ResourceTextsData _resourceTextsData;
    [SerializeField]
    private ResourceIconsData _resourceIconsData;

    public override void OnInspectorGUI()
    {
        EditorGUI.BeginChangeCheck();

        if (GUILayout.Button("calculate"))
        {
            _resourcesData = (ResourcesData)target;
            _resourcesData.Calculate(_resourceTextsData, _resourceIconsData);

            if (EditorGUI.EndChangeCheck())
                EditorUtility.SetDirty(_resourcesData);
        }
        EditorGUILayout.HelpBox("��� ���� ����������� �������������� �������������.\n" +
            "������������ ������������� ��� �������.\n" +
            "��� ��������� ����������� ����� Calculate ������ ResourcesData", MessageType.Info);

        base.OnInspectorGUI();
    }
}