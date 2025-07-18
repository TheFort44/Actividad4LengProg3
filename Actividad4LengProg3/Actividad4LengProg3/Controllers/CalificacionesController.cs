﻿using Actividad4LengProg3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace Actividad4LengProg3.Controllers
{
    public class CalificacionesController : Controller
    {
        private readonly Actividad4LengProg3Context _context;

        public CalificacionesController(Actividad4LengProg3Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.Estudiantes = _context.Estudiante
            .Select(Elemento => new SelectListItem
            {
                Value = Elemento.Matricula,
                Text = Elemento.Matricula + " - " + Elemento.Nombre + " - " + Elemento.Carrera
            }).ToList();

            ViewBag.Materias = _context.Materia
            .Select(Elementos => new SelectListItem
            {
                Value = Elementos.Codigo,
                Text = Elementos.Codigo + " - " + Elementos.Nombre
            }).ToList();

            return View(new CalificacionViewModel());
        }


        [HttpPost]
        public IActionResult Calificar(CalificacionViewModel calificacion)
        {
            if (ModelState.IsValid)
            {
                _context.Calificacion.Add(calificacion);
                _context.SaveChanges();
                TempData["Mensaje"] = "Calificacion Publicada";
                return RedirectToAction("ListadoCalificaciones");
            }
            return View("Index", calificacion);
        }

        public IActionResult ListadoCalificaciones()
        {
            var calificacion = _context.Calificacion.ToList();
            return View(calificacion);
        }

        [HttpGet]
        public IActionResult Editar(string idcalificacion)
        {
            var calificacion = _context.Calificacion.FirstOrDefault(c => c.Id.ToString() == idcalificacion);
            if (calificacion == null)
            {
                TempData["Mensaje"] = "Esta calificacion no existe";
                return RedirectToAction("ListadoCalificaciones");
            }
            return View(calificacion);
        }

        [HttpPost]
        public IActionResult Editar(CalificacionViewModel calificacion)
        {
            if (!ModelState.IsValid)
            {
                return View(calificacion);
            }
            var calificacionActual = _context.Calificacion.FirstOrDefault(c => c.Id == calificacion.Id);
            if (calificacionActual == null)
            {
                TempData["Mensaje"] = "Esta calificacion no existe";
                return RedirectToAction("ListadoCalificaciones");
            }

            calificacionActual.Nota = calificacion.Nota;

            _context.Update(calificacionActual);
            _context.SaveChanges();

            TempData["Mensaje"] = "Calificacion Corregida";
            return RedirectToAction("ListadoCalificaciones");
        }

        public IActionResult Eliminar(int num)
        {
            var calificacion = _context.Calificacion.FirstOrDefault(c => c.Id == num);
            if (calificacion != null)
            {
                _context.Calificacion.Remove(calificacion);
                _context.SaveChanges();
                TempData["Mensaje"] = "Calificacion eliminada";
                return RedirectToAction("ListadoCalificaciones");
            }
            return View("ListadoCalificaciones", calificacion);
        }
    }
}
