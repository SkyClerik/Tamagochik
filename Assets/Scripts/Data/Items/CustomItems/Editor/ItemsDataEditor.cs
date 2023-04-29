using Data.Items;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ItemsData))]
public class ItemsDataEditor : Editor
{
    private ItemsData _itemsData;

    [SerializeField]
    private ItemTextsData _itemTextsData;
    [SerializeField]
    private ItemIconsData _itemIconsData;

    public override void OnInspectorGUI()
    {
        EditorGUI.BeginChangeCheck();

        if (GUILayout.Button("calculate"))
        {
            _itemsData = (ItemsData)target;
            _itemsData.Calculate(_itemTextsData, _itemIconsData);

            if (EditorGUI.EndChangeCheck())
                EditorUtility.SetDirty(_itemsData);
        }

        EditorGUILayout.HelpBox("Все ниже приведенное просчитывается калькулятором.\n" +
            "Отображается исключительно для отладки.\n" +
            "Для настройки используйте метод Calculate класса ItemsData", MessageType.Info);

        base.OnInspectorGUI();
    }
}