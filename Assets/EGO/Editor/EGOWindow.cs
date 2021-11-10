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
        [MenuItem("EGO/MainWindow %w")]
        public static void Open()
        {
            Open<EGOWindow>("MainWindow");
        }

        public override void OnInit()
        {
            mViewController = CreateViewController<ToDoListController>();
        }

        public override void OnDispose()
        {
            
        }
    }
}

