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

            newVersionToDoList.Save();

            return JsonConvert.SerializeObject(newVersionToDoList);
        }
    }
}
