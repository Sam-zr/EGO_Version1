using EGO.FrameWork;
using EGO.Util;
using System;
using UnityEngine;

namespace EGO.ViewController
{
    class ToDoListController:FrameWork.ViewController
    {
        public Action<ToDo> OnTodoCreate;

        public ToDoListInputView InputView { get; set; } = new ToDoListInputView();
        public ToDoListView ListView { get; set; } = new ToDoListView();

        public ToolBarView ToolBarView { get; set; } = new ToolBarView();
 
        public ToDoListController()
        {            
        }

        public override void SetUpView()
        {
            mView.mStyle = "box";

            ToolBarView.AddMenu("清单", content =>
             {
                 ListView.mShowFinished.Value = false;
                 InputView.Show();
             });
            ToolBarView.AddMenu("已完成", content =>
            {
                ListView.mShowFinished.Value = true;
                InputView.Hide();
            });

            mView.AddChild(ToolBarView);

            InputView.OnTodoCreate = newToDo =>
            {
                newToDo.State.Bind(_ => ModelExtension.Save(ModelLoader<V_1.ToDoList>.Model));
                ModelLoader<V_1.ToDoList>.Model.ToDos.Add(newToDo);
                ModelExtension.Save(ModelLoader<V_1.ToDoList>.Model);
                ListView.CreateToDoView(newToDo);
            };
            mView.AddChild(InputView);

            mView.AddChild(ListView);
        }
    }
}
