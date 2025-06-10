namespace CSStack.WinFormsMVP.Sample
{
	public interface ISubFormView
	{
		event EventHandler? SubmitAction;

		string DisplayText { get; set; }

		string InputText { get; set; }

		SubFormPresenter Presenter { get; }
	}
}
