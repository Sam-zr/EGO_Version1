using EGO.FrameWork;
using EGO.Util;
using System.Linq;

namespace EGO.ViewController
{
    class ToDoListView : VerticalLayout
    {
        public ToDoListInputView InputView { get; set; } = new ToDoListInputView();

        public ToDoListView()
        {
            mStyle = "Box";

            InputView.OnTodoCreate = newToDo =>
            {
                newToDo.State.Bind(_ => ModelExtension.Save(ModelLoader<V_1.ToDoList>.Model));
                ModelLoader<V_1.ToDoList>.Model.ToDos.Add(newToDo);
                ModelExtension.Save(ModelLoader<V_1.ToDoList>.Model);
                CreateToDoView(newToDo);
            };
            AddChild(InputView);

            foreach (var todo in ModelLoader<V_1.ToDoList>.Model.ToDos.Where(todo=>todo.State.Value!=V_1.TodoState.Done))
            {
                CreateToDoView(todo);
            }

            AddChild(mTodosParentContainer);
        }

        ILayout mTodosParentContainer = new VerticalLayout("box");

        protected override void OnShow()
        {
            mTodosParentContainer.Refresh();
        }

        public  void CreateToDoView(V_1.ToDo todo)
        {
            var todoView = new ToDoView(todo);

            mTodosParentContainer.AddChild(todoView);
        }
    }
}
