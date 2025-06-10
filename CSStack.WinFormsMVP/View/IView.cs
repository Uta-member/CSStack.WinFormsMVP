namespace CSStack.WinFormsMVP
{
    public interface IView<TPresenter>
    {
        TPresenter Presenter { get; set; }
    }
}
