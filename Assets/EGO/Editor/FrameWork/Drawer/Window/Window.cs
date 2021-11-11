using System;
using UnityEditor;
using UnityEngine;

namespace EGO.FrameWork
{
    public abstract class Window:EditorWindow,IDisposable
    {
        private bool isShwoing = false;
        
        public static Window MainWindow { get; set; }

        public ViewController mViewController { get; set; }

        public T CreateViewController<T>() where T : ViewController,new()
        {
            T t = new T();
            t.SetUpView();
            return t;
        }

        public static void Open<T>(string title) where T:Window
        {
            var window = GetWindow<T>(true);

            if (!window.isShwoing)
            {
                window.titleContent = new GUIContent(title);
                window.isShwoing = true;
                window.Init();
                window.Show();
            }
            else
            {
                window.isShwoing = false;
                window.Dispose();
                window.Close();
            }
        }

        private void OnGUI()
        {
            mViewController.mView.DrawGUI();
        }

        public void Init()
        {
            OnInit();
        }

        public void Dispose()
        {
            OnDispose();
        }

        public abstract void OnDispose();
        public abstract void OnInit();

    }
}
