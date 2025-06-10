namespace CSStack.WinFormsMVP.Sample
{
	public sealed class MainFormPresenter
	{
		public MainFormPresenter(IMainFormView view)
		{
			View = view;
			View.SubmitAction += OnSubmitAction;
			View.DisplayText = "テキストボックスに何か入力してボタンを押してください";
			View.Show();
		}

		public IMainFormView View { get; }

		public void OnSubmitAction(object? sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(View.InputText))
			{
				View.DisplayText = "テキストボックスに何か入力してボタンを押してください";
			}
			else
			{
				View.DisplayText = $"入力された文字: {View.InputText}";
			}
		}
	}
}
