using EGO.FrameWork;
using EGO.Util;

namespace EGO.ViewController
{
    class ToDoListView : VerticalLayout
    {
        public Property<bool> mShowFinished = new Property<bool>(true);

        public ToDoListView()
        {
            mStyle = "Box";

            foreach (var todo in ModelLoader<V_1.ToDoList>.Model.ToDos)
            {
                CreateToDoView(todo);
            }

            AddChild(mTodosParentContainer);

            mShowFinished.Value = false;
        }

        ILayout mTodosParentContainer = new VerticalLayout("box");

        public  void CreateToDoView(V_1.ToDo todo)
        {
            var todoView = new ToDoView(todo);

            mTodosParentContainer.AddChild(todoView);

            mShowFinished.Bind(showFinished =>
            {
                if (showFinished==(todoView.model.State.Value == V_1.TodoState.Done))
                {
                    todoView.Show();
                }
                else
                {
                    todoView.Hide();
                }
            });
        }

        public void OnClickFinishedBtn()
        {
            mShowFinished.Value = false;
        }

        public void OnClickUnFinishedBtn()
        {
            mShowFinished.Value = true;
        }
    }
}
