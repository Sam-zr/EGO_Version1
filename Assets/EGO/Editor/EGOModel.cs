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

        public List<ToDo> ToDos = new List<ToDo>();

        //public void Save()
        //{
        //    EditorPrefs.SetString(ModelLoader.EGO_TODO, JsonConvert.SerializeObject(this));
        //}
    }

    [Serializable]
    public class ToDo
    {
        public string mContent;

        public Property<bool> mFinished;
    }
}

