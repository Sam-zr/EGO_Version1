namespace EGO.FrameWork
{
    public interface ILayout:IView
    {
        void AddChild(IView view);

        void RemoveChild(IView view);
    }
}
