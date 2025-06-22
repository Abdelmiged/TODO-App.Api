using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Shared.Algos;

namespace TODO_App.Api.Middlewares
{
    public class CatchAllUnknownRouteHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IApiDescriptionGroupCollectionProvider _apiProvider; // A built-in service that provides metadata about all API routes in the application

        public CatchAllUnknownRouteHandlerMiddleware(RequestDelegate _request,  IApiDescriptionGroupCollectionProvider _provider)
        {
            _next = _request;
            _apiProvider = _provider;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // First, wait for the response
            await _next(context);

            // Check if status code is 404, and if it's an api call (the route has the /api standard that I'm using)
            if(context.Response.StatusCode == 404 && context.Request.Path.StartsWithSegments("/api"))
            {
                // Groups api routes usually based on controller
                var otherApiRoutes = _apiProvider.ApiDescriptionGroups.Items.SelectMany(G => G.Items)
                                                                            .Select(R => R.RelativePath?
                                                                            .Split('?').FirstOrDefault())
                                                                            .Distinct()
                                                                            .ToList();

                var requestPath = context.Request.Path.Value?.TrimStart('/');

                List<string> validApiAlternativeRoutes = new List<string>();

                foreach(var route in otherApiRoutes)
                {
                    var distance = LevenshteinDistance.CalcSimilarity(requestPath, route);

                    if(distance <= LevenshteinDistance.SimilarityTolerance)
                        validApiAlternativeRoutes.Add(route);
                }

                context.Response.ContentType = "application/json";

                if (validApiAlternativeRoutes.Count != 0)
                {
                    string validRoutes = "";
                    for(int i = 0; i < validApiAlternativeRoutes.Count; i++)
                    {
                        string conjMsg = " or ";
                        if (i == validApiAlternativeRoutes.Count - 1)
                            conjMsg = "";
                        validRoutes += "/" + validApiAlternativeRoutes[i] + conjMsg;
                    }

                    string message = $"The requested route doesn't exist, did you mean {validRoutes}";

                    await context.Response.WriteAsJsonAsync(message);
                }
                else
                {
                    string message = $"The requested route doesn't exist.";

                    await context.Response.WriteAsJsonAsync(message);
                }
            }
        }
    }
}
