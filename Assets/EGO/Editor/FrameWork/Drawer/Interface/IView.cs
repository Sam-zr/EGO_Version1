using System.Collections.Generic;
using UnityEngine;

namespace EGO.FrameWork
{
    public interface IView
    {
        ILayout Parent { get; set; }
        List<GUILayoutOption> LayoutOptions { get; }
        void Show();
        void Hide();
        void DrawGUI();
        void RemoveFromParent();
    }
}
