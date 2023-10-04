using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PSIUWeb.Data.Interface;
using PSIUWeb.Models;

namespace PSIUWeb.Controllers
{
    public class PsicoController : Controller
    {
        private IPsicoRepository psicoRepository;

        public PsicoController(
            IPsicoRepository _psicoRepository
        )
        {
            psicoRepository = _psicoRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(
                psicoRepository.GetPsico()
            );
        }

        [HttpGet]
        public IActionResult Edit2(int? id)
        {
            if (id <= 0 || id == null)
                return NotFound();

            Psico? p =
                psicoRepository.GetPsicoById(id.Value);

            if (p == null)
                return NotFound();

            return View(p);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Psico psico)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    psicoRepository.Update(psico);
                    return View("Index", psicoRepository.GetPsico());
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
            }
            return View("Index");
        }

        [HttpGet]
        public IActionResult Delete1(int? id)
        {
            if (id == null)
                return NotFound();

            Psico ?p = psicoRepository.GetPsicoById(id.Value);

            if (p == null)
                return NotFound();

            return View(p);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            if (id == null || id == 0)
                return NotFound();

            psicoRepository.Delete(id);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Insert(Psico p)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    psicoRepository.Create(p);
                    return View("Index", psicoRepository.GetPsico());
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return View();
        }

       

    }
}
