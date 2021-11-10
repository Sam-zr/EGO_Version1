using UnityEngine;

namespace EGO.FrameWork
{
    public class VerticalLayout : Layout
    {
        public string mStyle { get; set; }

        public VerticalLayout(string style=null)
        {
            mStyle = style;
        }

        protected override void OnLayoutBegin()
        {
            if (string.IsNullOrEmpty(mStyle))
            {
                GUILayout.BeginVertical();
            }
            else
            {
                GUILayout.BeginVertical(mStyle);
            }
        }

        protected override void OnLayoutEnd()
        {
            GUILayout.EndVertical();
        }
    }
}
