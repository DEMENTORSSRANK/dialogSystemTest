using System.Linq;
using Sources.Data;
using UnityEditor;
using UnityEngine;

namespace Sources.Editor
{
    [CustomEditor(typeof(DialogData))]
    public class DialogDataEditor : UnityEditor.Editor
    {
        private SerializedProperty _title;

        private SerializedProperty _replicas;

        private DialogData _data;

        private void OnEnable()
        {
            _title = serializedObject.FindProperty("_title");

            _replicas = serializedObject.FindProperty("_replicas");

            _data = (DialogData) target;
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.PropertyField(_title);

            EditorGUILayout.BeginVertical("box");

            GUILayout.Label("Dialogs");

            for (int i = 0; i < _replicas.arraySize; i++)
            {
                var property = _replicas.GetArrayElementAtIndex(i);

                EditorGUILayout.PropertyField(property);

                EditorGUILayout.Space(5);

                EditorGUILayout.BeginHorizontal();

                if (GUILayout.Button("-"))
                {
                    _replicas.DeleteArrayElementAtIndex(i);
                }

                if (GUILayout.Button("+"))
                {
                    _replicas.InsertArrayElementAtIndex(i);

                    SerializedProperty newElement = _replicas.GetArrayElementAtIndex(i + 1);

                    newElement.FindPropertyRelative("_text").stringValue = string.Empty;

                    newElement.FindPropertyRelative("_authorFromRight").boolValue =
                        !newElement.FindPropertyRelative("_authorFromRight").boolValue;
                }

                if (i > 0)
                {
                    if (GUILayout.Button("↑"))
                    {
                        _replicas.MoveArrayElement(i, i - 1);
                    }
                }

                if (i < _data.Replicas.Count() - 1)
                {
                    if (GUILayout.Button("↓"))
                    {
                        _replicas.MoveArrayElement(i, i + 1);
                    }
                }

                EditorGUILayout.EndHorizontal();
            }

            EditorGUILayout.EndVertical();

            serializedObject.ApplyModifiedProperties();
        }
    }
}