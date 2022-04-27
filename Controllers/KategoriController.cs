using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvsStok.Models.Entity;


namespace MvsStok.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Category()
        {
            var ctgry = db.TBLKATEGORILERs.ToList();
            
            return View(ctgry);
        }
        public ActionResult Products()
        {
            var prdct = db.TBLURUNLERs.ToList();
            return View(prdct);
        }

        public ActionResult Customers()
        {
            var cstmr = db.TBLMUSTERILERs.ToList();
            return View(cstmr);
        }

        public ActionResult GetHelp()
        {
            return View();
        }
        [HttpGet]
        public ActionResult YeniKategori()
        {
            return View();
        }


        [HttpPost]
        public ActionResult YeniKategori(TBLKATEGORILER p1)
        {
            db.TBLKATEGORILERs.Add(p1);
            db.SaveChanges();
            return View();
        }

        [HttpGet]
        public ActionResult musteriEkleme()
        {
            return View();
        }


        [HttpPost]
        public ActionResult musteriEkleme(TBLMUSTERILER p2)
        {
            db.TBLMUSTERILERs.Add(p2);
            db.SaveChanges();
            return View();
        }

        [HttpGet] 
        public ActionResult urunEkleme()
        {
            List<SelectListItem> degerler = (from i in db.TBLKATEGORILERs.ToList()
                                            select new SelectListItem
                                            {
                                                Text = i.KATEGORIAD,
                                                Value = i.KATEGORIID.ToString()
                                            }).ToList();
            ViewBag.dgr = degerler;
            return View();
        }
        [HttpPost]
        public ActionResult urunEkleme(TBLURUNLER p3)
        {
            var ktg = db.TBLKATEGORILERs.Where(m => m.KATEGORIID == p3.TBLKATEGORILERs.KATEGORIID).FirstOrDefault();
            p3.TBLKATEGORILERs = ktg;
            db.TBLURUNLERs.Add(p3);
            db.SaveChanges();
            return RedirectToAction("Products");
        }

        public ActionResult KategoriSil(int id)
        {
            var category = db.TBLKATEGORILERs.Find(id);
            db.TBLKATEGORILERs.Remove(category);
            db.SaveChanges();
            return RedirectToAction("Category");
        }
        
        public ActionResult productDelete(int id)
        {
            var product = db.TBLURUNLERs.Find(id);
            db.TBLURUNLERs.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Products");
        }
        
        public ActionResult customerDelete(int id)
        {
            var customer = db.TBLMUSTERILERs.Find(id);
            db.TBLMUSTERILERs.Remove(customer);
            db.SaveChanges();
            return RedirectToAction("Customers");
        }
        public ActionResult categoryGetter(int id)
        {
            var ctgry = db.TBLKATEGORILERs.Find(id);
            return View("categoryGetter",ctgry);
        } 
        
        public ActionResult UpdateCategory(TBLKATEGORILER p1)
        {
            var ctgr = db.TBLKATEGORILERs.Find(p1.KATEGORIID);
            ctgr.KATEGORIAD = p1.KATEGORIAD;
            db.SaveChanges();
            return RedirectToAction("Category");
        }
        public ActionResult productUpdate(int id)
        {
            var prdct = db.TBLURUNLERs.Find(id);
            return View("productUpdate",prdct);
        }

        public ActionResult customerUpdate(int id)
        {
            var cstmr = db.TBLMUSTERILERs.Find(id);
            return View("customerUpdate", cstmr);
        }
        public ActionResult UpdateCustomer(TBLMUSTERILER p2)
        {
            var cstmr = db.TBLMUSTERILERs.Find(p2.MUSTERIID);
            cstmr.MUSTERIAD = p2.MUSTERIAD;
            cstmr.MUSTERISOYAD = p2.MUSTERISOYAD;
            db.SaveChanges();
            return RedirectToAction("Customers");
        }

        public ActionResult UpdateProduct(TBLURUNLER p3)
        {
            var prdct = db.TBLURUNLERs.Find(p3.URUNID);
            prdct.URUNAD = p3.URUNAD;
            prdct.MARKA = p3.MARKA;
            prdct.URUNKATEGORI = p3.URUNKATEGORI;
            prdct.FIYAT = p3.FIYAT;
            prdct.STOK = p3.STOK;
            db.SaveChanges();
            return RedirectToAction("Products");
        }
    }   
        
}
