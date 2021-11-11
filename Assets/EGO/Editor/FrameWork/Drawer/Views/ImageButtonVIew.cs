/**
*┌──────────────────────────────────────────────────────────────┐
*│　描   述：                                                    
*│　作   者：zhangren                                              
*│　版   本：1.0                                                 
*│　创建时间：2021/11/11 18:02:34                             
*└──────────────────────────────────────────────────────────────┘
*┌──────────────────────────────────────────────────────────────┐
*│　命名空间: Assets.EGO.Editor.FrameWork.Drawer.Views                                   
*│　类   名：ImageButtonVIew                                      
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
    class ImageButtonVIew:View
    {
        public Action MOnClickAction { get; set; }
        public string MTexturePath { get; set; }

        private Texture2D texture2D;

        public ImageButtonVIew(string  texturePath, Action onClickAction)
        {
            texture2D = Resources.Load<Texture2D>("Icon/"+texturePath);
            MOnClickAction = onClickAction;
        }

        protected override void OnGUI()
        {
            if (GUILayout.Button(texture2D, mStyles))
            {
                MOnClickAction.Invoke();
            }
        }
    }
}
