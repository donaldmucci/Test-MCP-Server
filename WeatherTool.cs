using ModelContextProtocol.Server;
using OpenMeteo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_MCP_Server;

[McpServerToolType]
public static class WeatherTool
{
    [McpServerTool, Description("Returns the current weather in the city passed on in input.")]
    public static async Task<string> WeatherIn(string city)
    {
        OpenMeteo.OpenMeteoClient client = new OpenMeteo.OpenMeteoClient();

        WeatherForecast weatherData = await client.QueryAsync(city);

        return $"Weather in {city}: " + weatherData.Current.Temperature + weatherData.CurrentUnits.Temperature;
    }

    [McpServerTool, Description("Returns the current temperature in the city passed on in input.")]
    public static async Task<string> WeatherTemperature(string city) 
    {
        OpenMeteo.OpenMeteoClient client = new OpenMeteo.OpenMeteoClient();

        WeatherForecast weatherData = await client.QueryAsync(city);

        return weatherData.Current.Temperature + weatherData.CurrentUnits.Temperature;
    }
}
