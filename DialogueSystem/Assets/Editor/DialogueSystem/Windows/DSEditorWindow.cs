using UnityEditor;
using UnityEngine.UIElements;

namespace DS.Windows
{
    using Utilities;

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

        #region Element Addition
        private void AddGraphView()
        {
            DSGraphView graphView = new(this);

            graphView.StretchToParentSize();

            rootVisualElement.Add(graphView);
        }

        private void AddStyles()
        {
            rootVisualElement.AddStyleSheets("DialogueSystem/DSVariables.uss");
        }
        #endregion
    }
}
