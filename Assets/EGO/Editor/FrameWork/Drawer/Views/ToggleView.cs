/**
*┌──────────────────────────────────────────────────────────────┐
*│　描   述：                                                    
*│　作   者：zhangren                                              
*│　版   本：1.0                                                 
*│　创建时间：2021/11/9 17:18:19                             
*└──────────────────────────────────────────────────────────────┘
*┌──────────────────────────────────────────────────────────────┐
*│　命名空间: Assets.EGO.Editor.FrameWork.Drawer.Views                                   
*│　类   名：ToggleView                                      
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
    class ToggleView : View
    {
        public string mContent { get; set; }

        public Property<bool> mToggle { get; set; }

        public ToggleView(string content,bool finished)
        {
            mContent = content;
            mToggle = new Property<bool>(finished);
        }

        protected override void OnGUI()
        {
            mToggle.Value = GUILayout.Toggle(mToggle.Value, mContent);
        }
    }
}
