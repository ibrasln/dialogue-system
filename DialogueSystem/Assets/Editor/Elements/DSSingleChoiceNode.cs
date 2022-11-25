using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Experimental.GraphView;

namespace DS.Elements
{
    using Utilities;
    using Enumerations;
    using Windows;

    public class DSSingleChoiceNode : DSNode
    {
        public override void Initialize(DSGraphView dsGraphView, Vector2 position)
        {
            base.Initialize(dsGraphView, position);

            DialogueType = DSDialogueType.SingleChoice;

            Choices.Add("Next Dialogue");
        }

        public override void Draw()
        {
            base.Draw();

            #region Output Container
            foreach (string choice in Choices)
            {
                Port choicePort = this.CreatePort(choice);
                outputContainer.Add(choicePort);
            }
            #endregion

            // It also calls the RefreshPorts(), so we don't need to call that function separately
            RefreshExpandedState();
        }
    }
}
