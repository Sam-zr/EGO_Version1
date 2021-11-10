using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace EGO.FrameWork
{
    class ToolBarView : View
    {
        public ToolBarView()
        {
            Index = new Property<int>(0);
            Index.Bind(newIndex =>
            {
                MenuActions[newIndex].Invoke(MenuNames[newIndex]);
            });
        }

        public List<string> MenuNames { get; set; } = new List<string>();

        public List<Action<string>> MenuActions { get; set; } = new List<Action<string>>();

        public Property<int> Index { get; private set; }

        public void AddMenu(string Name,Action<string> action)
        {
            MenuNames.Add(Name);
            MenuActions.Add(action);
        }

        protected override void OnGUI()
        {
            Index.Value = GUILayout.Toolbar(Index.Value, MenuNames.ToArray<string>());
        }
    }
}
