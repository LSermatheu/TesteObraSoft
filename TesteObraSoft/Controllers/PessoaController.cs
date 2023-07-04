using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using TesteObraSoft.Models;

namespace TesteObraSoft.Controllers
{
    public class PessoaController : Controller
    {
        private readonly Contexto _context;

        public PessoaController(Contexto context)
        {
            _context = context;
        }

        // GET: Pessoa
        public async Task<IActionResult> Index()
        {
            //return _context.Pessoa != null ? 
            //            View(await _context.Pessoa.ToListAsync()) :
            //            Problem("Entity set 'Contexto.Pessoa'  is null.");

            var pessoa = await _context.Pessoa.FromSqlRaw("ProcedureListar").ToListAsync();

            return View(pessoa);
        }

        // GET: Pessoa/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Pessoa == null)
            {
                return NotFound();
            }

            //var pessoa = await _context.Pessoa
            //    .FirstOrDefaultAsync(m => m.Id == id);

            var param = new SqlParameter("@id", id);
            var pessoa = await _context.Pessoa.FromSql($"EXECUTE ProcedureConsultar {param}").ToListAsync();

            if (pessoa == null)
            {
                return NotFound();
            }

            return View(pessoa[0]);
        }

        // GET: Pessoa/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pessoa/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Endereco,TelefoneFixo,TelefoneCelular,Email,Sexo,EstadoCivil,Salario")] Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                //_context.Add(pessoa);

                var param1 = new SqlParameter("@nome", pessoa.Nome);
                var param2 = new SqlParameter("@endereco", pessoa.Endereco);
                var param3 = new SqlParameter("@telFixo", pessoa.TelefoneFixo);
                var param4 = new SqlParameter("@telCelular", pessoa.TelefoneCelular);
                var param5 = new SqlParameter("@email", pessoa.Email);
                var param6 = new SqlParameter("@sexo", pessoa.Sexo);
                var param7 = new SqlParameter("@estadoCivil", pessoa.EstadoCivil);
                var param8 = new SqlParameter("@salario", pessoa.Salario);
                await _context.Database.ExecuteSqlAsync($"ProcedureIncluir {param1}, {param2}, {param3}, {param4}, {param5}, {param6}, {param7}, {param8}");

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pessoa);
        }

        // GET: Pessoa/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Pessoa == null)
            {
                return NotFound();
            }

            //var pessoa = await _context.Pessoa.FindAsync(id);

            var param = new SqlParameter("@id", id);
            var pessoa = await _context.Pessoa.FromSql($"EXECUTE ProcedureConsultar {param}").ToListAsync();

            if (pessoa == null)
            {
                return NotFound();
            }
            return View(pessoa[0]);
        }

        // POST: Pessoa/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Endereco,TelefoneFixo,TelefoneCelular,Email,Sexo,EstadoCivil,Salario")] Pessoa pessoa)
        {
            if (id != pessoa.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //_context.Update(pessoa);
                    var param = new SqlParameter("@id", pessoa.Id);
                    var param1 = new SqlParameter("@nome", pessoa.Nome);
                    var param2 = new SqlParameter("@endereco", pessoa.Endereco);
                    var param3 = new SqlParameter("@telFixo", pessoa.TelefoneFixo);
                    var param4 = new SqlParameter("@telCelular", pessoa.TelefoneCelular);
                    var param5 = new SqlParameter("@email", pessoa.Email);
                    var param6 = new SqlParameter("@sexo", pessoa.Sexo);
                    var param7 = new SqlParameter("@estadoCivil", pessoa.EstadoCivil);
                    var param8 = new SqlParameter("@salario", pessoa.Salario);
                    await _context.Database.ExecuteSqlAsync($"EXECUTE ProcedureAlterar {param}, {param1}, {param2}, {param3}, {param4}, {param5}, {param6}, {param7}, {param8}");

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PessoaExists(pessoa.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(pessoa);
        }

        // GET: Pessoa/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Pessoa == null)
            {
                return NotFound();
            }

            //var pessoa = await _context.Pessoa
            //    .FirstOrDefaultAsync(m => m.Id == id);

            var param = new SqlParameter("@id", id);
            var pessoa = await _context.Pessoa.FromSql($"EXECUTE ProcedureConsultar {param}").ToListAsync();

            if (pessoa == null)
            {
                return NotFound();
            }

            return View(pessoa[0]);
        }

        // POST: Pessoa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Pessoa == null)
            {
                return Problem("Entity set 'Contexto.Pessoa'  is null.");
            }
            var pessoa = await _context.Pessoa.FindAsync(id);
            if (pessoa != null)
            {
                //_context.Pessoa.Remove(pessoa);

                //var param = new SqlParameter("@id", id);
                await _context.Database.ExecuteSqlRawAsync($"EXECUTE ProcedureExcluir {id}");

            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PessoaExists(int id)
        {
            //return (_context.Pessoa?.Any(e => e.Id == id)).GetValueOrDefault();
            //var param = new SqlParameter("@id", id);

            var pessoa = _context.Pessoa.FromSql($"EXECUTE ProcedureConsultar {id}").Any();

            return pessoa;
        }
    }
}
