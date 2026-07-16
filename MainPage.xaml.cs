using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using Windows.Data.Xml.Dom;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Notifications;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Threading.Tasks;

namespace XenonStore
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            this.Loaded += MainPage_Loaded;
        }

        private async void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            await UpdateLiveTile();
        }

        private async Task UpdateLiveTile()
        {
            var urls = new List<string>
            {
                "https://xenonstore.dankassassin368.com/data/tile1.xml",
                "https://xenonstore.dankassassin368.com/data/tile2.xml",
                "https://xenonstore.dankassassin368.com/data/tile3.xml",
                "https://xenonstore.dankassassin368.com/data/tile4.xml",
                "https://xenonstore.dankassassin368.com/data/tile5.xml"
            };

            TileUpdater updater = TileUpdateManager.CreateTileUpdaterForApplication();
            updater.EnableNotificationQueue(true);
            updater.Clear();

            var client = new HttpClient();

            foreach (var url in urls)
            {
                try
                {
                    string xml = await client.GetStringAsync(url);
                    var doc = new Windows.Data.Xml.Dom.XmlDocument();
                    doc.LoadXml(xml);
                    updater.Update(new TileNotification(doc));
                }
                catch { }
            }

            //var rnd = new Random();
            //string url = urls[rnd.Next(urls.Count)];

            //try
            //{
            //    var cl = new HttpClient();
            //    string xml = await cl.GetStringAsync(url);

            //    var doc = new Windows.Data.Xml.Dom.XmlDocument();
            //    doc.LoadXml(xml);

            //    TileUpdater upd = TileUpdateManager.CreateTileUpdaterForApplication();
            //    upd.Update(new TileNotification(doc));
            //}
            //catch { }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            
        }

        private void AllApps_Tapped_1(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(AllAppsPage), "All types|All categories");
        }

        private void GamesSeeAll_Tapped_1(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(AllAppsPage), "Game|All categories");
        }

        private void SocialSeeAll_Tapped_1(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(AllAppsPage), "All types|Social");
        }

        private void VideoSeeAll_Tapped_1(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(AllAppsPage), "All types|Video + Entertainment");
        }

        private void PhotoSeeAll_Tapped_1(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(AllAppsPage), "All types|Photo + Design");
        }

        private void MusicSeeAll_Tapped_1(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(AllAppsPage), "All types|Music + Audio");
        }

        private void SportsSeeAll_Tapped_1(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(AllAppsPage), "All types|Sports");
        }

        private void BooksSeeAll_Tapped_1(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(AllAppsPage), "All types|Books + Reference");
        }

        private void NewsSeeAll_Tapped_1(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(AllAppsPage), "All types|News + Weather");
        }

        private void HealthSeeAll_Tapped_1(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(AllAppsPage), "All types|Health + Fitness");
        }

        private void FoodSeeAll_Tapped_1(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(AllAppsPage), "All types|Food + Cooking");
        }

        private void GridViewItem_Tapped_1(object sender, TappedRoutedEventArgs e)
        {

        }

        private void ShoppingSeeAll_Tapped_1(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(AllAppsPage), "All types|Shopping");
        }

        private void TravelSeeAll_Tapped_1(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(AllAppsPage), "All types|Travel + Navigation");
        }

        private void FinanceSeeAll_Tapped_1(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(AllAppsPage), "All types|Finance");
        }

        private void UtilitiesSeeAll_Tapped_1(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(AllAppsPage), "All types|Utilities");
        }

        private void EducationSeeAll_Tapped_1(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(AllAppsPage), "All types|Education");
        }

        private void GovernmentSeeAll_Tapped_1(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(AllAppsPage), "All types|Government");
        }

        private void Deezer_Tapped_1(object sender, TappedRoutedEventArgs e)
        {
            StoreApplication app = new StoreApplication
            {
                Id = 94,
                Name = "Recipe Keeper",
                Publisher = "Tudorspan Limited",
                Version = "1.5.2.0",
                DownloadUrl = "https://appxboxdl.dankassassin368.com/Windows%208.0%20APPX%20Files/Apps/Recipe%20Keeper/1.5.2.0/x86/TudorspanLimited.RecipeKeeperFree_1.5.2.0_x86__mnckez06wj9wa.appx",
                IconUrl = "https://store-images.s-microsoft.com/image/apps.61301.9007199266535064.8c40eaa7-00f5-4e70-a0d6-bbb41e6c57c1.0f289f61-1b21-4120-9ccd-ede726c0fd67?h=115",
                Description = "APP DOESN'T WORK\r\nRecipe Keeper is the easy to use, all-in-one recipe organizer, shopping list and meal planner available across all of your devices.",
                Type = "App",
                Category = "Food + Cooking"
            };

            Frame.Navigate(typeof(AppDetails), app);
        }

        private void SU_Tapped_1(object sender, TappedRoutedEventArgs e)
        {
            StoreApplication app = new StoreApplication
            {
                Id = 90,
                Name = "CNN App for Windows",
                Publisher = "CNN INTERACTIVE GROUP, Inc.",
                Version = "1.2.3.0",
                DownloadUrl = "https://dl.retiled.xyz/Apptravaganza%21/CNN%20App%20for%20Windows/588E6FFA.CNNAppforWindows_1.2.3.0_neutral__cs8eyncph15zy.appx",
                IconUrl = "https://i.ibb.co/xS7XBsQc/apps-33373-9007199266245764-0ba407dd-2796-4551-9fb7-e1e39a3b36eb.png",
                Description = "CNN connects you to the world, wherever you are. Stay informed with the latest headlines and original stories from around the globe. Follow up-to-the-minute reporting with breaking news and video. Lead the conversation by sharing today’s news and dig deeper into the stories that matter most to you. Get breaking news and follow stories as they develop. Go beyond the surface with international, politics, opinion, tech and entertainment stories and more. Contribute your story or opinion to CNN iReport by uploading photos and video directly from your app. Follow other iReporters and see stories from their point of view. Read the top headlines on the go with the CNN Live Tile. Choose the font size that most appeals to you. \nHave questions or feedback on the CNN App? E-mail us at WindowsTablet@cnn.com. We are always looking for suggestions on how to provide the best experience possible for you. \nPatched with newRetiled, credit to migbrunluz.",
                Type = "App",
                Category = "News + Weather"
            };

            Frame.Navigate(typeof(AppDetails), app);
        }

        private void Fotor_Tapped_1(object sender, TappedRoutedEventArgs e)
        {
            StoreApplication app = new StoreApplication
            {
                Id = 54,
                Name = "ESPN",
                Publisher = "ESPN Inc",
                Version = "1.3.1.0",
                DownloadUrl = "https://dl.retiled.xyz/Apptravaganza%21/ESPN%20%288.0%29/ESPNInc.TheESPNApp_1.3.1.0_neutral__hpt16c9c0eesj.appx",
                IconUrl = "https://store-images.microsoft.com/image/apps.10609.9007199266245259.9d548691-0799-47dd-afad-2a604f32b464.4b6584ce-5819-4a99-a0b3-40a764e96950",
                Description = "The ESPN app for Windows 8, offered on desktop and tablet, provides sports fans with all the things they love about ESPN in a single place. Get up- to- the -minute scores, news, and analysis for all your favorite teams, leagues, and players. Access rich, in depth content from the leader in sports. Download the ESPN app for Windows 8 for a deeper sports experience than ever before! For a limited time, ESPN Insider content is available for a free in the ESPN App for Windows!",
                Type = "App",
                Category = "Sports"
            };

            Frame.Navigate(typeof(AppDetails), app);
        }

        private void CF_Tapped_1(object sender, TappedRoutedEventArgs e)
        {
            StoreApplication app = new StoreApplication
            {
                Id = 119,
                Name = "Metro Commander Pro",
                Publisher = "Finebits OÜ",
                Version = "1.0.0.105",
                DownloadUrl = "https://appxboxdl.dankassassin368.com/Windows%208.0%20APPX%20Files/Apps/Metro%20Commander%20Pro/1.0.0.105/x86/BooStudioLLC.MetroCommanderPro_1.0.0.105_x86__b6e429xa66pga.appx",
                IconUrl = "https://i.ibb.co/8L4yt7Kf/Small-Logo-targetsize-256.png",
                Description = "Metro Commander is an orthodox file manager which allows you to manage your files and folders from within the Modern Windows UI interface.  Easily create, open, preview, rename, copy, move, delete, search and share files and folders.",
                Type = "App",
                Category = "Utilities"
            };

            Frame.Navigate(typeof(AppDetails), app);
        }

        private void GBC_Tapped_1(object sender, TappedRoutedEventArgs e)
        {
            StoreApplication app = new StoreApplication
            {
                Id = 66,
                Name = "Asparion Clock",
                Publisher = "Asparion",
                Version = "3.2.0.54",
                DownloadUrl = "https://appxboxdl.dankassassin368.com/Windows%208.0%20APPX%20Files/Apps/AsparionClock/3.2.0.54/neutral/12199Asparion.AsparionClock_3.2.0.54_neutral__f89vgcf3qm37t.appx",
                IconUrl = "https://i.ibb.co/s9DZHpgy/asparionclock.png",
                Description = "With this clock you can always keep track of time. It displays the date and time and other information in a tile on your windows start screen. You can choose the style and different date and time formats. In addition to that you can set alarms and timers.",
                Type = "App",
                Category = "Utilities"
            };

            Frame.Navigate(typeof(AppDetails), app);
        }

        private void FruitNinja_Tapped_1(object sender, TappedRoutedEventArgs e)
        {
            StoreApplication app = new StoreApplication
            {
                Id = 42,
                Name = "Fruit Ninja (x86)",
                Publisher = "Halfbrick Studios",
                Version = "1.8.1.66",
                DownloadUrl = "https://appxboxdl.dankassassin368.com/Windows%208.0%20APPX%20Files/Games/Fruit%20Ninja/HalfbrickStudiosPtyLtd.FruitNinja_1.8.1.66_x86__w77bc8x1h5kya.appx",
                IconUrl = "https://store-images.microsoft.com/image/apps.30924.9007199266251580.17b0aa98-9fa1-4a25-a67c-7673a018bf03.d5a8d5f5-f06d-4d2e-bd6e-05e95240e177",
                Description = "Slice across the screen to deliciously slash and splatter fruit like a true ninja warrior. Be careful of bombs – they are explosive to touch and will put a swift end to your juicy adventure! Fruit Ninja features Classic, Zen and the amazing Arcade mode! Your success will also please the wise ninja Sensei, who will accompany your journey with wise words and fun fruit facts. Fruit Ninja is the messiest and most satisfying fruit game ever! **** IMPORTANT NOTICE TO PARENTS This game may contain: - The ability to make optional in-app purchases using real money. - Links to external social networking sites intended for users over the age of 13. - Direct links to the internet which may open the default web browser on your device. Privacy Policy: http://www.halfbrick.com/pp Terms of Service: http://www.halfbrick.com/tos",
                Type = "Game",
                Category = "Action"
            };

            Frame.Navigate(typeof(AppDetails), app);
        }

        private void SharkDash_Tapped_1(object sender, TappedRoutedEventArgs e)
        {
            StoreApplication app = new StoreApplication
            {
                Id = 43,
                Name = "Shark Dash (x86)",
                Publisher = "GAMELOFT SA",
                Version = "0.0.8.3",
                DownloadUrl = "https://appxboxdl.dankassassin368.com/Windows%208.0%20APPX%20Files/Games/Shark%20Dash/GAMELOFTSA.SharkDash_0.0.8.3_x86__0pp20fcewvvtj.appx",
                IconUrl = "https://store-images.microsoft.com/image/apps.61051.9007199266242712.7880302f-61d4-4a1d-ad84-23f0e6c1e5b7.93cec116-ad41-4882-bdcb-6c58412e9918",
                Description = "Discover the new benchmark for physics puzzle games! Shark Dash is a highly addictive game that takes the physics puzzler to fun new heights with a unique cartoonish style starring funny little bath toys! Sharkee and his merry band of toy sharks were living happily in the bathtub. That is, until a bunch of mischievous ducks came along to ruin their peaceful little world. These cheaply-made rubber duckies are a little loopy from the chemicals they are made of, and now they’re teasing the sharks, playing pranks like they owned the place! But when the ducks kidnap Sally, Sharkee’s girlfriend, that’s when Sharkee and his buds have had enough! Join a wild journey to tricky bathtubs around the world, save Sally and get rid of the dimwitted ducks! BATH TIME HAS NEVER BEEN THIS FUN • Amazingly accessible gameplay: Simply drag and release the shark’s tail with your finger to launch him at the ducks! • Dispose of the duckies, grab all the coins, and finish each level with the fewest jumps possible to earn 3 Stars! Use your Stars to unlock new levels! • Not happy with your last shot? Undo it and try it again! A WILD JOURNEY IN BATHTUBS ALL OVER THE WORLD • Make your way through 96 levels with more to come in future updates! • Visit 4 different environments, from ancient Rome to distant Japan! • Complete tons of missions & unlock loads of achievements! MEET THE MOST ADORABLE BAND OF BATH TOYS • Sharkee, the hero and fearless leader of the merry band of plastic sharks • Sawy, whose incredible saw nose can cut chains and drop heavy objects on those dastardly ducks • Hammy, who uses his Jump Slash skill to leap through the air and hit ducks from incredible trajectories • Scuby, Sharkee’s twin brother, a calm and meditative toy who likes to swim through the watery depths to take out duckies wherever they hide Grab enough coins and you can upgrade the appearance of your sharks with cool new skins! ---- Visit our official site at http://www.gameloft.com Follow us on Twitter at http://glft.co/GameloftonTwitter or like us on Facebook at http://facebook.com/Gameloft to get more info about all our upcoming titles. Check out our videos and game trailers on http://www.youtube.com/Gameloft Discover our blog at http://glft.co/Gameloft_Official_Blog for the inside scoop on everything Gameloft.",
                Type = "Game",
                Category = "Puzzle"
            };

            Frame.Navigate(typeof(AppDetails), app);
        }

        private void PFX2_Tapped_1(object sender, TappedRoutedEventArgs e)
        {
            StoreApplication app = new StoreApplication
            {
                Id = 44,
                Name = "Pinball FX2 (x86)",
                Publisher = "Microsoft Studios",
                Version = "1.8.0.951",
                DownloadUrl = "https://appxboxdl.dankassassin368.com/Windows%208.0%20APPX%20Files/Games/Pinball%20FX2/1.8.0.951/Microsoft.Studios.PinballFx2_1.8.0.951_x86__8wekyb3d8bbwe.appx",
                IconUrl = "https://store-images.microsoft.com/image/apps.12320.9007199266251904.7be86ebb-12b9-45d1-940f-bbd201c60b61.df7571e8-5117-4aa0-a1f1-368b5c20c67e",
                Description = "Pinball FX is back, and it is better than ever! Pinball FX2 offers brand new tables and a host of new features and improvements, including a new state-of-the-art physics model that surpasses anything available so far.",
                Type = "Game",
                Category = "Action"
            };

            Frame.Navigate(typeof(AppDetails), app);
        }

        private void XG_Tapped_1(object sender, TappedRoutedEventArgs e)
        {
            StoreApplication app = new StoreApplication
            {
                Id = 24,
                Name = "Xbox Games (NewRetiled)",
                Publisher = "Microsoft corporation",
                Version = "1.0.927.0 x64",
                DownloadUrl = "https://dl.retiled.xyz/newRetiled/8.0/9200/Xbox%20Apps/Games/Microsoft.XboxLIVEGames_1.0.927.0_x64__8wekyb3d8bbwe.appx",
                IconUrl = "https://i.ibb.co/FfPtW26/image.png",
                Description = "The Xbox Games app on Windows 8.1 was a pre-installed, hub-style application designed to bring Xbox Live functionality directly to the desktop. It served as a central repository for finding, purchasing, and managing games, featuring a Metro-style user interface.",
                Type = "App",
                Category = "Other"
            };

            Frame.Navigate(typeof(AppDetails), app);
        }

        private void JJ_Tapped_1(object sender, TappedRoutedEventArgs e)
        {
            StoreApplication app = new StoreApplication
            {
                Id = 45,
                Name = "Jetpack Joyride (x86)",
                Publisher = "Halfbrick Studios",
                Version = "1.0.3.68",
                DownloadUrl = "https://appxboxdl.dankassassin368.com/Windows%208.0%20APPX%20Files/Games/Jetpack%20Joyride/HalfbrickStudiosPtyLtd.JetpackJoyride_1.0.3.68_x86__w77bc8x1h5kya.appx",
                IconUrl = "https://store-images.microsoft.com/image/apps.7580.9007199266251579.9159f39b-3006-405b-a854-07b2e36ad34c.a29dfa07-b214-4e8e-80db-5290c509fbde",
                Description = "Suit up with a selection of the coolest jetpacks ever made and take to the skies as Barry Steakfries, the lovable hero on a one-way trip to adventure! Join Barry as he breaks in to a secret laboratory to commandeer the experimental jetpacks from the clutches of science evildoers. Rain bullets, bubbles, rainbows and lasers downwards as you fly towards higher and higher scores! Along the way you’ll collect coins, vehicles, powerups and more, all of which can be upgraded and customized in the Stash. Want to dress up like a ninja? Paint your Profit Bird gold? Grab your robot pal Flash to come along for the ride? The choice is yours! Stay alive, get funky and lose yourself in Jetpack Joyride. There's so much to see and do, all the time in the world and more than enough jetpacks! As always, Barry Steakfries will provide! **** IMPORTANT NOTICE TO PARENTS This game may contain: - The ability to make optional in-app purchases using real money. - Links to external social networking sites intended for users over the age of 13. - Direct links to the internet which may open the default web browser on your device. Privacy Policy: http://www.halfbrick.com/pp Terms of Service: http://www.halfbrick.com/tos",
                Type = "Game",
                Category = "Action"
            };

            Frame.Navigate(typeof(AppDetails), app);
        }

        private void FX_Tapped_1(object sender, TappedRoutedEventArgs e)
        {
            StoreApplication app = new StoreApplication
            {
                Id = 132,
                Name = "FX Networks",
                Publisher = "FX Networks, LLC",
                Version = "1.2.3.105",
                DownloadUrl = "https://appxboxdl.dankassassin368.com/Windows%208.0%20APPX%20Files/Apps/FX%20Networks/1.2.3.105/x86/FXNetworksLLC.FXNetworks_1.2.3.105_x86__13ktfdhj42e2e.appx",
                IconUrl = "https://i.ibb.co/PsfSKJCv/fx-logo-square.jpg",
                Description = "THE APP DOESN'T WORK \nThe FX Networks app for Windows 8 is your personal companion viewing experience for all your favorite FX shows and blockbuster movies. When you watch your favorite shows on FX, you can now use the FX Windows 8 app to engage even more with American Horror Story, Sons of Anarchy, Justified, It's Always Sunny in Philadelphia, Anger Management, Louie, Wilfred, Archer, The League, Totally Biased with W. Kamau Bell, and Brand X with Russell Brand. Join in Live conversations with other fans across your favorite social platforms, plus check-in for stickers, watch video clips and more. Use the FX Networks Windows 8 app to also connect with FX Has the Movies and your favorite box office hits showing on FX.",
                Type = "App",
                Category = "News + Weather"
            };

            Frame.Navigate(typeof(AppDetails), app);
        }

        private void Foreca_Tapped_1(object sender, TappedRoutedEventArgs e)
        {
            StoreApplication app = new StoreApplication
            {
                Id = 16,
                Name = "Foreca Weather",
                Publisher = "Foreca Ltd.",
                Version = "1.0.1.1",
                DownloadUrl = "https://appxboxdl.dankassassin368.com/Windows%208.0%20APPX%20Files/Apps/08938A66.ForecaWeather/1.0.1.1/neutral/08938A66.ForecaWeather_1.0.1.1_neutral__ehkm8sa10hy4e.appx",
                IconUrl = "https://i.ibb.co/yFnxNtFs/Store-Logo-scale-180.png",
                Description = "Foreca is a premier Finnish weather forecasting company, founded in 1996 and recognized for its high-accuracy meteorological services used in over 180 countries. It is widely acclaimed as one of the most accurate, particularly in Europe, for rain, precipitation, and general weather predictions. Now in Windows 8.0 too.",
                Type = "App",
                Category = "News + Weather"
            };

            Frame.Navigate(typeof(AppDetails), app);
        }

        private void Newser_Tapped_1(object sender, TappedRoutedEventArgs e)
        {
            StoreApplication app = new StoreApplication
            {
                Id = 88,
                Name = "Newser",
                Publisher = "Newser",
                Version = "1.3.0.4",
                DownloadUrl = "https://appxboxdl.dankassassin368.com/Windows%208.0%20APPX%20Files/Apps/Newser/Newser.Newser_1.3.0.4_neutral__mmva361aftd3w.appx",
                IconUrl = "https://store-images.microsoft.com/image/apps.47183.9007199266445903.3227048e-6741-45eb-b667-c258af5a27a7.ce7d156c-dcbd-482a-a728-11d32d992b54",
                Description = "Newser's writers and editors carefully select approximately 45 of the most essential, entertaining, and delightfully quirky news items to cover each day. And at just two paragraphs each, our sharply written stories pack in only the most interesting details\u2014none of the boring stuff\u2014and are quick and easy to digest, especially on the go. And we're pretty to look at, too: our signature grid, reformatted for Windows 8, lets eye-catching photos and short and snappy headlines do the talking, providing a vivid snapshot of the day's news.",
                Type = "App",
                Category = "News + Weather"
            };

            Frame.Navigate(typeof(AppDetails), app);
        }

        private void Accu_Tapped_1(object sender, TappedRoutedEventArgs e)
        {
            StoreApplication app = new StoreApplication
            {
                Id = 135,
                Name = "AccuWeather - Weather for Life (x64)",
                Publisher = "AccuWeather",
                Version = "2.1.7.2",
                DownloadUrl = "https://dl.retiled.xyz/Apptravaganza%21/AccuWeather%20for%20Windows%208.0%20%28x64%20only%29/AccuWeather.AccuWeatherforWindows8_2.1.7.2_x64__8zz2pj9h1h1d8.appx",
                IconUrl = "https://i.ibb.co/4nmKHJ4d/apps-62427-9007199266244209-c43fb124-cfeb-4d7a-b725-8557aa86309b.png",
                Description = "Stay connected to the latest in weather forecasting with AccuWeather � Weather for Life. This free weather app was designed for Windows 10 users and has the very latest in weather news and information, including MinuteCast�, the leading minute-by-minute precipitation forecast that is hyper-localized to your exact street address. Key features include: AccuWeather MinuteCast� � minute-by-minute precipitation forecasts for the next two hours hyper-localized to your exact street address or GPS location. Includes precipitation type and intensity, and start and end times for precipitation. Available for the contiguous United States, Canada, United Kingdom, Ireland, Japan, France, Germany, Belgium, Switzerland, Netherlands, Luxembourg, Sweden, Denmark, parts of the Czech Republic, Gibraltar, Liechtenstein and a growing list of global locations. Severe weather notices for all locations � visible from anywhere within the app. Pushed severe weather alerts straight to your Windows Phone for locations in the United States, Canada, United Kingdom, and Germany. Accurate and local forecasts for every latitude/longitude on Earth. Forecasts update every 15 minutes with information for the next 15 days � all in 33 languages and dialects. Current weather conditions displayed with location name and time, temperature, wind speed, wind gust speed and wind direction, precipitation and amounts, humidity, visibility, UV Index, cloud cover, pressure, and AM and PM times for sunrise and sunset. Option to set current conditions to update as your GPS location changes. The Local Forecast Summary, a brief summary of what you can expect from the weather over the next 3-5 days for your location. Fully interactive, full-screen Bing Maps overlaid with AccuWeather�s precise weather data, including U.S., Canadian, European, and Japanese radar. Unlimited location storage for your GPS location and all your favorites. Pin Live Tiles in four sizes for multiple locations that peek and automatically update the forecasts on the Start screen. Download AccuWeather � Weather for Life today for free and experience the Superior Accuracy� that comes from high-quality weather forecasting.",
                Type = "App",
                Category = "News + Weather"
            };

            Frame.Navigate(typeof(AppDetails), app);
        }

        private void iHeart_Tapped_1(object sender, TappedRoutedEventArgs e)
        {
            StoreApplication app = new StoreApplication
            {
                Id = 56,
                Name = "iHeartRadio",
                Publisher = "Clear Channel Management Services, Inc.",
                Version = "4.3.0.16",
                DownloadUrl = "https://dl.retiled.xyz/Apptravaganza%21/iHeartRadio%20v4.3/iHeartRadio%20v4.3.appx",
                IconUrl = "https://yt3.googleusercontent.com/ytc/AIdro_nzDYC05C0uOJxniDyPorhZxKQPhqNgG_bawMSPrxgAD0I=s900-c-k-c0x00ffffff-no-rj",
                Description = "iHeartRadio offers free music in an all-in-one, free digital internet radio service that lets you stream more than 1,500 live radio stations. With iHeartRadio\u2019s Windows 8 radio app, you can also create commercial-free Custom Stations featuring songs from the artist you select and similar music.   THE BEST OF LIVE INTERNET RADIO Listen to your favorite live radio stations including pop, country, hip-hop and R&B, rock, talk, news, and sports. Browse radio stations by music style and location, then hit the scan button to move from radio station to radio station within a format.  CREATE YOUR OWN STATIONS Simply pick a song or artist to create your own commercial-free Custom Station featuring free music from that artist and similar ones. Choose from our catalog of over 15 million songs and 400,000 artists. Use iHeartRadio's exclusive Discovery Tuner to control how much variety you want in your music.  ANYTIME, ANYWHERE, ALWAYS FREE Take Your Favorite Radio Stations & Music Wherever You Go. Log in to iHeartRadio for free through email or Facebook to make iHeartRadio uniquely yours. Create, save, and share your internet radio stations from wherever you access iHeartRadio.",
                Type = "App",
                Category = "Music + Audio"
            };

            Frame.Navigate(typeof(AppDetails), app);
        }

        private void NRJ_Tapped_1(object sender, TappedRoutedEventArgs e)
        {
            StoreApplication app = new StoreApplication
            {
                Id = 9,
                Name = "NRJ",
                Publisher = "NRJ",
                Version = "1.0.1.5",
                DownloadUrl = "https://dl.retiled.xyz/Apptravaganza%21/NRJ%20%288.0%29/NRJ.NRJ_1.0.1.5_neutral__js6xree90qvwe.appx",
                IconUrl = "https://store-images.microsoft.com/image/apps.63191.9007199266246520.df242343-cd39-4a8e-9c4a-c31b5cb84208.837b4d4f-17fa-4255-b349-b7ce5308c5bf",
                Description = "T\u00e9l\u00e9chargez gratuitement l\u2019application NRJ et vous pourrez :\r\n- \u00c9couter en direct la radio NRJ et plus de 145 Webradios parmi lesquelles : Hits, Nouveaut\u00e9s, Dance, Disney Channel, RnB, Rap Fr, Hit of the day, \u2026\r\n- Ajouter en favoris votre radio et vos webradios pr\u00e9f\u00e9r\u00e9es\r\n- Epingler sur le bureau la radio ou la webradio de votre choix\r\n- Voter pour le titre en cours de diffusion\r\n- Partager sur Facebook ou Twitter vos hits pr\u00e9f\u00e9r\u00e9s\r\n\r\nPr\u00e9caution d\u2019emploi :\r\nNous recommandons l&#039;utilisation d\u2019une connexion filaire ou WIFI, car l\u2019application NRJ consomme de grandes quantit\u00e9s de donn\u00e9es.\r\nL\u2019utilisation d\u2019un r\u00e9seau, notamment 3G, d\u2019un op\u00e9rateur ou fournisseur d\u2019acc\u00e8s peut engendrer des frais suppl\u00e9mentaires, dont NRJ se d\u00e9charge de toute responsabilit\u00e9.\r\nIl est important que vous ayez un abonnement forfaitaire adapt\u00e9 \u00e0 ce genre d\u2019utilisation. Si vous avez un doute, merci de consulter votre op\u00e9rateur ou fournisseur d\u2019acc\u00e8s.",
                Type = "App",
                Category = "Music + Audio"
            };

            Frame.Navigate(typeof(AppDetails), app);
        }

        private void XBM_Tapped_1(object sender, TappedRoutedEventArgs e)
        {
            StoreApplication app = new StoreApplication
            {
                Id = 23,
                Name = "Xbox Music (newRetiled)",
                Publisher = "Microsoft Corporation",
                Version = "1.0.927.0 x64",
                DownloadUrl = "https://dl.retiled.xyz/newRetiled/8.0/9200/Xbox%20Apps/Music/Microsoft.ZuneMusic_1.0.927.0_x64__8wekyb3d8bbwe.appx",
                IconUrl = "https://i.ibb.co/60bn7b3H/Xbox-Music-Icon-8.png",
                Description = "Xbox Music in Windows 8 was the default, redesigned audio player and music streaming service aimed at providing a unified experience across Windows PCs, tablets, Windows Phone, and Xbox consoles",
                Type = "App",
                Category = "Music + Audio"
            };

            Frame.Navigate(typeof(AppDetails), app);
        }

        private void Spotlite_Tapped_1(object sender, TappedRoutedEventArgs e)
        {
            StoreApplication app = new StoreApplication
            {
                Id = 64,
                Name = "Spotlite - Listen to Spotify",
                Publisher = "Spotlite",
                Version = "2.2.0.8",
                DownloadUrl = "https://appxboxdl.dankassassin368.com/Windows%208.0%20APPX%20Files/Apps/Spotlite%20-%20Listen%20to%20Spotify/2.2.0.8/neutral/49573Spotlite.Spotlite-ListentoSpotify_2.2.0.8_neutral__z5pndgmqb06wp.Appx",
                IconUrl = "https://store-images.s-microsoft.com/image/apps.38350.9007199266251547.cd89b7da-4fbc-444c-8271-c97df2b09b95.c325500b-44bc-459e-8d0e-f09aceb7c37e",
                Description = "THIS APP IS NOT FUNCTIONAL \nLet Spotify bring you the right music for every mood and moment. The perfect songs for your workout, your night in, or your journey to work. Get Spotlite for free! Spotlite allows Spotify Premium and Unlimited users to listen to Spotify Music Service. Spotlite is not the official offering from Spotify but a third party client created by a Spotify fan for Spotify users using Windows 8",
                Type = "App",
                Category = "Music + Audio"
            };

            Frame.Navigate(typeof(AppDetails), app);
        }

        private void Deezerr_Tapped_1(object sender, TappedRoutedEventArgs e)
        {
            StoreApplication app = new StoreApplication
            {
                Id = 32,
                Name = "Deezer (x86)",
                Publisher = "Deezer",
                Version = "1.1.2.0",
                DownloadUrl = "https://appxboxdl.dankassassin368.com/Windows%208.0%20APPX%20Files/Apps/Deezer/1.1.2.0/x86/Deezer.Deezer_1.1.2.0_x86__q7m17pa7q8kj0.appx",
                IconUrl = "https://store-images.microsoft.com/image/apps.31533.9007199266242716.822cb7fe-fc0a-4219-9b94-202c1d5148b4.e6c8725d-b556-4c2c-be3c-a63dff9c863a",
                Description = "THIS APP IS NOT FUNCTIONAL \nEndless music to discover, love and take with you everywhere you go. Download the app and get an instant free upgrade to Premium+ for 15 days! Deezer is: - 35 million tracks, with all your favourite artists and songs - Personalised music recommendations prepared by our fabulous Deezer Editors - Unlimited mixes with your favourite artists and genres - Playlists to suit your tastes - Your library, built up over time with all your discoveries Even better, it's free! When you subscribe to Premium+, you get all the following extras: - No ads, no interruptions - Access your music even when you're offline by downloading albums and playlists to your device - Enjoy your music in High Quality audio Follow Deezer! Facebook : http://www.facebook.com/deezer Twitter : https://twitter.com/deezer",
                Type = "App",
                Category = "Music + Audio"
            };

            Frame.Navigate(typeof(AppDetails), app);
        }

        private void VLC_Tapped_1(object sender, TappedRoutedEventArgs e)
        {
            StoreApplication app = new StoreApplication
            {
                Id = 12,
                Name = "VLC for Windows 8",
                Publisher = "VideoLAN",
                Version = "0.0.5.0",
                DownloadUrl = "https://appxboxdl.dankassassin368.com/Windows%208.0%20APPX%20Files/Apps/VLC%20For%20Windows%208/VideoLAN.VLCforWindows8_0.0.5.0_x86__paz6r1rewnh0a.appx",
                IconUrl = "https://i.ibb.co//20RkfsVm//vlcmetro.png",
                Description = "VLC is probably the best open-source multimedia video player for the Windows operating system.\\r\\n\\r\\nVLC, once named VideoLan Client, is one of the most widely used media players on the market. A small, but powerful video platform, with an executable file under 40MB, yet has virtually illuminated the need for any codec download or added video plugins, as VLC supports 3GP, MKV, MPEG-2, AAC, DV Audio and many other file formats.",
                Type = "App",
                Category = "Video + Entertainment"
            };

            Frame.Navigate(typeof(AppDetails), app);
        }

        private void Nick_Tapped_1(object sender, TappedRoutedEventArgs e)
        {
            StoreApplication app = new StoreApplication
            {
                Id = 31,
                Name = "Nick",
                Publisher = "Nickelodeon",
                Version = "1.2.0.4",
                DownloadUrl = "https://appxboxdl.dankassassin368.com/Windows%208.0%20APPX%20Files/Apps/Nickelodeon%20App/Nickelodeon.Nick_1.2.0.4_x64__857vef5z66f7y.appx",
                IconUrl = "https://store-images.s-microsoft.com/image/apps.11220.9007199266248676.0764f41f-a617-4b39-9054-01c7451334c7.48d262c8-841b-46f1-b860-621242daec36",
                Description = "THIS APP IS NOT FUNCTIONAL \nWelcome to the Nick app, home of all things Nickelodeon for Windows 8! Watch short & funny original videos featuring your favorite stars and animated characters, play tons of games, check out photos of Nick stars, and more. (Please note: Full episodes are not currently available) The whole Nick gang is waiting for you – Victorious, SpongeBob, iCarly, Fairly Odd Parents, Big Time Rush, Teenage Mutant Ninja Turtles, Marvin Marvin, Korra, Robot & Monster, and more. Download now - let's play!",
                Type = "App",
                Category = "Video + Entertainment"
            };

            Frame.Navigate(typeof(AppDetails), app);
        }

        private void SmartGlass_Tapped_1(object sender, TappedRoutedEventArgs e)
        {
            StoreApplication app = new StoreApplication
            {
                Id = 70,
                Name = "Xbox 360 SmartGlass",
                Publisher = "Microsoft Corporation",
                Version = "1.4.3.0",
                DownloadUrl = "https://appxboxdl.dankassassin368.com/Windows%208.0%20APPX%20Files/Apps/XboxCompanion/1.4.3.0/x86/Microsoft.XboxCompanion_1.4.3.0_x86__8wekyb3d8bbwe.Appx",
                IconUrl = "https://i.ibb.co/kTtGdKh/xbox360smartglass.png",
                Description = "THIS APP IS NOT FUNCTIONAL \nXbox SmartGlass lets you use your Windows 8 device as a second screen to intelligently interact with your Xbox 360. It helps your devices work together to enhance your TV shows, movies, music, sports, and games. Control and interact with what's on your TV with simple gestures on your Windows device. Note: Requires Xbox 360. To see which features are available in your region, see the Xbox SmartGlass feature list. http://go.microsoft.com/fwlink/?LinkId=263598",
                Type = "App",
                Category = "Video + Entertainment"
            };

            Frame.Navigate(typeof(AppDetails), app);
        }

        private void Flixster_Tapped_1(object sender, TappedRoutedEventArgs e)
        {
            StoreApplication app = new StoreApplication
            {
                Id = 77,
                Name = "Flixster (x86)",
                Publisher = "Flixster",
                Version = "1.3.3.7",
                DownloadUrl = "https://appxboxdl.dankassassin368.com/Windows%208.0%20APPX%20Files/Apps/Flixster/x86/Flixster.Flixster_1.3.3.7_x86__pwh22gvzcj20c.Appx",
                IconUrl = "https://i.ibb.co/tTwMqd7K/download.png",
                Description = "(unable to connect to the server)\r\nWatch movie trailers, get showtimes and stream movies from your UltraViolet movie collection.  This app is no longer available in the Store, and has stopped functioning ever since.",
                Type = "App",
                Category = "Video + Entertainment"
            };

            Frame.Navigate(typeof(AppDetails), app);
        }

        private void Particle_Tapped_1(object sender, TappedRoutedEventArgs e)
        {
            StoreApplication app = new StoreApplication
            {
                Id = 103,
                Name = "Particle System",
                Publisher = "Jujuba Software",
                Version = "1.0.1.4",
                DownloadUrl = "https://appxboxdl.dankassassin368.com/Windows%208.0%20APPX%20Files/Games/Particle%20System/1.0.1.4/x64/AFF540DC.ParticleSystem_1.0.1.4_x64__v7353qx4kg3sa.appx",
                IconUrl = "https://i.ibb.co/VcZQJpYk/Logo.png",
                Description = "Run thousands of colorful particles on your screen in real-time. Click or touch the screen to create gravitational forces(multi-touche supported) Press a letter or number on the keyboard to make particles form it's shape. Press 'space' to explode it.",
                Type = "App",
                Category = "Video + Entertainment"
            };

            Frame.Navigate(typeof(AppDetails), app);
        }
    }
}
