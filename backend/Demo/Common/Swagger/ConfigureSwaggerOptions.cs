using System.Runtime.CompilerServices;
using Asp.Versioning.ApiExplorer;
using Demo.Common.Extensions;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Nexticz.Magic.Shared.Lib.Swagger;

public class ConfigureSwaggerOptions
    : IConfigureOptions<SwaggerGenOptions>
{
    private readonly IApiVersionDescriptionProvider _provider;
    private readonly IConfiguration _config;

    public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider, IConfiguration config)
    {
        _provider = provider;
        _config = config;
    }

    public void Configure(SwaggerGenOptions options)
    {
    }
}

public class RequiredNotNullableSchemaFilter : ISchemaFilter
{
    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        if (schema.Properties == null) return;

        var properties = context.Type.GetProperties();

        foreach (var schemProp in schema.Properties)
        {
            var codeProp =
                properties.SingleOrDefault(x => x.Name.ToCamelCase() == schemProp.Key)
                ?? throw new MissingFieldException(
                    $"Could not find property {schemProp.Key} in {context.Type}, or several names conflict."
                );

            var isRequired = Attribute.IsDefined(codeProp, typeof(RequiredMemberAttribute));
            if (isRequired)
                //schemProp.Value.Nullable = false;
                _ = schema.Required.Add(schemProp.Key);
        }
    }
}