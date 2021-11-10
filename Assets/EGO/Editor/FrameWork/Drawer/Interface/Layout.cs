/**
*┌──────────────────────────────────────────────────────────────┐
*│　描   述：布局的基类                                                    
*│　作   者：zhangren                                              
*│　版   本：1.0                                                 
*│　创建时间：2021/11/9 16:36:26                             
*└──────────────────────────────────────────────────────────────┘
*┌──────────────────────────────────────────────────────────────┐
*│　命名空间: Assets.EGO.Editor.FrameWork.Drawer.Interface                                   
*│　类   名：Layout                                      
*└──────────────────────────────────────────────────────────────┘
*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGO.FrameWork
{
    public abstract class Layout : View, ILayout
    {
        public List<IView> mChilds { get; set; } = new List<IView>();
        public void AddChild(IView view)
        {
            mChilds.Add(view);
        }

        public void RemoveChild(IView view)
        {
            mChilds.Remove(view);
        }

        protected override void OnGUI()
        {
            OnLayoutBegin();
            foreach (var child in mChilds)
            {
                child.DrawGUI();
            }
            OnLayoutEnd();
        }

        protected abstract void OnLayoutBegin();
        protected abstract void OnLayoutEnd();
    }
}
