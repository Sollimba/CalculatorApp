using Microsoft.AspNetCore.Mvc;
using LabCalculator.Models;

[Route("api/[controller]")]
[ApiController]
public class CalculatorController : ControllerBase
{
    [HttpPost]
    public ActionResult<double> Calculate([FromBody] CalculatorModel model)
    {
        // Проверка на наличие первого операнда и операции
        if (model.FirstOperand == 0 && string.IsNullOrEmpty(model.Operation))
        {
            return BadRequest("Model is required.");
        }

        double result = 0;

        switch (model.Operation)
        {
            case "+":
                result = model.FirstOperand + model.SecondOperand.GetValueOrDefault();
                break;
            case "-":
                result = model.FirstOperand - model.SecondOperand.GetValueOrDefault();
                break;
            case "*":
                result = model.FirstOperand * model.SecondOperand.GetValueOrDefault();
                break;
            case "/":
                if (model.SecondOperand == 0) return BadRequest("Division by zero.");
                result = model.FirstOperand / model.SecondOperand.GetValueOrDefault();
                break;
            case "^":
                result = Math.Pow(model.FirstOperand, model.SecondOperand.GetValueOrDefault());
                break;
            case "sqrt":
                result = Math.Sqrt(model.FirstOperand);
                break;
            case "sin":
                result = Math.Sin(model.FirstOperand * (Math.PI / 180)); // Преобразование в радианы
                break;
            case "cos":
                result = Math.Cos(model.FirstOperand * (Math.PI / 180)); // Преобразование в радианы
                break;
            case "tan":
                result = Math.Tan(model.FirstOperand * (Math.PI / 180)); // Преобразование в радианы
                break;
            case "cot":
                result = 1 / Math.Tan(model.FirstOperand * (Math.PI / 180)); // Преобразование в радианы
                break;
            default:
                return BadRequest("Invalid operation");
        }

        // Округляем результат до одного знака после запятой
        result = Math.Round(result, 1);

        return Ok(result);
    }
}