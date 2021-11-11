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

        private List<GUILayoutOption> mLayoutOptions { get;} = new List<GUILayoutOption>();

        public GUILayoutOption[] mStyles;

        public void Show()
        {
            mVisible = true;
        }

        public void Hide()
        {
            mVisible = false;
        }

        public bool mIsBeforeDrawGUI = false;

        public void BeforeDrawGUI()
        {
            if (mIsBeforeDrawGUI)
            {
                return;
            }
            mIsBeforeDrawGUI = true;
            mStyles = mLayoutOptions.ToArray();
        }

        public void DrawGUI()
        {
            if (mVisible == true)
            {
                BeforeDrawGUI();

                OnGUI();
            }
        }

        protected abstract void OnGUI();

        public ILayout Parent { get; set; }

        public void RemoveFromParent()
        {
            Parent.RemoveChild(this);
        }

        public void AddLayoutOption(GUILayoutOption option)
        {
            mLayoutOptions.Add(option);
        }
    }
}
