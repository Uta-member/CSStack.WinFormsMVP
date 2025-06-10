namespace CSStack.WinFormsMVP.Sample
{
    public interface IMainFormView : IView<MainFormPresenter>
    {
        event EventHandler? SubmitAction;

        string DisplayText { get; set; }

        string InputText { get; set; }
    }
}
