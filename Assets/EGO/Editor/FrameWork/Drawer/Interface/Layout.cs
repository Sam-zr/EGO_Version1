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

namespace EGO.FrameWork
{
    public abstract class Layout : View, ILayout
    {
        public List<IView> mChilds { get; set; } = new List<IView>();

        Queue<Action> Commonds = new Queue<Action>();

        public void AddChild(IView view)
        {
            mChilds.Add(view);
            view.Parent = this;
        }

        public void RemoveChild(IView view)
        {
            Commonds.Enqueue(() =>
            {
                mChilds.Remove(view);
            });
        }

        public override void Refresh()
        {
            mChilds.ForEach(view => view.Refresh());
            base.Refresh();
        }

        protected override void OnGUI()
        {
            OnLayoutBegin();
            foreach (var child in mChilds)
            {
                child.DrawGUI();
            }
            OnLayoutEnd();

            while (Commonds.Count>0)
            {
                Commonds.Dequeue().Invoke();
            }
        }

        protected abstract void OnLayoutBegin();
        protected abstract void OnLayoutEnd();
    }
}
