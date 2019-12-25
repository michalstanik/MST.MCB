using MCB.Business.Models.Geo;
using Microsoft.AspNetCore.Http;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;

namespace MCB.Api.OperationFilters
{
    public class RegionOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var mediaTypesGetRegionDictionary = new Dictionary<string, Type>()
            {
                { "application/vnd.mcb.regionwithuservisits+json", typeof(RegionModelWithCountriesAndUserVisits) }
            };

            switch (operation.OperationId)
            {
                case "GetRegion":

                    foreach (var mediaType in mediaTypesGetRegionDictionary)
                    {
                        operation.Responses[StatusCodes.Status200OK.ToString()].Content.Add(
                            mediaType.Key,
                            new OpenApiMediaType()
                            {
                                Schema = context.SchemaRegistry.GetOrRegister(mediaType.Value)
                            });
                    }
                    break;

                default:
                    return;
            }
        }
    }
}
