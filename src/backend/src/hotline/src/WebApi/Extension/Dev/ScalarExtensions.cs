using Scalar.AspNetCore;

namespace Hotline.WebApi.Extension.Dev;

public static class ScalarExtensions
{

    public static IEndpointRouteBuilder MapScalar(this IEndpointRouteBuilder endpoint, IHostEnvironment env)
    {
        if (!env.IsDevelopment())
            return endpoint;    
        
        endpoint.MapOpenApi();

        endpoint.MapScalarApiReference(options =>
        {
            options.WithTitle("Hotline WebAPi")
                .WithTheme(ScalarTheme.DeepSpace)
                .WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.HttpClient);
        });
        
        return endpoint;
    }
    
}