/**
*┌──────────────────────────────────────────────────────────────┐
*│　描   述：                                                    
*│　作   者：zhangren                                              
*│　版   本：1.0                                                 
*│　创建时间：2021/11/8 18:16:11                             
*└──────────────────────────────────────────────────────────────┘
*┌──────────────────────────────────────────────────────────────┐
*│　命名空间: Assets.EGO.Editor.Deprecated                                   
*│　类   名：DeprecatedModel                                      
*└──────────────────────────────────────────────────────────────┘
*/


using System;
using System.Collections.Generic;

//弃用的
namespace EGO.Deprecated
{

    [Serializable]
    public class ToDoList
    {
        public List<ToDo> ToDos = new List<ToDo>();
    }

    [Serializable]
    public class ToDo
    {
        public string mContent;
        public bool mFinished;
        public bool mFinishedValueChanged { get; set; }
        public bool mFinishedValue
        {
            get => mFinished;
            set
            {
                if (mFinished != value)
                {
                    mFinishedValueChanged = true;
                    mFinished = value;
                }
            }
        }
        public ToDo(string content, bool finished)
        {
            mContent = content;
            mFinished = finished;
        }
    }
}
