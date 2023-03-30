using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Horoskop5
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Start : ContentPage
    {
        public List<Button> buttons { get; set; }
        List<ContentPage> pages { get; set; }
        Picker pk;
        DatePicker dp;
        Image img;
        List<string> files;
        List<string> description;
        List<string> info;
        public Start()
        {
            StackLayout st = new StackLayout();
            buttons = new List<Button>();
            pages = new List<ContentPage>();
            files = new List<string> {
                "oven.jpg",
                "tel.jpg",
                "bliz.jpg",
                "rak.jpg",
                "lev.jpg",
                "deva.jpg",
                "vesi.jpg",
                "skorp.jpgf",
                "strel.jpg",
                "kozer.jpg",
                "vodolei.jpg",
                "ribi.jpg"
            };
            List<string> dirs = new List<string> { "Овен", "Телец", "Близнецы", "Рак", "Лев", "Дева", "Весы", "Скорпион", "Стрелец", "Козерог", "Водолей", "Рыбы" };
            description = new List<string> {
                "Для Овнов 2023 год станет довольно важным временем. Вам необходимо будет окончательно определиться с собственными позициями и мнениями касаемо всех сфер.",
                "Изменения которые Тельцы запустили когда-то давно наконец-то дадут свои плоды. Вы сможете подстроиться под новые обстоятельства и достигнуть больших успехов в работе.",
                "В 2023 году вам должно стать легче. Во всех сферах жизни появится больше стабильности и ясности.",
                "Раков можно поздравить! В 2022 году вы прошли большой путь трансформаций в сфере личных взаимоотношений: избавились от ненужных людей и обрели хороших друзей. В 2023 году вы будете чувствовать себя свободно и появится желание встряхнуться и начать что-то новое.",
                "Львам предстоит пережить краеугольный год с большими изменениями. У вас будет шанс раскрыться и показать себя миру, но будьте осторожны и следите за эмоциями и ментальным здоровьем.",
                "Девам 2023 год принесет много значительных событий. Вы внезапно можете стать для себя мерилом нравственности и вектором духовности. Окружающие будут воспринимать вас, как опору и лидера.",
                "Весам в 2023 году может казаться, что всё вокруг скучно – боритесь с этим и раскрашивайте рутину. Вы будете считать, что кому-то везет больше вас. Поработайте над ответственностью и собранностью.",
                "Для Скорпионов наступает счастливый и наполненный мощными энергиями год.",
                "Стрельцов будет влечь жажда развлечений – захочется праздника жизни. Приходит время действовать по творческому импульсу, а не подчиняться кому-то.",
                "Козероги почувствуют освобождение, разрушатся тяжелые оковы ответственности и напряженности. Вы найдете место для радости и удовольствий, а не только для забот и работы.",
                "Важный год наступает для Водолеев – он будет звать на подвиги. В 2023 году закладывайте фундамент для изменений в будущем.",
                "Рыбы ждет необычный год. Вы будете склонны к уединению. Необходимо избирательно подходить к выбору круга общения."
            };
            info = new List<string>() {
                "https://www.kp.ru/woman/goroskop/goroskop-na-2023-god-oven/",
                "https://www.kp.ru/woman/goroskop/goroskop-na-2023-god-telecz/",
                "https://www.kp.ru/woman/goroskop/goroskop-na-2023-god-bliznetsy/",
                "https://www.kp.ru/woman/goroskop/goroskop-na-2023-god-rak/",
                "https://www.kp.ru/woman/goroskop/goroskop-na-2023-god-lev/",
                "https://www.kp.ru/woman/goroskop/goroskop-na-2023-god-deva/",
                "https://www.kp.ru/woman/goroskop/goroskop-na-2023-god-vesy/",
                "https://www.kp.ru/woman/goroskop/goroskop-na-2023-god-skorpion/",
                "https://www.kp.ru/woman/goroskop/goroskop-na-2023-god-strelets/",
                "https://www.kp.ru/woman/goroskop/goroskop-na-2023-god-kozerog/",
                "https://www.kp.ru/woman/goroskop/goroskop-na-2023-god-vodolej/",
                "https://www.kp.ru/woman/goroskop/goroskop-na-2023-god-ryby/"
            };
            for (int i = 0; i < files.Count; i++)
            {
                AlamLeht p = new AlamLeht(dirs[i], files[i], description[i], info[i]);
                pages.Add(p);
            }
            dp = new DatePicker
            {
                Format = "D"
            };
            dp.DateSelected += Dp_DateSelected;

            pk = new Picker
            {
                ItemsSource = dirs,
                Title = "Выберите знак задиака",
                TitleColor = Color.DarkBlue
            };
            pk.SelectedIndexChanged += Pk_SelectedIndexChanged;
            img = new Image
            {
                Source = "goroskop.jpg"
            };
            st.Children.Add(img);
            SwipeGestureRecognizer swipe = new SwipeGestureRecognizer
            {
                Direction = SwipeDirection.Left
            };
            swipe.Swiped += Swipe_Swiped;
            img.GestureRecognizers.Add(swipe);
            st.Children.Add(dp);
            st.Children.Add(pk);
            Content = st;
        }
        private async void Dp_DateSelected(object sender, DateChangedEventArgs e)
        {
            var m = e.NewDate.Month;
            var d = e.NewDate.Day;

            if (m == 3 && d >= 21 && d <= 31 || m == 4 && d <= 19)//Oven
            {
                await Navigation.PushAsync(pages[0]);
            }
            if (m == 4 && d >= 20 && d <= 30 || m == 5 && d <= 20)//Telec
            {
                await Navigation.PushAsync(pages[1]);
            }
            if (m == 5 && d >= 21 && d <= 31 || m == 6 && d <= 20)//Twins
            {
                await Navigation.PushAsync(pages[2]);
            }
            if (m == 6 && d >= 21 && d <= 30 || m == 7 && d <= 22)//Rak
            {
                await Navigation.PushAsync(pages[3]);
            }
            if (m == 7 && d >= 23 && d <= 31 || m == 8 && d <= 22)//Lev
            {
                await Navigation.PushAsync(pages[4]);
            }
            if (m == 8 && d >= 23 && d <= 31 || m == 9 && d <= 22)//Deva
            {
                await Navigation.PushAsync(pages[5]);
            }
            if (m == 9 && d >= 23 && d <= 31 || m == 10 && d <= 22)//Vesi
            {
                await Navigation.PushAsync(pages[6]);
            }
            if (m == 10 && d >= 23 && d <= 30 || m == 11 && d <= 21)//Skorpion
            {
                await Navigation.PushAsync(pages[7]);
            }
            if (m == 11 && d >= 22 && d <= 31 || m == 12 && d <= 21)//Strelec
            {
                await Navigation.PushAsync(pages[8]);
            }
            if (m == 12 && d >= 22 && d <= 31 || m == 1 && d <= 19)//Kozerok
            {
                await Navigation.PushAsync(pages[9]);
            }
            if (m == 1 && d >= 20 && d <= 31 || m == 2 && d <= 18)//Vodolei
            {
                await Navigation.PushAsync(pages[10]);
            }
            if (m == 2 && d >= 19 && d <= 28 || m == 3 && d <= 20)//Ribi
            {
                await Navigation.PushAsync(pages[11]);
            }
        }

        int i = 0;
        private void Swipe_Swiped(object sender, SwipedEventArgs e)
        {
            if (i < files.Count - 1)
            {
                i++;
            }
            else if (i == files.Count - 1)
            {
                i = 0;
            }
            img.Source = files[i];

        }

        private async void Pk_SelectedIndexChanged(object sender, EventArgs e)
        {
            await Navigation.PushAsync(pages[pk.SelectedIndex]);
        }
    }
}