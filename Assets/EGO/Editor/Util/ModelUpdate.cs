/**
*┌──────────────────────────────────────────────────────────────┐
*│　描   述：更新模型                                                    
*│　作   者：zhangren                                              
*│　版   本：1.0                                                 
*│　创建时间：2021/11/9 10:12:37                             
*└──────────────────────────────────────────────────────────────┘
*┌──────────────────────────────────────────────────────────────┐
*│　命名空间: Assets.EGO.Editor.Util                                   
*│　类   名：ModelUpdate                                      
*└──────────────────────────────────────────────────────────────┘
*/


using EGO.FrameWork;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace EGO.Util
{
    class ModelUpdate
    {
        public static string Update(object oldValue)
        {
            Debug.Log("准备升级数据结构");
            if (oldValue.GetType()==typeof(Deprecated.ToDoList))
            {
                var deprecated = oldValue as Deprecated.ToDoList;

                Debug.Log("开始升级数据结构");

                var newVersionToDos = deprecated.ToDos.Select(todo => new ToDo()
                {
                    mContent = todo.mContent,
                    mFinished = new Property<bool>(todo.mFinished)
                }).ToList();

                var newVersionToDoList = new ToDoList()
                {
                    ToDos = newVersionToDos
                };

                ModelLoader.Save();

                return JsonConvert.SerializeObject(newVersionToDoList);
            }
            return JsonConvert.SerializeObject(new ToDoList());
        }
    }

    public class ModelUpdateCommand_Ver_1 : UpdateAction<ToDoList, V_1.ToDoList>
    {
        public override V_1.ToDoList ConvertOld2New(ToDoList oldModel)
        {
            var newTodoList = new V_1.ToDoList();

            foreach (var oldTodo in oldModel.ToDos)
            {
                var newTodo = new V_1.ToDo();

                newTodo.mContent = oldTodo.mContent;
                newTodo.State.Value = oldTodo.mFinished.Value ? V_1.TodoState.Done : V_1.TodoState.NotStart;

                newTodoList.ToDos.Add(newTodo);
            }
            return newTodoList;
        }
    }

    public abstract class UpdateAction<TOldModel, TNewModel> 
        where TNewModel:class
        where TOldModel:class
    {
        public TNewModel Result { get; private set;  }

        public void Execute(object oldValue)
        {
            Result = ConvertOld2New(oldValue as TOldModel);
        }

        public abstract TNewModel ConvertOld2New(TOldModel oldModel);
    }
}
