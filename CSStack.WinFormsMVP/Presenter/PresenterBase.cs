namespace CSStack.WinFormsMVP
{
	/// <summary>
	/// Presenterのベースクラス
	/// </summary>
	/// <typeparam name="TView">Viewの型。IViewを実装したものを渡してください。</typeparam>
	/// <typeparam name="TSelf">継承先クラスの型。</typeparam>
	public abstract class PresenterBase<TView, TSelf> : IPresenter<TView> where TView : IView<TSelf>
		where TSelf : PresenterBase<TView, TSelf>
	{
		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="view">Viewのインスタンス</param>
		public PresenterBase(TView view)
		{
			View = view;
		}

		/// <inheritdoc/>
		public TView View { get; }
	}
}