/**
*┌──────────────────────────────────────────────────────────────┐
*│　描   述：                                                    
*│　作   者：zhangren                                              
*│　版   本：1.0                                                 
*│　创建时间：2021/11/10 12:14:02                             
*└──────────────────────────────────────────────────────────────┘
*┌──────────────────────────────────────────────────────────────┐
*│　命名空间: Assets.EGO.Editor.ViewController                                   
*│　类   名：ToDoView                                      
*└──────────────────────────────────────────────────────────────┘
*/

using EGO.FrameWork;
using EGO.Util;
using UnityEngine;

namespace EGO.ViewController
{
    class ToDoView:HorizontalLayout
    {
        public V_1.ToDo mModel;

        ButtonView mBtnStart;
        ButtonView mBtnFinish;
        ButtonView mBtnReset;

        public ToDoView(V_1.ToDo toDo)
        {
            mModel = toDo;

            mBtnStart = new ButtonView("开始", () =>
            {
                mModel.State.Value = V_1.TodoState.Started;
                Refresh();
            }).Width(50);

            mBtnFinish = new ButtonView("完成", () =>
            {
                mModel.State.Value = V_1.TodoState.Done;
                Refresh();
            }).Width(50);

            mBtnReset = new ButtonView("重置", () =>
            {
                mModel.State.Value = V_1.TodoState.NotStart;
                Refresh();
            }).Width(50);

            AddChild(mBtnStart);
            AddChild(mBtnFinish);
            AddChild(mBtnReset);


            var Label = new CustomView(() =>
              {
                  GUILayout.Label(mModel.mContent);
              });

            AddChild(Label);

            var button = new ButtonView("删除", () =>
            {
                mModel.State.UnBindAll();
                ModelLoader<V_1.ToDoList>.Model.ToDos.Remove(mModel);
                ModelExtension.Save(ModelLoader<V_1.ToDoList>.Model);

                RemoveFromParent();
            }).Width(60);
            AddChild(button);
        }

        protected override void OnBeforeDrawGUI()
        {
            Refresh();
        }

        protected override void OnRefresh()
        {
            switch (mModel.State.Value)
            {
                case V_1.TodoState.NotStart:
                    mBtnStart.Show();
                    mBtnFinish.Hide();
                    mBtnReset.Hide();
                    break;
                case V_1.TodoState.Started:
                    mBtnStart.Hide();
                    mBtnFinish.Show();
                    mBtnReset.Hide();
                    break;
                case V_1.TodoState.Done:
                    mBtnStart.Hide();
                    mBtnFinish.Hide();
                    mBtnReset.Show();
                    break;
                default:
                    break;
            }

            //if (mModel.State.Value==V_1.TodoState.Done)
            //{
            //    RemoveFromParent();
            //}
        }
    }
}
