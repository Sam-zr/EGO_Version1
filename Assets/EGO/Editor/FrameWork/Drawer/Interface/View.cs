/**
*┌──────────────────────────────────────────────────────────────┐
*│　描   述：View的基类                                                    
*│　作   者：zhangren                                              
*│　版   本：1.0                                                 
*│　创建时间：2021/11/9 16:27:32                             
*└──────────────────────────────────────────────────────────────┘
*┌──────────────────────────────────────────────────────────────┐
*│　命名空间: Assets.EGO.Editor.FrameWork.Drawer.Interface                                   
*│　类   名：View                                      
*└──────────────────────────────────────────────────────────────┘
*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace EGO.FrameWork
{
    public abstract class View : IView
    {
        public bool mVisible { get; set; } = true;

        public List<GUILayoutOption> LayoutOptions { get;} = new List<GUILayoutOption>();

        public void Show()
        {
            mVisible = true;
        }

        public void Hide()
        {
            mVisible = false;
        }

        public void DrawGUI()
        {
            if (mVisible == true)
            {
                OnGUI();
            }
        }

        protected abstract void OnGUI();

        public ILayout Parent { get; set; }

        public void RemoveFromParent()
        {
            Parent.RemoveChild(this);
        }
    }
}
