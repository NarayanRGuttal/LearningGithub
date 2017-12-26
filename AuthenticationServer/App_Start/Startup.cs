 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Owin;
using Microsoft.Owin;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using AuthenticationServer.Providers;

[assembly: OwinStartup(typeof(AuthenticationServer.Startup))]

namespace AuthenticationServer
{

	public  class Startup
	{
		public void Configuration(IAppBuilder appBuilder)
		{
			ConfigureAuth(appBuilder);
		}

		public void ConfigureAuth(IAppBuilder appBuilder)
		{
			OAuthAuthorizationServerOptions OAuthOptions = new OAuthAuthorizationServerOptions()
			{
				TokenEndpointPath = new PathString("/token"),
				Provider = new OAuthTokenProvider(),
				AccessTokenExpireTimeSpan = TimeSpan.FromDays(2),
				AllowInsecureHttp = true

			};


			appBuilder.UseOAuthAuthorizationServer(OAuthOptions);
			appBuilder.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
			//HttpConfiguration httpConfig = new HttpConfiguration();
			//WebApiConfig.Register(httpConfig);

		}

	}
}