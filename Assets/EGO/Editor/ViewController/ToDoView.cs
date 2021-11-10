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

namespace EGO.ViewController
{
    class ToDoView:HorizontalLayout
    {
        public ToDo model;
        public ToDoView(ToDo toDo)
        {
            model = toDo;

            var toggle = new ToggleView(model.mContent, model.mFinished.Value);
            toggle.mToggle.Bind(mValue => model.mFinished.Value = mValue);
            AddChild(toggle);

            var button = new ButtonView("删除", () =>
            {
                model.mFinished.UnBindAll();
                ModelLoader.Model.ToDos.Remove(model);
                ModelLoader.Model.Save();

                this.RemoveFromParent();
            });
            AddChild(button);
        }
    }
}
