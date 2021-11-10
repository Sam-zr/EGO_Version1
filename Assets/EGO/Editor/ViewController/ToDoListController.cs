/**
*┌──────────────────────────────────────────────────────────────┐
*│　描   述：                                                    
*│　作   者：zhangren                                              
*│　版   本：1.0                                                 
*│　创建时间：2021/11/9 20:41:51                             
*└──────────────────────────────────────────────────────────────┘
*┌──────────────────────────────────────────────────────────────┐
*│　命名空间: Assets.EGO.Editor.ViewController                                   
*│　类   名：ToDoList                                      
*└──────────────────────────────────────────────────────────────┘
*/



using EGO.FrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGO.ViewController
{
    class ToDoListController:FrameWork.ViewController
    {

        public Action<ToDo> OnTodoCreate;

        public string mInputContent = string.Empty;
 
        public ToDoListController()
        {
            View.mStyle = "box";

            View.AddChild(new SpaceView());

            var textAreaView = new TextAreaView(mInputContent);
            textAreaView.Content.Bind(newValue => mInputContent = newValue);
            View.AddChild(textAreaView);

            View.AddChild(new ButtonView("添加", () =>
            {
                if (!string.IsNullOrEmpty(mInputContent))
                {
                    var newToDo = new ToDo() { mContent = mInputContent, mFinished = new Property<bool>() };
                    OnTodoCreate(newToDo);
                    mInputContent = string.Empty;
                }
            }));
        }

    }
}
