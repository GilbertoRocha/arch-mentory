using System.Reflection.Metadata;
using Azure.Core.Pipeline;
using Azure.Extensions.AspNetCore.Configuration.Secrets;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Hotline.Domain.Interfaces;
using Hotline.Infrastructure.Database;
using Hotline.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Azure.Core;
using Microsoft.Extensions.Hosting;

namespace Hotline.Infrastructure.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options => options.UseNpgsql(configuration["DB-CONNECTION"]));
        services.AddScoped<ITicketRepository, TicketRepository>();

        return services;
    }

    public static IConfigurationBuilder LoadEnvValues(this IConfigurationBuilder  configBuilder)
    {
        var currentConfig = configBuilder.Build();
        var vaultEndpoint = currentConfig["AzureKeyVault:Endpoint"];

        if (string.IsNullOrEmpty(vaultEndpoint))
            return configBuilder;
        
        var env = currentConfig["ASPNETCORE_ENVIRONMENT"] ?? "Production";
        Uri kvUri = new(vaultEndpoint);

        if (env.Equals("Development", StringComparison.OrdinalIgnoreCase))
            return LoadDevAzureKeyVault(kvUri, configBuilder);
        
        return configBuilder.AddAzureKeyVault(kvUri, new DefaultAzureCredential());
    }

    private static IConfigurationBuilder  LoadDevAzureKeyVault(Uri kvUri, IConfigurationBuilder  configBuilder)
    {
        SecretClientOptions clientOptions = new();
        
        clientOptions.ConfigureSimulatorSsl(kvUri);
        
        var secretClient = new SecretClient(kvUri , new TokenCredentialStub(), clientOptions);
        
        return configBuilder.AddAzureKeyVault(secretClient, new KeyVaultSecretManager());
        
    }
    
    private static void ConfigureSimulatorSsl(this SecretClientOptions options, Uri keyVaultUri)
    {
        var httpHandler = new HttpClientHandler
        {
            // For dev env ignores the SSL of the KV simulator
            ServerCertificateCustomValidationCallback = (message, cert, chain, sslPolicyErrors) => true,
            CheckCertificateRevocationList = false
        };
        var httpClient = new HttpClient(httpHandler);
        // replace when it is running in dev, inside the cluster
        httpClient.DefaultRequestHeaders.Host = keyVaultUri.Authority.Replace(".host.k3d.internal", "");
        //httpClient.DefaultRequestHeaders.Host = "mentory.vault.localhost:8443";
        
        options.Transport = new HttpClientTransport(httpClient);
        options.DisableChallengeResourceVerification = true;
    }
    
    
    private class TokenCredentialStub : TokenCredential
    {
        public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            return new ValueTask<AccessToken>(new AccessToken("fake-token-for-simulator", DateTimeOffset.MaxValue));
        }

        public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            return new AccessToken("fake-token-for-simulator", DateTimeOffset.MaxValue);
        }
    }
    
}