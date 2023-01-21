using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class EmpleadoController : Controller
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            ML.Empleado empleado=new ML.Empleado(); 

            ML.Result result=BL.Empleado.GetAll();
            if (result.Correct)
            {
                empleado.EmpleadoList = result.Objects;
                return View(empleado);
            }
            else
            {
                return View();
            }
        }
        
        [HttpGet]
        public IActionResult Form(int? IdEmpleado)
        {
            ML.Empleado empleado= new ML.Empleado();

            if (IdEmpleado==null)
            {
                return View(empleado);
            }
            else
            {
                ML.Result result = BL.Empleado.GetById(IdEmpleado.Value);
                if (result.Correct)
                {
                    empleado = (ML.Empleado)result.Object;
                }
                return View(empleado);
            }
        }

        [HttpPost]
        public IActionResult Form(ML.Empleado empleado)
        {
            ML.Result result=new ML.Result();

            if (empleado.IdEmpleado==0)
            {
                result = BL.Empleado.Add(empleado);
                if (result.Correct)
                {
                    ViewBag.Message = result.Message;
                }
                else
                {
                    ViewBag.Message = "Ocrrio un error";
                }
            }
            else
            {
                result = BL.Empleado.Update(empleado);
                if (result.Correct)
                {
                    ViewBag.Message = result.Message;
                }
                else
                {
                    ViewBag.Message = "Ocrrio un error";
                }

            }
            return PartialView("Modal");
        }

        [HttpGet]
        public IActionResult Delete(int? IdEmpleado)
        {

            if (IdEmpleado>0)
            {
                ML.Result result = BL.Empleado.Delete(IdEmpleado.Value);
                ViewBag.Message = result.Message;
            }
            else
            {
                ViewBag.Message = "Ocrrio un error";
            }
            return PartialView("Modal");
        }

        public JsonResult UpdateStatus(int IdEmpleado,bool Status)
        {
            var result = BL.Empleado.UpdateStatus(IdEmpleado,Status);
            return Json(result);
        }
    }
}
