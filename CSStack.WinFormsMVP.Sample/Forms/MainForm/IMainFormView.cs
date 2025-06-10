namespace CSStack.WinFormsMVP.Sample
{
	public interface IMainFormView
	{
		event EventHandler? SubmitAction;

		string DisplayText { get; set; }

		string InputText { get; set; }

		void Show();
	}
}
