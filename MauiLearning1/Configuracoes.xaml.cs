namespace MauiLearning1;

public partial class Configuracoes : ContentPage
{
    public Configuracoes()
    {
        InitializeComponent();
    }
    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);

        RetornaMainPage();
    }
    private async void RetornaMainPage()
    {
        var login = await SecureStorage.Default.GetAsync("Login");

        if (string.IsNullOrEmpty(login))
        {
            await DisplayAlert("Usuário desconhecido", "É necessário efetuar o login antes de navegar pelas páginas", "Ok");
            await Shell.Current.GoToAsync("//InitialPage");
        }

    }

}