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
        public V_1.ToDo model;
        public ToDoView(V_1.ToDo toDo)
        {
            model = toDo;

            var toggle = new ToggleView(model.mContent,
                model.State.Value == V_1.TodoState.NotStart || model.State.Value == V_1.TodoState.NotStart ? false : true);
            toggle.mToggle.Bind(mValue =>
            {
                if (mValue==true)
                {
                    model.State.Value = V_1.TodoState.Done;
                }
                else
                {
                    model.State.Value = V_1.TodoState.NotStart;
                }
            } );
            AddChild(toggle);

            var button = new ButtonView("删除", () =>
            {
                model.State.UnBindAll();
                ModelLoader<V_1.ToDoList>.Model.ToDos.Remove(model);
                ModelExtension.Save(ModelLoader<V_1.ToDoList>.Model);

                this.RemoveFromParent();
            }).Width(60);

            AddChild(button);
        }
    }
}
