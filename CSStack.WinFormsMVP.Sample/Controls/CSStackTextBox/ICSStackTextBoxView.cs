namespace CSStack.WinFormsMVP.Sample
{
    public interface ICSStackTextBoxView : IView<CSStackTextBoxPresenter>
    {
        string Text { get; set; }
    }
}
