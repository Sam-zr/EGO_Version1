/**
*┌──────────────────────────────────────────────────────────────┐
*│　描   述：                                                    
*│　作   者：zhangren                                              
*│　版   本：1.0                                                 
*│　创建时间：2021/11/9 10:15:05                             
*└──────────────────────────────────────────────────────────────┘
*┌──────────────────────────────────────────────────────────────┐
*│　命名空间: Assets.EGO.Editor.Util                                   
*│　类   名：ModelLoader                                      
*└──────────────────────────────────────────────────────────────┘
*/


using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

namespace EGO.Util
{
    public static class ModelLoader
    {
        public const string EGO_TODO = "EGO_TODO3";

        private static ToDoList mModel = null;

        public static ToDoList Model 
        {
            get 
            {
                if (mModel==null)
                {
                    Load();
                }
                return mModel;
            }
        }

        public static ToDoList Load()
        {
            var todoContent = EditorPrefs.GetString(EGO_TODO, string.Empty);

            //Debug.Log(todoContent);
            if (string.IsNullOrEmpty(todoContent))
            {
                return mModel=new ToDoList();
            }

            try
            {
                var deprecated = JsonConvert.DeserializeObject<Deprecated.ToDoList>(todoContent);

                todoContent=ModelUpdate.Update(deprecated);
            }
            catch (Exception e)
            {
                Debug.Log(e);
            }

            return mModel=JsonConvert.DeserializeObject<ToDoList>(todoContent);
        }

        public static void Save(ToDoList toDoList)
        {
            Debug.Log(JsonConvert.SerializeObject(toDoList));
            EditorPrefs.SetString(EGO_TODO, JsonConvert.SerializeObject(toDoList));
        }
    }
}
