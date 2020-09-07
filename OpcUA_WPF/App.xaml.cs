using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows;
using Workstation.ServiceModel.Ua;

namespace OpcUA_WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private UaApplication application;

        protected override void OnStartup(StartupEventArgs e)
        {
            // Build and run an OPC UA application instance.
            this.application = new UaApplicationBuilder()
                .SetApplicationUri($"urn:{Dns.GetHostName()}:Workstation.StatusHmi")
                .SetDirectoryStore($"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\\Workstation.StatusHmi\\pki")
                .SetIdentity(this.ShowSignInDialog)
                .Build();

            this.application.Run();

            // Create and show the main view.
            //var view = new MainWindow();
            //view.Show();
        }

        private async Task<IUserIdentity> ShowSignInDialog(EndpointDescription endpoint)
        {
            if (endpoint.UserIdentityTokens.Any(p => p.TokenType == UserTokenType.Anonymous))
            {
                return new AnonymousIdentity();
            }
            throw new NotImplementedException("ProvideUserIdentity supports only UserName and Anonymous identity, for now.");
        }
    }
}
