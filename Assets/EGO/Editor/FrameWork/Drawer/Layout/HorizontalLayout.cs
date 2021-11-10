using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace EGO.FrameWork
{
    public class HorizontalLayout : Layout
    {
        public string mStyle { get; set; }

        public HorizontalLayout(string style=null)
        {
            mStyle = style;
        }

        protected override void OnLayoutBegin()
        {
            if (string.IsNullOrEmpty(mStyle))
            {
                GUILayout.BeginHorizontal();
            }
            else
            {
                GUILayout.BeginHorizontal(mStyle);
            }
        }

        protected override void OnLayoutEnd()
        {
            GUILayout.EndHorizontal();
        }
    }
}
