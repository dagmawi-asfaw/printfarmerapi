using Microsoft.AspNetCore.Mvc;

namespace PrintFarm.controller;

[ApiController]
[Route("[Controller]")]
public class PrintFarmController : ControllerBase
{
    // public PrintFarmController() { }





    /// <summary>Calculates price based on the height and width of the frame</summary>
    /// <remarks>
    /// Sample request
    ///    GET http://localhost:5148/PrintFarm/200/220
    ///       Accept: application/json
    /// </remarks>
    /// <param name="height"/>
    /// <param name="width"/>
    /// <returns>string</returns>
    /// <response code="200">Returns the cost of the frame in dollars.</response>
    /// <response code="400">If the amount of frame material needed is less than 20 inches or greater than 1000 inches.</response>
    [HttpGet("{width}/{height}")]
    [Produces("text/plain")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<String> GetPrice(int height, int width)
    {
        string result;
        result = CalculatePrice(Convert.ToDouble(height), Convert.ToDouble(width));
        if (result == "not valid")
        {
            return BadRequest(result);
        }
        else
        {
            return Ok($"The cost of a {height}x{width} frame is ${result}");
        }
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