using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace DS.Windows
{
    public class DSEditorWindow : EditorWindow
    {
        [MenuItem("Tools/Dialogue System Window")]
        public static void OpenWindow()
        {
            GetWindow<DSEditorWindow>("Dialogue System Graph");
        }

        private void OnEnable()
        {
            AddGraphView();

            AddStyles();
        }

        private void AddGraphView()
        {
            DSGraphView graphView = new();

            graphView.StretchToParentSize();

            rootVisualElement.Add(graphView);
        }

        private void AddStyles()
        {
            StyleSheet styleSheet = (StyleSheet)EditorGUIUtility.Load("DialogueSystem/DSVariables.uss");
            rootVisualElement.styleSheets.Add(styleSheet);
        }
    }
}
