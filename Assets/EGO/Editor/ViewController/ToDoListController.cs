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
            ToolBarView.AddMenu("Button1", content =>
             {
                 Debug.Log(content);
             });
            ToolBarView.AddMenu("Button2", content =>
            {
                Debug.Log(content);
            });
            ToolBarView.AddMenu("Button3", content =>
            {
                Debug.Log(content);
            });
            View.AddChild(ToolBarView);

            InputView.OnTodoCreate = newToDo =>
            {
                newToDo.State.Bind(_ => ModelExtension.Save(ModelLoader<V_1.ToDoList>.Model));
                ModelLoader<V_1.ToDoList>.Model.ToDos.Add(newToDo);
                ModelExtension.Save(ModelLoader<V_1.ToDoList>.Model);
                ListView.CreateToDoView(newToDo);
            };
            View.AddChild(InputView);

            View.AddChild(new SpaceView(10));

            View.AddChild(ListView);
        }
    }
}
