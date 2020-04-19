using System;
using System.Collections.Generic;
using System.Windows;
using HtmlAgilityPack;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Windows.Documents;



namespace Kino_3._0
{
    /// <summary>
    /// Логика взаимодействия для KinoFrukt.xaml
    /// </summary>
    public partial class KinoFrukt : Window
    {
        public static string country;
        public static string country2;
        public static string actors;
        public static string actors2;
        public static string director;
        public static string director2;
        public static string year;
        public static string nazv;
        public static string nazv1;
        public static string nazvAngl;
        public static string zhanr;
        public static string image;
        public static int seasonNumber;
        public static string url;
        int YtbIdNumber = 0;


        HtmlNodeCollection nodesNazv;
        HtmlNodeCollection nodesCountry;
        HtmlNodeCollection nodesYear;
        HtmlNodeCollection nodesZhanr;
        HtmlNodeCollection nodesDirector;
        HtmlNodeCollection nodesActors;
        HtmlNodeCollection nodesImage;
        HtmlNodeCollection nodesImage2;


        public KinoFrukt()
        {
            InitializeComponent();
            
            //string key = "Software\\Microsoft\\Windows\\CurrentVersion\\Internet Settings";
            //string serverName = "195.9.237.66";//your proxy server name;
            //string port = "8080"; //your proxy port;
            //string proxy = serverName + ":" + port;

            //RegistryKey RegKey = Registry.CurrentUser.OpenSubKey(key, true);
            //RegKey.SetValue("ProxyServer", proxy);
            //RegKey.SetValue("ProxyEnable", 1);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string siteKinofrukt = "kinofrukt";
            string siteKinopoisk = "kinopoisk";

            if (tbSeasonNumber.Text !="")
                seasonNumber = Int32.Parse(tbSeasonNumber.Text);

            url = tbUrlKF.Text;

            //string GetHtml()
            //{
            //    using (var client = new WebClient())
            //    {

            //        client.Headers.Add("Host", "www.kinopoisk.ru:443");
            //        client.Headers.Add("Accept", "text / html, application / xhtml + xml, application / xml; q = 0.9,image / webp,image / apng,*/*;q=0.8");
            //        client.Headers.Add("Accept-Encoding", "gzip, deflate, br");
            //        client.Headers.Add("Accept-Language", "en-US,en;q=0.9,uk;q=0.8,ru;q=0.7");
            //        client.Headers.Add("Cookie", "PHPSESSID=acves29a8mep728e8usca6mpd6; yandex_gid=143; desktop_session_key=2aa1ff6214bd69f49034817443ba339d549e81b0ec0df6b651a1ad63525285b7ef46c47688421a6e9cdba252f184feb2873991729962cc29f3a6e497db4206c7da8b74c32666eae10c14df3b2b455a51; desktop_session_key.sig=wr4KOKP6CZWaSd4Bzhysufn9R3g; yandexuid=7839672051513866813; my_perpages=%5B%5D; _ym_uid=1518637208818912632; Session_id=3%3A1520689404.5.0.1520689404790%3AsVWOWw%3A11C.1%7C1110000014810420.-1.0%7C30%3A170284.99.JRTf0qI9vm_puxjBreNHI8VGN-8; uid=14810420; mykp_button=edit_main; tc=49; mobile=no; noflash=true; refresh_yandexuid=7839672051513866813; _ym_isad=1; loc2=win; user_country=ua; _ym_visorc_22663942=b");
            //        client.Headers.Add("Upgrade-Insecure-Requests", "1");
            //        client.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/65.0.3325.181 Safari/537.36");
            //        client.Headers.Add("X-Compress", "null");
            //        client.Headers.Add("Referer", url);

            //        return (client.DownloadString(url));
            //    }
            //}
            //string html = GetHtml();


            WebClient webClient = new BetterWebClient();
            

            if (tbUrlKF.Text.Contains(siteKinopoisk))
            {
                //try
                //{
                //webClient.Headers.Add("Host", "www.kinopoisk.ru:443");
                webClient.Headers.Add("Accept", "text / html, application / xhtml + xml, application / xml; q = 0.9,image / webp,image / apng,*/*;q=0.8");
                webClient.Headers.Add("Accept-Encoding", "gzip, deflate, br");
                webClient.Headers.Add("Accept-Language", "en-US,en;q=0.9,uk;q=0.8,ru;q=0.7");
                //webClient.Headers.Add("Cookie", "_ym_uid=1513893969963817275; fuid01=5a3bc78271a7498b.H-wkzmjytz--OeEmGDaOx9P7RK1UyUnVL90Ac98c1TFPHnkJ_rDVsthW6HEg7gKrpYIMt0sYlsRJpqXxpqdzLlk8-xhY9Sqn6d4cBv4mlMVQParrB6P4u1SQCQwVRFJ8; yandexuid=5842653851513866884; my_perpages=%5B%5D; PHPSESSID=v2s920v3buofvjd7vulubili47; yandex_gid=143; mobile=no; refresh_yandexuid=5842653851513866884; user_country=ua; tc=49; noflash=true; _ym_isad=2; _ym_visorc_22663942=b");
                //webClient.Headers.Add("Upgrade-Insecure-Requests", "1");
                webClient.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/65.0.3325.181 Safari/537.36");
                //webClient.Headers.Add("X-Compress", "null");
                //webClient.Headers.Add("Referer", url);
                //}
                //catch
                //{
                    //webClient.Headers.Add("Content-Lang", "ru");
                    //webClient.Headers.Add("Accept", "application/json");
                    //webClient.Headers.Add("UserAgent", "Android client (4.4 / api19), ru.kinopoisk/4.0.2 (52)");
                    //webClient.Headers.Add("device", "android");
                    //webClient.Headers.Add("Android-Api-Version", "19");
                    //webClient.Headers.Add("clientDate", DateTime.Now.ToString("HH:mm dd.MM.yyyy"));
                    //webClient.Headers.Add("Cookie", "PHPSESSID=r2t5uvjq435r4q7ib3vtdjq360");
                    //webClient.Headers.Add("Pragma", "no-cache");
                    //webClient.Headers.Add("Cache-Control", "no-cache");
                //}
            }
            else if (tbUrlKF.Text.Contains(siteKinofrukt))
            {
                webClient.Headers.Add("Content-Type", "text");
                webClient.Encoding = System.Text.Encoding.UTF8;
                webClient.Headers.Add("UserAgent",
                    "Opera/9.80 (Windows NT 6.1; WOW64; MRA 8.2 (build 6870)) Presto/2.12.388 Version/12.16");
            }

            string html = webClient.DownloadString(url);
            string needCapchaKP =
                "https://www.kinopoisk.ru/captcha/voiceintro";
            if (html.Contains(needCapchaKP))
            {
                rtbKF.AppendText("Кинопоиск требует капчу");
                return;
            }

            //убираем всякие закорюки из кода
            if (html.Contains("&nbsp;"))
                html = html.Replace("&nbsp;", " ");
            if (html.Contains("&#233;"))
                html = html.Replace("&#233;", "é");
            if (html.Contains("&eacute;"))
                html = html.Replace("&eacute;", "é");
            if (html.Contains("&laquo;"))
                html = html.Replace("&laquo;", "«");
            if (html.Contains("&raquo;"))
                html = html.Replace("&raquo;", "»");
            if (html.Contains("&#214;"))
                html = html.Replace("&#214;", "Ö");
            if (html.Contains("&#252;"))
                html = html.Replace("&#252;", "ü");
            


            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);
            
            //если в юрл есть слово кинофрукт
            if (tbUrlKF.Text.Contains(siteKinofrukt))
            {
                try
                {
                    //возвращает название
                    nodesNazv = doc.DocumentNode.SelectNodes(
                        "/html/body/div[@class='body2']/div[@class='main-center-block']/div[@class='content-block']/div[@class='right-col']/div[@id='dle-content']/div[@class='main-news']/h1");

                    if (nodesNazv == null)
                        return;
                    foreach (HtmlNode node in nodesNazv)
                    {
                        nazv = node.InnerText;
                        if (nazv.Contains("1,2"))
                            nazv1 = nazv.Substring("", " 1,2");
                        if (nazv.Contains("(фильм"))
                            nazv1 = nazv.Substring("", " (фильм");
                        if (nazv.Contains("(20"))
                            nazv1 = nazv.Substring("", " (20");
                    }

                    
                }
                catch 
                {
                    rtbKF.AppendText("Нет названия!");
                }

                try
                {
                    //возвращает страну
                    nodesCountry = doc.DocumentNode.SelectNodes(
                        "/html/body/div[@class='body2']/div[@class='main-center-block']/div[@class='content-block']/div[@class='right-col']/div[@id='dle-content']/div[@class='main-news']/div[@class='main-news-content']/div[@class='main-news-descr-line'][2]");

                    if (nodesCountry == null)
                        country = "-";
                    foreach (HtmlNode node in nodesCountry)
                    {
                        country = node.InnerText;
                        country2 = country.Substring("var actors = '", "';");
                    }
                }
                catch
                {
                    country = "-";
                }

                try
                {
                    //возвращает год
                    nodesYear = doc.DocumentNode.SelectNodes(
                        "/html/body/div[@class='body2']/div[@class='main-center-block']/div[@class='content-block']/div[@class='right-col']/div[@id='dle-content']/div[@class='main-news']/div[@class='main-news-content']/div[@class='main-news-descr-line'][1]/i/a");

                    if (nodesYear == null)
                        year = "-";
                    foreach (HtmlNode node in nodesYear)
                    {
                        year = node.InnerText;
                    }

                    if (seasonNumber > 1)
                        year = "2018";
                }
                catch
                {
                    year = "-";
                }

                try
                {
                    //возвращает жанр
                    nodesZhanr = doc.DocumentNode.SelectNodes(
                        "/html/body/div[@class='body2']/div[@class='main-center-block']/div[@class='content-block']/div[@class='right-col']/div[@id='dle-content']/div[@class='main-news']/div[@class='main-news-content']/div[@class='main-news-descr-line'][3]/i");

                    if (nodesZhanr == null)
                        zhanr = "-";
                    foreach (HtmlNode node in nodesZhanr)
                    {
                        zhanr = node.InnerText;
                        zhanr = zhanr.ToLower();
                    }
                }
                catch
                {
                    zhanr = "-";
                }

                try
                {
                    //возвращает режиссера
                    nodesDirector = doc.DocumentNode.SelectNodes(
                        "/html/body/div[@class='body2']/div[@class='main-center-block']/div[@class='content-block']/div[@class='right-col']/div[@id='dle-content']/div[@class='main-news']/div[@class='main-news-content']/div[@class='main-news-descr-line'][4]");

                    if (nodesDirector == null)
                        director = "-";
                    foreach (HtmlNode node in nodesDirector)
                    {
                        director = node.InnerText;
                        director2 = director.Substring("var actors = '", "';");
                    }
                }
                catch
                {
                    director = "-";
                }

                try
                {
                    //возвращает актеров
                    nodesActors = doc.DocumentNode.SelectNodes(
                        "/html/body/div[@class='body2']/div[@class='main-center-block']/div[@class='content-block']/div[@class='right-col']/div[@id='dle-content']/div[@class='main-news']/div[@class='main-news-content']/div[@class='main-news-descr-line'][5]");

                    if (nodesActors == null)
                        actors = "-";
                    foreach (HtmlNode node in nodesActors)
                    {
                        actors = node.InnerText;
                        actors2 = actors.Substring("var actors = '", "';");
                    }
                }
                catch
                {
                    actors = "-";
                }

                try
                {
                    //возвращает картинку
                    nodesImage = doc.DocumentNode.SelectNodes(
                        "/html[1]/body[1]/div[3]/div[2]/div[2]/div[2]/div[1]/div[6]/div[2]/div[1]/div[1]/ul[1]/li[2]/div[1]/a[1]/img[1]");


                    if (nodesImage == null)
                        image = "-";
                    foreach (HtmlNode node in nodesImage)
                    {
                        image = node.OuterHtml;
                    }

                    if (image.Contains(nazv) != true)
                    {
                        nodesImage2 = doc.DocumentNode.SelectNodes(
                            "/html/body/div[@class='body2']/div[@class='main-center-block']/div[@class='content-block']/div[@class='right-col']/div[@id='dle-content']/div[@class='main-news']/div[@class='main-news-content']/div[@class='main-news-image']/img/@src");
                        if (nodesImage2 == null)
                            image = "-";
                        foreach (HtmlNode node in nodesImage2)
                        {
                            image = node.OuterHtml;
                        }
                    }
                }
                catch
                {
                    image = "-";
                }

                //если в юрл есть слово кинопоиск
            }
            else if (tbUrlKF.Text.Contains(siteKinopoisk))
            {
                try
                {
                    //возвращает название основное
                    //бывает, что нет русского названия, то русское название пишем в поле внизу у кнопки результат
                    if (tbAnglNazv.Text == "") {
                        if (html.Contains("moviename-big"))
                        {
                            nazv1 = html.Substring("<h1 class=\"moviename-big\" itemprop=\"name\">", "</h1>");
                        }
                        else
                        {
                            nazv1 = html.Substring("<span itemprop=\"alternativeHeadline\">", "</span>");
                        }
                        //var nodesNazv = doc.DocumentNode.SelectSingleNode("//h1[@class='moviename-big' and itemprop='name']");
                        //if (nodesNazv != null)
                        //{
                        //    nazv1 = nodesNazv.InnerText;
                        //}
                    }
                    else
                    {
                        nazv1 = tbAnglNazv.Text;
                    }

                    if (nazv1.Contains(" <span>(сериал"))
                    {
                        nazv1 = nazv1.Substring("", " <span>(сериал");
                    }
                    if (nazv1.Contains(" <span>(видео"))
                    {
                        nazv1 = nazv1.Substring("", " <span>(видео");
                    }
                    if (nazv1.Contains(" <span>(ТВ"))
                    {
                        nazv1 = nazv1.Substring("", " <span>(ТВ");
                    }
                    if (nazv1.Contains(" <span>(мини"))
                    {
                        nazv1 = nazv1.Substring("", " <span>(мини");
                    }

                    
                }
                catch 
                {
                    rtbKF.AppendText("Нет названия!");
                }

                try
                {
                    //возращает название ориг
                    if (tbAnglNazv.Text == "")
                    { 
                        if (html.Contains("alternativeHeadline"))
                        { 
                            nazvAngl = html.Substring("<span itemprop=\"alternativeHeadline\">", "</span>");
                        }
                    }
                    else
                    {
                        nazvAngl = tbAnglNazv.Text;
                    }
                    
                }
                catch
                {
                    nazvAngl = "-";
                }

                try
                {
                    //возвращает страну
                    country2 = html.Substring("<td class=\"type\">страна</td>", "</td>");
                    //country2 = country2.Substring("/\">", "</a>");
                    country2 = StripHtmlTagsUsingRegex(country2);
                    country2 = country2.Replace("\n     ", "");
                    country2 = country2.Trim();
                }
                catch
                {
                    country2 = "-";
                }

                try
                {
                    //возвращает год
                    
                   
                    if (html.Contains("премьера (РФ)"))
                    {
                        year = html.Substring("data-ical-date=\"", "\" data-date-premier");
                        year = year.Substring(year.Length - 4);
                    } else if (html.Contains("премьера (мир)"))
                    {
                        year = html.Substring("title=\"\">", "</a>");
                        year = year.Substring(year.Length - 4);
                    }
                    year = html.Substring("<td class=\"type\">год</td>", "</td>");
                    year = year.Substring("title=\"\">", "</a>");

                    if (seasonNumber > 1)
                        year = "2018";
                }
                catch
                {
                    year = "2018";
                }

                try
                {
                    //возвращает жанр
                    zhanr = html.Substring("<span itemprop=\"genre\">", "an>");
                    string zajve = "</sp";
                    zhanr = zhanr.Replace(zajve, "");
                    zhanr = StripHtmlTagsUsingRegex(zhanr);
                    
                }
                catch
                {
                    zhanr = "-";
                }

                try
                {
                    //возвращает режиссера
                    director2 = html.Substring("<td itemprop=\"director\">", "</td>");
                    director2 = StripHtmlTagsUsingRegex(director2);
                    var zajve = ", ...";
                    director2 = director2.Replace(zajve, "");
                    

                }
                catch
                {
                    director2 = "-";
                }

                try
                {
                    //возвращает актеров
                    actors2 = html.Substring("<li itemprop=\"actors\">", "</li></ul>");
                    var zajve = "</li>";
                    actors2 = actors2.Replace(zajve, ", ");
                    actors2 = StripHtmlTagsUsingRegex(actors2);
                    var zajve2 = ", ...";
                    actors2 = actors2.Replace(zajve2, "");
                    

                }
                catch
                {
                    actors2 = "-";
                }

                try
                {
                    //возвращает картинку
                    image = html.Substring("<a class=\"popupBigImage\"", "</a>");
                    image = image.Substring("src=\"", "\" alt");
                }
                catch
                {
                    image = "-";
                }

            }
            //поисковый запрос в ютуб
            if (cbIfSerial.IsChecked == true)
            {
                if (seasonNumber > 1)
                {
                    Search.q = $"{nazv1} {seasonNumber} сезон ({year}) анонс сериала";
                }
                else
                {
                    Search.q = $"{nazv1} ({year}) анонс сериала";
                }
            }
            else
            {
                Search.q = $"{nazv1} ({year}) трейлер";
            }

            Search.YTBsearch();

            //собираем кусочки
            if (image != "")
                ImageResize.GetImage();
            Sborka();

        }
        static string StripHtmlTagsUsingRegex(string inputString)
        {
            return Regex.Replace(inputString, @"<[^>]*>", String.Empty);

            //если надо какие-то теги оставить, например br и p, то используем <(?!br|p|\/p)[^>]*>
            //return Regex.Replace(inputString, @"<(?!br|p|\/p)[^>]*>", String.Empty);
        }

        

        public static string blockNazv;
        public static string blockCountry;
        public static string blockZhanr;
        public static string blockQuality;
        public static string blockDirector;
        public static string blockActors;
        public static string blockOpisanieVerh;
        public static string blockOpisanieNiz;
        public static string blockZagolovok;
        public static string blockYoutube;

        public void Sborka()
        {
            blockNazv = $"<strong>Оригинальное название</strong>: {nazv1} / {nazvAngl}";
            blockCountry = $"\n<strong>Страна</strong>: {country2}";
            blockZhanr = $"\n<strong>Жанр</strong>: {zhanr}";
            blockQuality = $"\n<strong>Качество: <span style=\"color: #bcff64;\">HD-трейлер</span></strong>";
            blockDirector = $"\n<strong>Режиссер</strong>: {director2}";
            blockActors = $"\n<strong>В ролях</strong>: {actors2}";
            blockOpisanieVerh = "\n\n<strong>Описание</strong>:\n\n";
            blockOpisanieNiz = $"<h2>{nazv1} ({year}) смотреть фильм онлайн бесплатно в хорошем качестве</h2>";
            blockZagolovok = $"\n{nazv1} ({year}) фильм смотреть онлайн";

            if (cbIfForeight.IsChecked == true)
            {
                nazvAngl = tbAnglNazv.Text;
                if (nazvAngl!="")
                    blockNazv = $"<strong>Оригинальное название</strong>: {nazv1} / {nazvAngl}";
                else
                    blockNazv = $"<strong>Оригинальное название</strong>: {nazv1}";
            }

            if (cbIfCartoon.IsChecked == true)
            {
                blockOpisanieNiz = $"<h2>{nazv1} ({year}) смотреть мультфильм онлайн бесплатно в хорошем качестве</h2>";
                blockZagolovok = $"\n{nazv1} ({year}) мультфильм смотреть онлайн";
            }

            if (cbIfSerial.IsChecked == true)
            {
                blockZhanr = $"\n<strong>Жанр</strong>: сериал, {zhanr}";
                blockQuality = $"\n<strong>Качество: <span style=\"color: #bcff64;\">HDTVRip</span></strong>";
                
                if (seasonNumber > 1)
                {
                    blockOpisanieNiz =
                        $"<h2>{nazv1} {seasonNumber} сезон ({year}) сериал смотреть онлайн бесплатно в хорошем качестве</h2>";
                    blockZagolovok = $"\n{nazv1} {seasonNumber} сезон (1,2,3,4,5,6,7,8 серия) сериал смотреть онлайн";
                }
                else
                {
                    blockOpisanieNiz = $"<h2>{nazv1} ({year}) сериал смотреть онлайн бесплатно в хорошем качестве</h2>";
                    blockZagolovok = $"\n{nazv1} 1,2,3,4,5,6,7,8 серия ({year}) сериал смотреть онлайн";
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            rtbKF.Document.Blocks.Clear();
            tbSeasonNumber.Text = "0";
            rtbYTBlist.Document.Blocks.Clear();
            tbUrlKF.Text = "";
            tbSeasonNumber.Text = "";
            seasonNumber = 0;
            YtbIdNumber = 0;
            cbIfSerial.IsChecked = false;
            cbIfForeight.IsChecked = false;
            cbIfCartoon.IsChecked = false;
            tbAnglNazv.Text = "";
            tbYtbNumber.Text = "";
            Search.q = null;
            Search.listUrl = null;
            Search.idSplit = null;
            blockYoutube = null;
            actors2 = null;
            director2 = null;
            zhanr = null;
            country2 = null;
        }

        private void btnYtbSet_Click(object sender, RoutedEventArgs e)
        {
            int seasonNum = 0;
            if (tbSeasonNumber.Text !="")
                seasonNum = Int32.Parse(tbSeasonNumber.Text);

            if (cbIfSerial.IsChecked == true)
            {
                if (seasonNum > 1)
                {
                    Search.q = $"{nazv1} {seasonNumber} сезон ({year}) анонс сериала";
                }
                else
                {
                    Search.q = $"{nazv1} ({year}) анонс сериала";
                }
            }
            else
            {
                Search.q = $"{nazv1} ({year}) трейлер";
            }

            Search.YTBsearch();

        }

        private void btnYTBEng_Click(object sender, RoutedEventArgs e)
        {
            if (cbIfSerial.IsChecked == true)
            {
                Search.YtbId = String.Empty;
                Search.listId = String.Empty;
                Search.idSplit = null;
                rtbYTBlist.Document.Blocks.Clear();

                if (seasonNumber > 1)
                {
                    Search.q = $"{nazvAngl} {seasonNumber} season ({year}) trailer";
                }
                else
                {
                    Search.q = $"{nazvAngl} ({year}) trailer";
                }
            }
            else
            {
                Search.q = $"{nazvAngl} ({year}) movie trailer";
            }
            
            Search.YTBsearch();
            //rtbYTBlist.AppendText(Search.listUrl);
        }

        private void btnYtbGet_Click(object sender, RoutedEventArgs e)
        {
            YtbIdNumber = 0;
            rtbYTBlist.Document.Blocks.Clear();
            if (tbYtbNumber.Text != "")
                YtbIdNumber = Int32.Parse(tbYtbNumber.Text);
            if (YtbIdNumber != 0)
            {
                
                var searchID = Search.idSplit[YtbIdNumber-1];
                blockYoutube =
                    $"\n<iframe src=\"https://www.youtube.com/embed/{searchID}\" frameborder=\"0\" allow=\"autoplay; encrypted-media\" allowfullscreen></iframe>";
            }
            else
            {
                blockYoutube = null;
            }
            rtbYTBlist.AppendText(Search.listUrl);
        }

        private void btnResult_Click(object sender, RoutedEventArgs e)
        {
            //очищаем формы 
            rtbKF.Document.Blocks.Clear();
            rtbYTBlist.Document.Blocks.Clear();
            //добавляем к ричтекстбоксу поле текст, чтоб затем скопировать в строку и засунуть в буфер обмена
            rtbKF.Document.Blocks.Add(new Paragraph(new Run()));
            //выводим в ричтекстбоксы содержимое блоков и вывод ютуба
            rtbKF.AppendText(blockNazv + blockCountry + blockZhanr + blockQuality + blockDirector + blockActors +
                             blockOpisanieVerh + blockOpisanieNiz + blockZagolovok + blockYoutube);
            rtbYTBlist.AppendText(Search.listUrl);
            //это для того, чтоб по нажатию кнопки содержимое ричтекстбокса копировалось в буфер
            string richText = new TextRange(rtbKF.Document.ContentStart, rtbKF.Document.ContentEnd).Text;
            Clipboard.SetText(richText);
        }

       
    }

    //класс для удобства работы со строками
    public static class Ext
    {
        public static string Substring(this string str, string left, string right,
            int startIndex = 0, StringComparison comparsion = StringComparison.Ordinal)
        {
            if (string.IsNullOrEmpty(str))
            {
                return string.Empty;
            }
            int leftPosBegin = str.IndexOf(left, startIndex, comparsion);

            if (leftPosBegin == -1)
            {
                return string.Empty;
            }
            int leftPosEnd = leftPosBegin + left.Length;
            int rightPos = str.IndexOf(right, leftPosEnd, comparsion);

            if (rightPos == -1)
            {
                return string.Empty;
            }
            int length = rightPos - leftPosEnd;

            return str.Substring(leftPosEnd, length);
        }

        public static string[] Substrings(this string str, string left, string right, int startIndex = 0, StringComparison comparsion = StringComparison.Ordinal)
        {
            if (string.IsNullOrEmpty(str))
            {
                return new string[0];
            }

            int currentStartIndex = startIndex;
            List<string> strings = new List<string>();

            while (true)
            {
                int leftPosBegin = str.IndexOf(left, currentStartIndex, comparsion);

                if (leftPosBegin == -1)
                {
                    break;
                }
                int leftPosEnd = leftPosBegin + left.Length;
                int rightPos = str.IndexOf(right, leftPosEnd, comparsion);

                if (rightPos == -1)
                {
                    break;
                }
                int length = rightPos - leftPosEnd;
                strings.Add(str.Substring(leftPosEnd, length));
                currentStartIndex = rightPos + right.Length;
            }

            return strings.ToArray();
        }
    }
}