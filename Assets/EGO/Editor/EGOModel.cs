using EGO.FrameWork;
using EGO.Util;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using UnityEditor;

namespace EGO.V_1
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

        public DateTime CreateAt = DateTime.Now;

        public DateTime FinishedAt;

        public DateTime StartTime;

        public Property<TodoState> State=new Property<TodoState>(TodoState.NotStart);
    }

    public enum TodoState
    {
        NotStart,
        Started,
        Done,
    }
}

namespace EGO
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

        public Property<bool> mFinished;
    }
}

