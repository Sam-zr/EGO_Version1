using Newtonsoft.Json;
using System;
using UnityEditor;
using UnityEngine;

namespace EGO.Util
{
    public static class ModelLoader<TModel>
        where TModel : class, new()
    {
        public const string EGO_TODO = "EGO_TODO3";

        private static TModel mModel = null;

        public static TModel Model
        {
            get
            {
                if (mModel == null)
                {
                    Load();
                }
                return mModel;
            }
        }

        public static TModel Load()
        {
            var todoContent = EditorPrefs.GetString(EGO_TODO, string.Empty);

            if (string.IsNullOrEmpty(todoContent))
            {
                return mModel = new TModel();
            }

            try
            {
                mModel = JsonConvert.DeserializeObject<TModel>(todoContent);
            }
            catch (Exception e)
            {
                mModel = ModelUpdate.Update<TModel>(todoContent);
                Debug.Log(e);
            }

            return mModel = JsonConvert.DeserializeObject<TModel>(todoContent);
        }
    }

    public static class ModelExtension
    {
        public static void Save<TModel>(this TModel toDoList) where TModel : class
        {
            //Debug.Log(JsonConvert.SerializeObject(toDoList));
            EditorPrefs.SetString(ModelLoader<V_1.ToDoList>.EGO_TODO, JsonConvert.SerializeObject(toDoList));
        }
    }
}
