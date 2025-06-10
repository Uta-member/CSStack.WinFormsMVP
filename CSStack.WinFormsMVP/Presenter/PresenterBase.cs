namespace CSStack.WinFormsMVP
{
    public abstract class PresenterBase<TView, TSelf> : IPresenter<TView>
        where TView : IView<TSelf>
        where TSelf : PresenterBase<TView, TSelf>
    {
        public PresenterBase(TView view)
        {
            View = view;
            View.Presenter = (TSelf)this;
        }

        public TView View { get; }
    }
}