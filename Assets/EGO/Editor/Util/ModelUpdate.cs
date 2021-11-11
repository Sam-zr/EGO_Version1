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
        public static TNewModel Update<TNewModel>(string  strOldValue)
            where TNewModel:class
        {
            //转化成旧的数据结构
            var oldValue = JsonConvert.DeserializeObject<ToDoList>(strOldValue);

            var UpdateComm = new ModelUpdateCommand_Ver_1();
            UpdateComm.Execute(oldValue);

            return UpdateComm.Result as TNewModel;
        }
    }

    /// <summary>
    /// 结构升级V_1
    /// </summary>
    public class ModelUpdateCommand_Ver_1 : UpdateAction<ToDoList, V_1.ToDoList>
    {
        public override V_1.ToDoList ConvertOld2New(ToDoList oldModel)
        {
            var newTodoList = new V_1.ToDoList();

            foreach (var oldTodo in oldModel.ToDos)
            {
                var newTodo = new V_1.ToDo();

                newTodo.mContent = oldTodo.mContent;
                newTodo.State.Value = oldTodo.mFinished!=null && oldTodo.mFinished.Value ? V_1.TodoState.Done : V_1.TodoState.NotStart;

                newTodoList.ToDos.Add(newTodo);
            }
            return newTodoList;
        }
    }

    /// <summary>
    /// 数据结构升级基类
    /// </summary>
    /// <typeparam name="TOldModel"></typeparam>
    /// <typeparam name="TNewModel"></typeparam>
    public abstract class UpdateAction<TOldModel, TNewModel> 
        where TNewModel:class
        where TOldModel:class
    {
        public TNewModel Result { get; private set;  }

        /// <summary>
        /// 执行，调用子类实现的抽象方法
        /// </summary>
        /// <param name="oldValue"></param>
        public void Execute(object oldValue)
        {
            Result = ConvertOld2New(oldValue as TOldModel);
        }

        /// <summary>
        /// 旧的数据结构转化为新的
        /// </summary>
        /// <param name="oldModel">旧的数据结构</param>
        /// <returns></returns>
        public abstract TNewModel ConvertOld2New(TOldModel oldModel);
    }
}
