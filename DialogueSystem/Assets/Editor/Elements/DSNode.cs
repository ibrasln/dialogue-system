using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;
using UnityEngine;

namespace DS.Elements
{
    using Windows;
    using Enumerations;
    using Utilities;

    public class DSNode : Node
    {
        public string DialogueName { get; set; }
        public List<string> Choices { get; set; }
        public string Text { get; set; }
        public DSDialogueType DialogueType { get; set; }

        private DSGraphView graphView;
        private Color defaultBackgroundColor;

        public virtual void Initialize(DSGraphView dsGraphView, Vector2 position)
        {
            DialogueName = "Dialogue Name";
            Choices = new();
            Text = "Dialogue text.";

            graphView = dsGraphView;

            SetPosition(new Rect(position, Vector2.zero));

            defaultBackgroundColor = new Color(29f / 255f, 29f / 255f, 30f / 255f);

            mainContainer.AddToClassList("ds-node__main-container");
            extensionContainer.AddToClassList("ds-node__extension-container");
        }

        public virtual void Draw()
        {
            #region Title Container
            TextField dialogueNameTextField = DSElementUtility.CreateTextField(DialogueName, callback =>
            {
                graphView.RemoveUngroupedNode(this);

                DialogueName = callback.newValue;

                graphView.AddUngroupedNode(this);
            });

            dialogueNameTextField.AddClasses(
                "ds-node__textfield",
                "ds-node__filename-textfield",
                "ds-node__textfield__hidden"
                );

            titleContainer.Insert(0, dialogueNameTextField);
            #endregion

            #region Input Container
            Port inputPort = this.CreatePort("Dialogue Connection", Orientation.Horizontal, Direction.Input, Port.Capacity.Multi);
            inputContainer.Add(inputPort);
            #endregion

            #region Extensions Container
            VisualElement customDataContainer = new();

            customDataContainer.AddToClassList("ds-node__custom-data-container");

            Foldout textFoldout = DSElementUtility.CreateFoldout("Dialogue Text");

            TextField textTextField = DSElementUtility.CreateTextArea(Text);

            textTextField.AddClasses(
                "ds-node__textfield",
                "ds-node__quote-textfield"
                );

            textFoldout.Add(textTextField); 
            customDataContainer.Add(textFoldout);
            extensionContainer.Add(customDataContainer);
            #endregion
        }

        public void SetErrorStyle(Color color)
        {
            mainContainer.style.backgroundColor = color;
        }

        public void ResetStyle()
        {
            mainContainer.style.backgroundColor = defaultBackgroundColor;
        }
    }
}
