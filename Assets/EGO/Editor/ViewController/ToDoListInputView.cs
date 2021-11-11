using EGO.FrameWork;
using System;
using UnityEngine;

namespace EGO.ViewController
{
    class ToDoListInputView:VerticalLayout
    {
        public Action<V_1.ToDo> OnTodoCreate;

        public string mInputContent = string.Empty;
        public ToDoListInputView()
        {
            mStyle = "box";

            var horizontalLayout = new HorizontalLayout(mStyle);
            {
                var textAreaView = new TextAreaView(mInputContent);
                textAreaView.Content.Bind(newValue => mInputContent = newValue);
                horizontalLayout.AddChild(textAreaView);

                var buttonView = new ButtonView("添加", () =>
                 {
                     if (!string.IsNullOrEmpty(mInputContent))
                     {
                         var newToDo = new V_1.ToDo() { mContent = mInputContent };
                         OnTodoCreate(newToDo);
                         mInputContent = string.Empty;
                     }
                 });
                buttonView.LayoutOptions.Add(GUILayout.Width(50));

                horizontalLayout.AddChild(buttonView);
            }
            
            AddChild(horizontalLayout);
        }
    }
}
