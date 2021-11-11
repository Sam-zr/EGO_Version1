using EGO.FrameWork;
using EGO.Util;
using System;
using UnityEngine;

namespace EGO.ViewController
{
    class ToDoListController:FrameWork.ViewController
    {
        public ToDoListView MTodoListView { get; set; } = new ToDoListView();

        public FinishListView MFinishListView { get; set; } = new FinishListView();

        public ToolBarView ToolBarView { get; set; } = new ToolBarView();
 
        public ToDoListController()
        {            
        }

        public override void SetUpView()
        {
            mView.mStyle = "box";

            ToolBarView.AddMenu("清单", content =>
             {
                 MTodoListView.mShowFinished.Value = false;
                 MTodoListView.Show();
                 MFinishListView.Hide();
             });
            ToolBarView.AddMenu("已完成", content =>
            {
                MTodoListView.mShowFinished.Value = true;
                MTodoListView.Hide();
                MFinishListView.Show();
            });

            mView.AddChild(ToolBarView);

            mView.AddChild(MTodoListView);

            mView.AddChild(MFinishListView);
        }
    }
}
