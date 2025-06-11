# CSStack.WinFormsMVP

WinForms で MVP フレームワークを採用する際に便利なインターフェースやクラスを提供します。

# 使い方

## View の定義

コントロールに実装させるインターフェースを定義します。Presenter からアクセスしたい View のプロパティやイベントを列挙してください。  
View のインターフェースは`IView`を継承します。なお、ここで`MainFormPresenter`を型引数に渡していますが、MainFormPresenter はこの後定義します。

```csharp:MainFormView
public interface IMainFormView : IView<MainFormPresenter>
{
    event EventHandler? SubmitAction;

    string DisplayText { get; set; }

    string InputText { get; set; }
}
```

## Presenter の定義

Presenter は View のインターフェースを受け取るコンストラクタを持ち、View のプロパティやイベントにアクセスします。
Presenter を定義する際は、`PresenterBase`を継承します。もし`PresenterBase`を継承したくない場合は`IPresenter`を実装し、コンストラクタで View を受け取って View プロパティに代入してください。  
このライブラリでは View と Presenter しか定義しないので Model が存在しませんが、Model は DB アクセスやビジネスロジックを担当するクラスとして定義し、Presenter 内で呼び出します。  
Model の形はライブラリでは厳密に定義しないため、オニオンアーキテクチャ等で定義して、ユースケースのクラスを Presenter のコンストラクタ受け取って操作する形など、柔軟に対応可能です。

```csharp: MainFormPresenter
public sealed class MainFormPresenter : PresenterBase<IMainFormView, MainFormPresenter>
{
	public MainFormPresenter(IMainFormView view)
		: base(view)
	{
		View.SubmitAction += OnSubmitAction;
		View.DisplayText = "テキストボックスに何か入力してボタンを押してください";
	}

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
```

## コントロールの実装

コントロールは先ほど定義した View のインターフェース（`IMainFormView`）を実装し、コントロール内の各プロパティと View のインターフェースに定義されたものを紐づけます。  
今回の例では、`MainForm`というフォームを作成し、Label、TextBox、Button を配置しています。  
`DisplayText`や`InputText`等のようなプロパティは、コントロールのプロパティに直接アクセスする形で実装します。  
`SubmitAction`のようなイベントは、コントロールのイベントハンドラにデリゲートとして登録し、View のイベントを呼び出します。  
また、コンストラクタの`InitializeComponent()`より後で必ず Presenter のコンストラクタを呼び出してください。これを呼び出さないと View の各プロパティなどが Presenter に送られず、コントロールが正しく動作しません。

```csharp:MainForm
public partial class MainForm : Form, IMainFormView
{
    public MainForm()
    {
        InitializeComponent();
        button1.Click += delegate
        {
            SubmitAction?.Invoke(this, EventArgs.Empty);
        };
        Presenter = new MainFormPresenter(this);
    }

    public event EventHandler? SubmitAction;

    public string DisplayText
    {
        get
        {
            return label1.Text;
        }
        set
        {
            label1.Text = value;
        }
    }

    public string InputText
    {
        get
        {
            return textBox1.Text;
        }
        set
        {
            textBox1.Text = value;
        }
    }

    public MainFormPresenter Presenter { get; set; }
}
```

## アプリケーションの起動

最後に、`Program.cs`でアプリケーションを起動します。こちらはデフォルトの状態から変更はありません。起動するフォームの名前が`MainForm`となっているだけです。

```csharp:Program
internal static class Program
{
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    private static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        Application.Run(new MainForm());
    }
}
```

今回の例ではフォームの例を挙げましたが、同じ方法で UserControl やカスタムコントロールも実装できます。これは View のコンストラクタで Presenter を初期化しているためです。  
本来は View は Presenter を参照すべきではありませんが、WinForms ではデザイナを使用する関係上、コントロールの生成に関与できないため、苦肉の策でこのような形になりました。
