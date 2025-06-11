namespace CSStack.WinFormsMVP
{
	/// <summary>
	/// Viewのインターフェース
	/// </summary>
	/// <typeparam name="TPresenter">Presenterの型。IPresenterまたはPresenterBaseを継承したものを渡してください。</typeparam>
	public interface IView<TPresenter>
	{
		/// <summary>
		/// Presenter
		/// </summary>
		TPresenter Presenter { get; set; }
	}
}
