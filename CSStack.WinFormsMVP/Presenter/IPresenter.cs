namespace CSStack.WinFormsMVP
{
    public interface IPresenter<TView>
    {
        TView View { get; }
    }
}
