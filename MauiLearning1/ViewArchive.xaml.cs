using CommunityToolkit.Maui.Views;
using IronPdf;
using Microsoft.Maui.Controls.Shapes;
namespace MauiLearning1;

public partial class ViewArchive : Popup
{
	public ViewArchive(string path)
	{
		InitializeComponent();

        if (path.Contains(".txt"))
        {
            LblArchive.IsVisible = true;

            var result = File.ReadAllLines(path);
            LblArchive.Text = string.Join("\n",result); 
        }

        else
        {
            string tempFolder = FileSystem.CacheDirectory;
            string pattern = System.IO.Path.Combine(tempFolder, "pdf_page_*.png");

            using (var pdf = new PdfDocument(path))
            {
                string[] images = pdf.RasterizeToImageFiles(pattern);
                imgArchive.Source = images[0];
                imgArchive.IsVisible = true;
            }
        }
    }
}