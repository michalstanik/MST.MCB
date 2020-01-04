using IdentityModel.OidcClient;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using Xamarin.Forms;

namespace MCB.Mobile
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private HttpClient _client;
        string _accessToken;

        public MainPage()
        {
            InitializeComponent();
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            _client = new HttpClient();
        }

        async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            var options = new OidcClientOptions
            {
                Authority = Constants.AuthorityUri,
                ClientId = Constants.ClientId,
                Scope = Constants.Scope,
                RedirectUri = Constants.RedirectUri,
                ResponseMode = OidcClientOptions.AuthorizeResponseMode.Redirect
            };

            //string certResult = await DependencyService.Get<IServerCommunication>().GetFromServerAsync(options.Authority);

            var oidcClient = new OidcClient(options);
            var state = await oidcClient.PrepareLoginAsync();

            var response = await DependencyService.Get<INativeBrowser>().LaunchBrowserAsync(state.StartUrl);
            // HACK: Replace the RedirectURI, purely for UWP, with the current application callback URI.
            state.RedirectUri = Constants.RedirectUri;
            var result = await oidcClient.ProcessResponseAsync(response, state);

            if (result.IsError)
            {
                Debug.WriteLine("\tERROR: {0}", result.Error);
                return;
            }

            _accessToken = result.AccessToken;
        }
    }
}
