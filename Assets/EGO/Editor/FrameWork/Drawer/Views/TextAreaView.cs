/**
*┌──────────────────────────────────────────────────────────────┐
*│　描   述：                                                    
*│　作   者：zhangren                                              
*│　版   本：1.0                                                 
*│　创建时间：2021/11/9 11:34:27                             
*└──────────────────────────────────────────────────────────────┘
*┌──────────────────────────────────────────────────────────────┐
*│　命名空间: Assets.EGO.Editor.FrameWork.Drawer.Views                                   
*│　类   名：TextAreaView                                      
*└──────────────────────────────────────────────────────────────┘
*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

namespace EGO.FrameWork
{
    class TextAreaView : View
    {
        public Property<string> Content { get; set; }

        public TextAreaView(string str = "")
        {
            Content = new Property<string>();
            Content.Value = str;
        }

        protected override void OnGUI()
        {
            Content.Value = EditorGUILayout.TextArea(Content.Value);
        }
    }
}
