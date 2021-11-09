
using MediatR;

namespace CentevaArchitecture.Application.WeatherForecasts
{
    public class GetWeatherForecastQuery : IRequest<List<WeatherForecastDto>>
    {
        // No params

        public class GetWeatherForecastHandler : IRequestHandler<GetWeatherForecastQuery, List<WeatherForecastDto>>
        {
            public Task<List<WeatherForecastDto>> Handle(GetWeatherForecastQuery request, CancellationToken cancellationToken)
            {
                var result = Enumerable.Range(1, 5).Select(index => new WeatherForecastDto
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                }).ToList();

                return Task.FromResult(result);
            }

            private static readonly string[] Summaries = new[]
            {
                "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
            };
        }
    }
}
