


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;

namespace EGO.FrameWork
{
    public class Window:EditorWindow
    {
        public static Window MainWindow { get; set; }

        public ViewController mViewController { get; set; }

        public void Open()
        {
            
        }

        private void OnGUI()
        {
            mViewController.View.DrawGUI();
        }
    }
}
