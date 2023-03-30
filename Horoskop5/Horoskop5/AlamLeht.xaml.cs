using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Horoskop5
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AlamLeht : ContentPage
    {
        Label lbl, lbl2;
        Image img;
        Switch sw;
        Button btn;
        string infoUri;
        public AlamLeht(string title, string file, string description, string info)
        {
            lbl = new Label
            {
                Text = title,
                FontAttributes = FontAttributes.Bold,
                FontSize = Device.GetNamedSize(NamedSize.Title, typeof(Label)),
                TextColor = Color.Blue,
                HorizontalOptions = LayoutOptions.Center
            };
            infoUri = info;
            lbl2 = new Label
            {
                Text = description,
                FontSize = Device.GetNamedSize(NamedSize.Title, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center
            };
            img = new Image { Source = file };
            btn = new Button
            {
                Text = "Подробнее",
                BackgroundColor = Color.Violet
            };
            btn.Clicked += Btn_Clicked;
            Content = new StackLayout
            {
                Children = { lbl, lbl2, btn, img }
            };
        }

        private async void Btn_Clicked(object sender, EventArgs e)
        {
            await Browser.OpenAsync(infoUri);
        }
    }
}