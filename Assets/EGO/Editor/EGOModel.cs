/**
*┌──────────────────────────────────────────────────────────────┐
*│　描   述：                                                    
*│　作   者：zhangren                                              
*│　版   本：1.0                                                 
*│　创建时间：2021/11/5 17:09:07                             
*└──────────────────────────────────────────────────────────────┘
*┌──────────────────────────────────────────────────────────────┐
*│　命名空间: Assets.EGO.Editor                                   
*│　类   名：EGOModel                                      
*└──────────────────────────────────────────────────────────────┘
*/



using EGO.FrameWork;
using EGO.Util;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using UnityEditor;

namespace EGO
{
    [Serializable]
    public class ToDoList
    {
        //private static readonly string EGO_TODO = "EGO_TODO"; 

        public List<ToDo> ToDos = new List<ToDo>();

        public void Save()
        {
            //Debug.Log(JsonConvert.SerializeObject(this));
            EditorPrefs.SetString(ModelLoader.EGO_TODO, JsonConvert.SerializeObject(this));
        }
    }

    [Serializable]
    public class ToDo
    {
        public string mContent;

        public Property<bool> mFinished;
    }
}

