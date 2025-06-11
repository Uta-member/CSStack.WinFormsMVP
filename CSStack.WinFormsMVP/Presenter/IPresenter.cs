namespace CSStack.WinFormsMVP
{
	/// <summary>
	/// Presenterのインターフェース
	/// </summary>
	/// <typeparam name="TView">Viewの型。IViewを実装したものを渡してください。</typeparam>
	public interface IPresenter<TView>
	{
		/// <summary>
		/// View
		/// </summary>
		TView View { get; }
	}
}
