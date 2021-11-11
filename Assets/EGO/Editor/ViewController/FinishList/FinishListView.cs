/**
*┌──────────────────────────────────────────────────────────────┐
*│　描   述：                                                    
*│　作   者：zhangren                                              
*│　版   本：1.0                                                 
*│　创建时间：2021/11/11 16:13:50                             
*└──────────────────────────────────────────────────────────────┘
*┌──────────────────────────────────────────────────────────────┐
*│　命名空间: Assets.EGO.Editor.ViewController.FinishTodoList                                   
*│　类   名：FinishListView                                      
*└──────────────────────────────────────────────────────────────┘
*/


using EGO.FrameWork;
using EGO.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGO.ViewController
{
    public class FinishListView : VerticalLayout
    {
        public Property<bool> mShowFinished = new Property<bool>(true);

        public FinishListView()
        {
            mStyle = "Box";

            foreach (var todo in ModelLoader<V_1.ToDoList>.Model.ToDos.Where(todo=>todo.State.Value==V_1.TodoState.Done))
            {
                CreateToDoView(todo);
            }

            AddChild(mTodosParentContainer);

            mShowFinished.Value = false;
        }

        ILayout mTodosParentContainer = new VerticalLayout("box");

        public void CreateToDoView(V_1.ToDo todo)
        {
            var todoView = new ToDoView(todo);

            mTodosParentContainer.AddChild(todoView);
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
