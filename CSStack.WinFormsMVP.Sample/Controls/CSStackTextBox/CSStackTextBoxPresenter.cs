namespace CSStack.WinFormsMVP.Sample
{
    public sealed class CSStackTextBoxPresenter : PresenterBase<ICSStackTextBoxView, CSStackTextBoxPresenter>
    {
        public CSStackTextBoxPresenter(ICSStackTextBoxView view)
            : base(view)
        {
        }
    }
}
