using MCB.Business.Models.Trips;
using Microsoft.AspNetCore.Http;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;

namespace MCB.Api.OperationFilters
{
    public class TripOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var mediaTypesGetTripDictionary = new Dictionary<string, Type>()
            {
                { "application/vnd.mcb.tripwithstops+json", typeof(TripWithStopsModel) },
                { "application/vnd.mcb.tripfull+json", typeof(TripFullModel) },
                { "application/vnd.mcb.tripwithstopsandusers+json", typeof(TripWithStopsAndUsersModel) },
                { "application/vnd.mcb.tripwithcountries+json", typeof(TripWithCountriesModel) },
                { "application/vnd.mcb.tripwithcountriesandstats+json", typeof(TripWithCountriesAndStatsModel) },
                { "application/vnd.mcb.tripwithcountriesandworldheritages+json", typeof(TripWithCountriesAndWorldHeritagesModel) }
            };

            var mediaTypesGetTripsDictionary = new Dictionary<string, Type>()
            {
                { "application/vnd.mcb.tripwithstops+json", typeof(TripWithStopsModel) },
                { "application/vnd.mcb.tripwithstopsandusers+json", typeof(TripWithStopsAndUsersModel) },
                { "application/vnd.mcb.tripwithcountries+json", typeof(TripWithCountriesModel) },
                { "application/vnd.mcb.tripwithcountriesandstats+json", typeof(TripWithCountriesAndStatsModel) },
                { "application/vnd.mcb.tripwithcountriesandworldheritages+json", typeof(TripWithCountriesAndWorldHeritagesModel) }
            };

            var mediaTypesSetTripDictionary = new Dictionary<string, Type>()
            {
                {"application/vnd.mcb.tripwithstopsforcreation+json", typeof(TripWithStopsModelForCreation)}
            };

            switch (operation.OperationId)
            {
                case "GetTrip":

                    foreach (var mediaType in mediaTypesGetTripDictionary)
                    {
                        operation.Responses[StatusCodes.Status200OK.ToString()].Content.Add(
                            mediaType.Key,
                            new OpenApiMediaType()
                            {
                                Schema = context.SchemaRegistry.GetOrRegister(mediaType.Value)
                            });
                    }
                    break;

                case "GetTrips":

                    foreach (var mediaType in mediaTypesGetTripsDictionary)
                    {
                        operation.Responses[StatusCodes.Status200OK.ToString()].Content.Add(
                            mediaType.Key,
                            new OpenApiMediaType()
                            {
                                Schema = context.SchemaRegistry.GetOrRegister(mediaType.Value)
                            });
                    }
                    break;

                case "AddTrip":

                    foreach (var mediaType in mediaTypesSetTripDictionary)
                    {
                        operation.RequestBody.Content.Add(
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
