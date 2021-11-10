using EGO.FrameWork;
using EGO.Util;
using EGO.ViewController;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace EGO
{
    public class EGOWindow : Window
    {
        private bool isShwoing = false; 

        [MenuItem("EGO/MainWindow %w")]
        public static void Open()
        {
            var window = GetWindow<EGOWindow>(true);

            if (!window.isShwoing)
            {
                //showUtility为true时的窗口不能显示图标
                var mainTexture = Resources.Load<Texture>("Icon/3-01");
                window.titleContent = new GUIContent("MainWindow", mainTexture);

                window.mToDoList = ModelLoader.Load();

                window.Init();
                window.Show();
                window.isShwoing = true;

                window.mToDoList.ToDos.ForEach(
                    todo => todo.mFinished.Bind(_=>window.mToDoList.Save()));
            }
            else
            {
                window.Reset();
                window.mToDoList.ToDos.ForEach(
                    todo => todo.mFinished.UnBindAll());
                window.Close();
                window.isShwoing = false;
            }
        }

        public void Init()
        {
            if (viewList == null)
            {
                viewList = new List<IView>();
            }

            mViewController = new ToDoListController()
            {
                OnTodoCreate = newToDo =>
                  {
                      newToDo.mFinished.Bind(_ => mToDoList.Save());
                      mToDoList.ToDos.Add(newToDo);
                      mToDoList.Save();
                  }
            };

            


            viewList.Add(new SpaceView(10));

            var verticalLayout = new VerticalLayout("box");
            {
                foreach (var todo in mToDoList.ToDos)
                {
                    var horizontalLayout = new HorizontalLayout("box");

                    var toggle = new ToggleView(todo.mContent, todo.mFinished.Value);
                    toggle.mToggle.Bind(mValue => todo.mFinished.Value = mValue);
                    horizontalLayout.AddChild(toggle);

                    var button = new ButtonView("删除", () =>
                    {
                        todo.mFinished.UnBindAll();
                        mToDoList.ToDos.Remove(todo);
                        mToDoList.Save();
                    });
                    horizontalLayout.AddChild(button);

                    verticalLayout.AddChild(horizontalLayout);
                }
            }
            viewList.Add(verticalLayout);
        }

        public void Reset()
        {
            if (viewList!=null)
            {
                viewList.Clear();
            }
        }

        public List<IView> viewList;
        string mText = string.Empty;
        private ToDoList mToDoList;
    }
}

