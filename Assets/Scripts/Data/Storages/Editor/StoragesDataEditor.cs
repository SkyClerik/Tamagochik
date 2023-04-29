using Data.Storages;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(StoragesData))]
public class StoragesDataEditor : Editor
{
    private StoragesData _storageData;

    [SerializeField]
    private StorageTextsData _storageTextsData;
    [SerializeField]
    private StorageIconsData _storageIconsData;

    public override void OnInspectorGUI()
    {
        EditorGUI.BeginChangeCheck();

        if (GUILayout.Button("calculate"))
        {
            _storageData = (StoragesData)target;
            _storageData.Calculate(_storageTextsData, _storageIconsData);

            if (EditorGUI.EndChangeCheck())
                EditorUtility.SetDirty(_storageData);
        }

        EditorGUILayout.HelpBox("��� ���� ����������� �������������� �������������.\n" +
            "������������ ������������� ��� �������.\n" +
            "��� ��������� ����������� ����� Calculate ������ StoragesData", MessageType.Info);

        base.OnInspectorGUI();
    }
}