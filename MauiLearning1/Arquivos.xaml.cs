using CommunityToolkit.Maui.Storage;
using CommunityToolkit.Maui.Views;
using Microsoft.Maui.Controls.Shapes;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace MauiLearning1;

public partial class Arquivos : ContentPage
{
    public string UserName { get; set; }
    public Arquivos()
    {
        InitializeComponent();
        #region estilização de labels e cards
        SetBold(LblArchives, "Archives", "");
        PopulaCards();
        #endregion


    }

    private void BtnDelete_Clicked(object sender, EventArgs e)
    {
        DisplayAlert("Are you sure?", "You will delete permantly this archive, do u have certain?", "Return", "Continue");
    }

    private async void PopulaCards()
    {
        var arquivos = await SelecionaPasta();

        foreach (var item in arquivos) 
        {
            var card = new FileCard();
           SetBold(card.LblFileName, "File Name:", item.Nome!);
           SetBold(card.LblAuthor  , "Author:"   , item.Autor!);
           SetBold(card.LblData    , "Data:"     , item.Data!);
           SetBold(card.LblType    , "Type:"     , item.Tipo!);
            Flex.Children.Add(card);
        }
    }
    private async Task<List<ArquivosDetalhes>> SelecionaPasta()
    {

        var result = new List<FileCard>();
        var folder = await FolderPicker.Default.PickAsync();
        var Arquivos = new List<ArquivosDetalhes>();
        if (folder is null)
        {
            await DisplayAlert("Alerta", "É necessário selecionar uma pasta!", "Ok", "Voltar");
        }

        string caminho = folder!.Folder!.Path;

        var CaminhoArquivos = Directory.GetFiles(caminho);

        foreach (var item in CaminhoArquivos)
        {
            var Arquivo = new ArquivosDetalhes();
            Arquivo.Data = File.GetCreationTime(item).ToString("dd/MM/yyyy");
            Arquivo.Tipo = System.IO.Path.GetExtension(item).ToLower().Replace(".",""); 
            Arquivo.Nome = System.IO.Path.GetFileName(item) ;
            Arquivo.Autor = "";
            Arquivos.Add(Arquivo);
        }

        return Arquivos;
    }

    public void SetBold(Label label, string title, string value)
    {
        label.Text = $"<strong>{title}</strong> {value}";
    }
    private async void BtnUpdate_Clicked(object sender, EventArgs e)
    {
        var result = await FilePicker.PickAsync(new PickOptions
        {
            PickerTitle = "Selecione um arquivo"
        });

        if (result != null)
        {
            var stream = await result.OpenReadAsync();
        }
    }

    private async void BtnView_Clicked(object sender, EventArgs e)
    {
        await this.ShowPopupAsync(new ViewArchive("C:\\MAUI\\Archives Teste\\TESTETXT.txt"));

        /**** Alternatively, Shell.Current can be used to display a Popup

        await Shell.Current.ShowPopupAsync(new Label
        {
            Text = "This is a very important message!"
        }, new PopupOptions
        {
            CanBeDismissedByTappingOutsideOfPopup = false,
            Shape = new RoundRectangle
            {
                CornerRadius = new CornerRadius(20, 20, 20, 20),
                StrokeThickness = 2,
                Stroke = Colors.LightGray
            }
        })
        ****/
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

        UserName = login;
        LblUser.Text = $"Welcome <strong>{UserName}</strong>!";
    }
}
