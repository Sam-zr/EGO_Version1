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

