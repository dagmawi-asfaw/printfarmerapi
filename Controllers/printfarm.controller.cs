using Microsoft.AspNetCore.Mvc;

namespace PrintFarm.controller;

[ApiController]
[Route("[Controller]")]
public class PrintFarmController : ControllerBase
{
    // public PrintFarmController() { }

    [HttpGet]
    public string GetPrice(int height, int width)
    {
        return "default get";
    }




    [HttpGet("{width}/{height}")]
    public string GetIt(int height, int width)
    {
        string result;
        result = CalculatePrice(Convert.ToDouble(height), Convert.ToDouble(width));
        return $"The cost of a {height}x{width} frame is {result}";
    }

    private string CalculatePrice(double height, double width)
    {
        double perimeter;
        perimeter = (2 * height) + (2 * width);

        if ((perimeter > 20.00) && (perimeter <= 50.00))
        {
            return "20.00";
        }
        if ((perimeter > 50.00) && (perimeter <= 100.00))
        {
            return "50.00";
        }
        if ((perimeter > 100.00) && (perimeter <= 1000.00))
        {
            return "100.00";
        }
        return "not valid";
    }
}