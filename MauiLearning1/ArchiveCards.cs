using Microsoft.Maui.Controls.Shapes;
using Microsoft.Maui.Layouts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiLearning1
{
    public class FileCard : Border
    {
        public Label LblFileName { get; set; }
        public Label LblAuthor { get; set; }
        public Label LblData { get; set; }
        public Label LblType { get; set; }

        public Button BtnDelete { get; private set; }
        public Button BtnUpdate { get; private set; }
        public Button BtnView { get; private set; }

        public FileCard()
        {
            Margin = new Thickness(0, 10);
            MaximumWidthRequest = 480;
            Stroke = Colors.Black;
            StrokeShape = new RoundRectangle { CornerRadius = new CornerRadius(15, 15, 15, 15) };
            // Layout principal
            var rootLayout = new VerticalStackLayout
            {
                Margin = new Thickness(0, 10),
                Spacing = 5
            };

            // Linha com Nome + Autor + Data
            var infoLayout = new FlexLayout
            {
                AlignItems = FlexAlignItems.Center,
                Direction = FlexDirection.Row,
                Wrap = FlexWrap.Wrap
            };

            LblFileName = new Label
            {
                Margin = new Thickness(10, 2, 5, 0),
                CharacterSpacing = 2,
                FontSize = 13,
                TextType = TextType.Html
            };

            LblAuthor = new Label
            {
                Margin = new Thickness(10, 2, 5, 0),
                CharacterSpacing = 2,
                FontSize = 13,
                TextType = TextType.Html
            };

            LblData = new Label
            {
                Margin = new Thickness(10, 2, 0, 0),
                CharacterSpacing = 2,
                FontSize = 13,
                TextType = TextType.Html
            };

            infoLayout.Children.Add(LblFileName);
            infoLayout.Children.Add(LblAuthor);
            infoLayout.Children.Add(LblData);

            // Label com o tipo
            LblType = new Label
            {
                Margin = new Thickness(20, 0),
                CharacterSpacing = 2,
                FontSize = 13,
                TextType = TextType.Html,
                Text = "Type: "
            };

            // Botões
            var buttonsLayout = new FlexLayout
            {
                Direction = FlexDirection.Row,
                JustifyContent = FlexJustify.End
            };

            BtnDelete = new Button
            {
                Margin = new Thickness(0, 0, 2, 0),
                BackgroundColor = Color.FromArgb("#7D1704"),
                CharacterSpacing = 2,
                CornerRadius = -10,
                Text = "Delete"
            };

            BtnUpdate = new Button
            {
                Margin = new Thickness(0, 0, 2, 0),
                BackgroundColor = Color.FromArgb("#1A5704"),
                CharacterSpacing = 2,
                CornerRadius = -10,
                Text = "Update"
            };

            BtnView = new Button
            {
                Margin = new Thickness(0, 0, 5, 0),
                BackgroundColor = Color.FromArgb("#6E736D"),
                CharacterSpacing = 2,
                CornerRadius = -10,
                Text = "View"
            };

            buttonsLayout.Children.Add(BtnDelete);
            buttonsLayout.Children.Add(BtnUpdate);
            buttonsLayout.Children.Add(BtnView);

            // Adiciona tudo no VerticalStack
            rootLayout.Children.Add(infoLayout);
            rootLayout.Children.Add(LblType);
            rootLayout.Children.Add(buttonsLayout);

            // Border Content
            Content = rootLayout;
        }
    }
}


