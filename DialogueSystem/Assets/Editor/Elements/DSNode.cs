using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;
using UnityEngine;

namespace DS.Elements
{
    using Enumerations;

    public class DSNode : Node
    {
        public string DialogueName { get; set; }
        public List<string> Choices { get; set; }
        public string Text { get; set; }

        public DSDialogueType DialogueType { get; set; }

        public virtual void Initialize(Vector2 position)
        {
            DialogueName = "Dialogue Name";
            Choices = new();
            Text = "Dialogue text.";

            SetPosition(new Rect(position, Vector2.zero));

            mainContainer.AddToClassList("ds-node__main-container");
            extensionContainer.AddToClassList("ds-node__extension-container");
        }

        public virtual void Draw()
        {
            #region Title Container
            TextField dialogueNameTextField = new() { value = DialogueName };

            dialogueNameTextField.AddToClassList("ds-node__textfield");
            dialogueNameTextField.AddToClassList("ds-node__filename-textfield");
            dialogueNameTextField.AddToClassList("ds-node__textfield__hidden");

            titleContainer.Insert(0, dialogueNameTextField);
            #endregion

            #region Input Container
            Port inputPort = InstantiatePort(Orientation.Horizontal, Direction.Input, Port.Capacity.Multi, typeof(bool));
            inputPort.portName = "Dialogue Connection";
            inputContainer.Add(inputPort);
            #endregion

            #region Extensions Container
            VisualElement customDataContainer = new();

            customDataContainer.AddToClassList("ds-node__custom-data-container");

            Foldout textFoldout = new() { text = "Dialogue Text" };
            TextField textTextField = new() { value = Text };

            textTextField.AddToClassList("ds-node__textfield");
            textTextField.AddToClassList("ds-node__quote-textfield");

            textFoldout.Add(textTextField); 
            customDataContainer.Add(textFoldout);
            extensionContainer.Add(customDataContainer);
            #endregion
        }
    }
}
