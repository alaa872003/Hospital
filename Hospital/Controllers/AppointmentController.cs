using Hospital.Data;
using Hospital.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers
{
    public class AppointmentController : Controller
    {

        ApplicationDbContext context = new ApplicationDbContext();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ShowAppointment(int id)
        {
            var appointments = context.Appointments.Where(e=>e.DoctorId==id);

            return View(appointments);
        }

  


    }
}

