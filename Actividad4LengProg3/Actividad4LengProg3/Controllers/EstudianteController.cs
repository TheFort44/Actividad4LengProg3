using Actividad4LengProg3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Actividad4LengProg3.Controllers
{
    public class EstudianteController : Controller
    {
        private static List<EstudianteViewModel> estudiantes = new List<EstudianteViewModel>()
        {
            new EstudianteViewModel
            {
                NombreCompleto = "Jaime Escalante",
                Matricula = "SD-2023-04866",
                Carrera = "Ingeniería",
                CorreoInstitucional = "sd-2023-04866@ufhec.edu.do",
                Telefono = "8297584971",
                FechaNacimiento = new DateTime(2004, 1, 21),
                Genero = "Masculino",
                Turno = "Mañana",
                TipoIngreso = "Nuevo ingreso",
                EstaBecado = true,
                PorcentajeBeca = 100,
                TerminosYCondiciones = true
            },
            new EstudianteViewModel
            {
                NombreCompleto = "Carlos Jiménez Peña",
                Matricula = "MT-2023-0582",
                Carrera = "Medicina",
                CorreoInstitucional = "carlos.jimenez@ufhec.edu.do",
                Telefono = "8095552345",
                FechaNacimiento = new DateTime(2000, 11, 10),
                Genero = "Masculino",
                Turno = "Tarde",
                TipoIngreso = "Reingreso",
                EstaBecado = false,
                PorcentajeBeca = null,
                TerminosYCondiciones = true
            },
            new EstudianteViewModel
            {
                NombreCompleto = "María Fernández Gómez",
                Matricula = "SD-2023-0823",
                Carrera = "Derecho",
                CorreoInstitucional = "maria.fernandez@ufhec.edu.do",
                Telefono = "8095553456",
                FechaNacimiento = new DateTime(2002, 3, 15),
                Genero = "Femenino",
                Turno = "Noche",
                TipoIngreso = "Transferencia",
                EstaBecado = true,
                PorcentajeBeca = 75,
                TerminosYCondiciones = true
            },
            new EstudianteViewModel
            {
                NombreCompleto = "José Martínez Ruiz",
                Matricula = "SD-2023-4824",
                Carrera = "Arquitectura",
                CorreoInstitucional = "jose.martinez@ufhec.edu.do",
                Telefono = "8095554567",
                FechaNacimiento = new DateTime(1999, 8, 30),
                Genero = "Masculino",
                Turno = "Mañana",
                TipoIngreso = "Nuevo ingreso",
                EstaBecado = false,
                PorcentajeBeca = null,
                TerminosYCondiciones = true
            }
        };

        private readonly List<string> carreras = new List<string> { "Ingeniería", "Medicina", "Derecho", "Arquitectura" };
        private readonly List<string> tiposIngreso = new List<string> { "Nuevo ingreso", "Reingreso", "Transferencia" };

        [HttpGet]
        public IActionResult Index()
        {
            CargarCombos();
            return View(new EstudianteViewModel());
        }

        [HttpPost]
        public IActionResult Registrar(EstudianteViewModel model)
        {
            CargarCombos();

            if (!ModelState.IsValid)
            {
                return View("Index", model);
            }

            estudiantes.Add(model);
            TempData["Mensaje"] = "Estudiante registrado correctamente.";
            return RedirectToAction("ListadoEstudiantes");
        }

        public IActionResult ListadoEstudiantes(string filtroMatricula)
        {
            var listaFiltrada = string.IsNullOrEmpty(filtroMatricula)
                ? estudiantes
                : estudiantes.Where(e => e.Matricula.Contains(filtroMatricula, StringComparison.OrdinalIgnoreCase)).ToList();

            return View(listaFiltrada);
        }

        private void CargarCombos()
        {
            ViewBag.Carreras = new SelectList(carreras);
            ViewBag.TiposIngreso = new SelectList(tiposIngreso);
        }

        [HttpGet]
        public IActionResult Eliminar(string matricula)
        {
            var estudiante = estudiantes.FirstOrDefault(e => e.Matricula == matricula);
            if (estudiante != null)
            {
                estudiantes.Remove(estudiante);
                TempData["Mensaje"] = "Estudiante eliminado correctamente.";
            }

            return RedirectToAction("ListadoEstudiantes");
        }

        [HttpGet]
        public IActionResult Editar(string matricula)
        {
            var estudiante = estudiantes.FirstOrDefault(e => e.Matricula == matricula);
            if (estudiante == null)
            {
                TempData["MensajeError"] = "Estudiante no encontrado.";
                return RedirectToAction("ListadoEstudiantes");
            }

            ViewBag.Carreras = new SelectList(carreras, estudiante.Carrera);
            ViewBag.TiposIngreso = new SelectList(tiposIngreso, estudiante.TipoIngreso);

            return View(estudiante);
        }

        [HttpPost]
        public IActionResult Editar(EstudianteViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Carreras = new SelectList(carreras, model.Carrera);
                ViewBag.TiposIngreso = new SelectList(tiposIngreso, model.TipoIngreso);
                return View(model);
            }

            var estudianteExistente = estudiantes.FirstOrDefault(e => e.Matricula == model.Matricula);
            if (estudianteExistente == null)
            {
                TempData["MensajeError"] = "Estudiante no encontrado.";
                return RedirectToAction("ListadoEstudiantes");
            }

            estudianteExistente.NombreCompleto = model.NombreCompleto;
            estudianteExistente.Carrera = model.Carrera;
            estudianteExistente.CorreoInstitucional = model.CorreoInstitucional;
            estudianteExistente.Telefono = model.Telefono;
            estudianteExistente.FechaNacimiento = model.FechaNacimiento;
            estudianteExistente.Genero = model.Genero;
            estudianteExistente.Turno = model.Turno;
            estudianteExistente.TipoIngreso = model.TipoIngreso;
            estudianteExistente.EstaBecado = model.EstaBecado;
            estudianteExistente.PorcentajeBeca = model.PorcentajeBeca;
            estudianteExistente.TerminosYCondiciones = model.TerminosYCondiciones;

            TempData["MensajeExito"] = "Cambios guardados con éxito.";

            return RedirectToAction("ListadoEstudiantes");
        }
    }
}