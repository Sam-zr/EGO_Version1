using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
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

            var verticalLayout = new VerticalLayout("box");
            {
                foreach (var todo in ModelLoader.Model.ToDos)
                {
                    var todoView = new ToDoView(todo);

                    verticalLayout.AddChild(todoView);

                    mShowFinished.Bind(showFinished =>
                    {
                        if (todoView.model.mFinished.Value==showFinished)
                        {
                            todoView.Show();
                        }
                        else
                        {
                            todoView.Hide();
                        }
                    });
                }
                AddChild(verticalLayout);

                mShowFinished.Value = false;
            }
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
