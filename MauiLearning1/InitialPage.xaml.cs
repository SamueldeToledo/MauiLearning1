namespace MauiLearning1;

public partial class InitialPage : ContentPage
{
    public string Login { get; set; }
    public InitialPage()
    {
        InitializeComponent();
        RetornaLogin();
        
    }

    private async void RetornaLogin()
    {
        var login = await SecureStorage.Default.GetAsync("Login");

        if (!string.IsNullOrEmpty(login))
            HabilitaBemVindo();

        lblArchiveManipulator.Text = "<strong>Archive Manipulator</strong>";
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await SecureStorage.Default.SetAsync("Login", Login);
        await DisplayAlert("Login", "Login efetuado com sucesso!", "OK");

        HabilitaBemVindo();
    }

    private async void HabilitaBemVindo()
    {
        ELogin.IsVisible = false;
        ESenha.IsVisible = false;
        BtnLogin.IsVisible = false;
        Login = await SecureStorage.Default.GetAsync("Login");
        LblBemVindo.Text = $"<p>Bem vindo <span style=\"font-weight:bold; color:#5f4f7d;\">{Login}</span></p>";
    }
}