using EGO.FrameWork;
using EGO.Util;

namespace EGO.ViewController
{
    class ToDoListView : VerticalLayout
    {
        private ButtonView mShowUnFinishedButton = null;
        private ButtonView mShowFinishedButton = null;

        private Property<bool> mShowFinished = new Property<bool>(true);

        public ToDoListView()
        {
            AddChild(new SpaceView());

            mShowUnFinishedButton = new ButtonView("显示已完成",OnClickUnFinishedBtn);

            mShowFinishedButton = new ButtonView("显示未完成",OnClickFinishedBtn);

            mShowFinished.Bind(newvalue =>
            {
                if (newvalue == true)
                {
                    mShowFinishedButton.Show();
                    mShowUnFinishedButton.Hide();
                }
                else
                {
                    mShowFinishedButton.Hide();
                    mShowUnFinishedButton.Show();
                }
            });

            

            AddChild(mShowFinishedButton);
            AddChild(mShowUnFinishedButton);

            foreach (var todo in ModelLoader.Model.ToDos)
            {
                CreateToDoView(todo);
            }

            AddChild(mTodosParentContainer);

            mShowFinished.Value = false;
        }

        ILayout mTodosParentContainer = new VerticalLayout("box");

        public  void CreateToDoView(ToDo todo)
        {
            var todoView = new ToDoView(todo);

            mTodosParentContainer.AddChild(todoView);

            mShowFinished.Bind(showFinished =>
            {
                if (todoView.model.mFinished.Value == showFinished)
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
