using EGO.FrameWork;
using EGO.Util;
using System;

namespace EGO.ViewController
{
    class ToDoListController:FrameWork.ViewController
    {
        public Action<ToDo> OnTodoCreate;

        public ToDoListInputView InputView { get; set; } = new ToDoListInputView();
        public ToDoListView ListView { get; set; } = new ToDoListView();
 
        public ToDoListController()
        {            
        }

        public override void SetUpView()
        {
            InputView.OnTodoCreate = newToDo =>
            {
                newToDo.mFinished.Bind(_ => ModelLoader.Model.Save());
                ModelLoader.Model.ToDos.Add(newToDo);
                ModelLoader.Model.Save();
            };
            View.AddChild(InputView);

            View.AddChild(new SpaceView(10));

            View.AddChild(ListView);
        }
    }
}
