﻿using EGO.FrameWork;
using System;

namespace EGO.ViewController
{
    class ToDoListInputView:VerticalLayout
    {
        public Action<ToDo> OnTodoCreate;

        public string mInputContent = string.Empty;
        public ToDoListInputView()
        {
            mStyle = "box";

            AddChild(new SpaceView());

            var textAreaView = new TextAreaView(mInputContent);
            textAreaView.Content.Bind(newValue => mInputContent = newValue);
            AddChild(textAreaView);

            AddChild(new ButtonView("添加", () =>
            {
                if (!string.IsNullOrEmpty(mInputContent))
                {
                    var newToDo = new ToDo() { mContent = mInputContent, mFinished = new Property<bool>() };
                    OnTodoCreate(newToDo);
                    mInputContent = string.Empty;
                }
            }));
        }
    }
}
