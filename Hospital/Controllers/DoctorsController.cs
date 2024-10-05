
using Hospital.Data;
using Hospital.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace Hospital.Controllers
{
    public class DoctorsController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult BookAppointment()
        {
            var doctors = context.Doctors.ToList();
            return View(model: doctors);
        }

        public IActionResult CompleteAppointment(int id)
        {

            var doctor = context.Doctors.Where(e => e.Id == id).FirstOrDefault();
            if (doctor != null)
                return View(doctor);
            return RedirectToAction("NotFounded");
        }
        [HttpPost]
        public IActionResult CompleteAppointment(Appointment appointment)
        {
            context.Appointments.Add(appointment);
            context.SaveChanges();
            return RedirectToAction("ShowAppointment");

        }


        public IActionResult NotFounded()
        {
            return View();
        }

      
    }
}
