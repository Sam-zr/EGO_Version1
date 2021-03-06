/**
*┌──────────────────────────────────────────────────────────────┐
*│　描   述：                                                    
*│　作   者：zhangren                                              
*│　版   本：1.0                                                 
*│　创建时间：2021/11/9 14:16:35                             
*└──────────────────────────────────────────────────────────────┘
*┌──────────────────────────────────────────────────────────────┐
*│　命名空间: Assets.EGO.Editor.FrameWork.Drawer.Views                                   
*│　类   名：ButtonView                                      
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
    class ButtonView : View
    {
        public Action mOnClickAction { get; set; }
        public string mButtonContent { get; set; }

        public ButtonView(string buttonContent,Action onClickAction)
        {
            mButtonContent = buttonContent;
            mOnClickAction = onClickAction;
        }

        protected override void OnGUI()
        {
            if (GUILayout.Button(mButtonContent, mStyles))
            {
                mOnClickAction.Invoke();
            }
        }
    }
}
