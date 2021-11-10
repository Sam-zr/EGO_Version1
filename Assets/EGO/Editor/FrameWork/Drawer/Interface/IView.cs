namespace EGO.FrameWork
{
    public interface IView
    {
        ILayout Parent { get; set; }
        void Show();
        void Hide();
        void DrawGUI();
        void RemoveFromParent();
    }
}
