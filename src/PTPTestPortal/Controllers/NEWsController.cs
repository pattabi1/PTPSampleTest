using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PTPTestPortal.Models;

namespace PTPTestPortal.Controllers
{
    public class NEWsController : Controller
    {
        private readonly PTPTestContext _context;

        public NEWsController(PTPTestContext context)
        {
            _context = context;
        }

        // GET: NEWs
        public async Task<IActionResult> Index()
        {
            var Newslist = _context.news.FromSql("PTP_getNews").ToList();
            return View(Newslist);
        }

        // GET: NEWs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nEWs = await _context.news
                .FirstOrDefaultAsync(m => m.NewsID == id);
            if (nEWs == null)
            {
                return NotFound();
            }

            return View(nEWs);
        }

        // GET: NEWs/Create
        public IActionResult CreateorEdit(int id)
        {
            if (id == 0)
            {
                return View();
            }
            else
            {
                return View(_context.news.Find(id));
            }
        }

        // POST: NEWs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateorEdit([Bind("NewsID,webSectionID,UploadID,Title,Body,Caption,sOrder,featuredCode,newsDate,startOn,endOn,isGlobal")] NEWs nEWs)
        {
            if (ModelState.IsValid)
            {
                //_context.Add(nEWs);
                if (nEWs.NewsID == 0)
                {
                    int newsResult = _context.Database.ExecuteSqlCommand("PTP_createNews @p0,@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10", nEWs.webSectionID, nEWs.UploadID, nEWs.Title, nEWs.Body,
                        nEWs.Caption, nEWs.sOrder, nEWs.featuredCode, nEWs.newsDate, nEWs.startOn, nEWs.endOn, nEWs.isGlobal);
                }
                else
                {
                    int newsResult = _context.Database.ExecuteSqlCommand("PTP_updateNews @p0,@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11", nEWs.NewsID, nEWs.webSectionID, nEWs.UploadID, nEWs.Title, nEWs.Body,
                        nEWs.Caption, nEWs.sOrder, nEWs.featuredCode, nEWs.newsDate, nEWs.startOn, nEWs.endOn, nEWs.isGlobal);
                }
                //await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nEWs);
        }

        // GET: NEWs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nEWs = await _context.news.FindAsync(id);
            if (nEWs == null)
            {
                return NotFound();
            }
            return View(nEWs);
        }

        // POST: NEWs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,webSectionID,UploadID,Title,Body,Caption,sOrder,featuredCode,newsDate,startOn,endOn,isGlobal")] NEWs nEWs)
        {
            if (id != nEWs.NewsID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nEWs);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NEWsExists(nEWs.NewsID))
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
            return View(nEWs);
        }

        // GET: NEWs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nEWs = await _context.news
                .FirstOrDefaultAsync(m => m.NewsID == id);
            if (nEWs == null)
            {
                return NotFound();
            }

            return View(nEWs);
        }

        // POST: NEWs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nEWs = await _context.news.FindAsync(id);
            _context.news.Remove(nEWs);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NEWsExists(int id)
        {
            return _context.news.Any(e => e.NewsID == id);
        }
    }
}
