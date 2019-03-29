using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Apolice.Web.Models;
using Apolice.Service;
using Apolice.Model.Models;
using PagedList;

namespace Apolice.Web.Controllers
{
    public class ApoliceController : Controller
    {

        private IApoliceService apoliceService;

        public ApoliceController(IApoliceService apoliceService)
        {
            this.apoliceService = apoliceService;
        }

        [HttpGet]
        public ActionResult Index(string sortOrder, string currentFilter, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NumeroParam = sortOrder == "Numero" ? "Numero_desc" : "Numero";
            ViewBag.PlacaParam = sortOrder == "Placa" ? "Placa_desc" : "Placa";

            
            ViewBag.CurrentFilter = currentFilter;

            List<ApoliceModel> list = null;

            
                list = apoliceService.GetApolices().Select(u => new ApoliceModel
                {
                    NumeroApolice = u.NumeroApolice,
                    CpfCnpj = u.CpfCnpj,
                    PlacaVeiculo = u.PlacaVeiculo,
                    ValorPremio = u.ValorPremio,
                    ID = u.ID
                }).ToList();
            


            switch (sortOrder)
            {
                case "Placa":
                    list = list.OrderBy(s => s.PlacaVeiculo).ToList();
                    break;
                case "Placa_desc":
                    list = list.OrderByDescending(s => s.PlacaVeiculo).ToList();
                    break;
                case "Numero":
                    list = list.OrderBy(s => s.NumeroApolice).ToList();
                    break;
                case "Numero_desc":
                    list = list.OrderByDescending(s => s.NumeroApolice).ToList();
                    break;
                default:
                    list = list.OrderBy(s => s.ID).ToList();
                    break;
            }

            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(list.ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        public ActionResult SaveOrEdit(int? id)
        {
            ApoliceModel model = new ApoliceModel();

            try
            {
                if (id.HasValue && id != 0)
                {
                    Model.Models.Apolice apoliceEntity = apoliceService.GetApolice((int)id.Value);
                    model.NumeroApolice = apoliceEntity.NumeroApolice;
                    model.CpfCnpj = apoliceEntity.CpfCnpj;
                    model.PlacaVeiculo = apoliceEntity.PlacaVeiculo;
                    model.ValorPremio = apoliceEntity.ValorPremio;
                    model.ID = apoliceEntity.ID;
                }
            }
            catch (Exception ex)
            {
                string message = string.Format("<b>Atenção:</b> {0}<br /><br />", ex.Message);
                ModelState.AddModelError(string.Empty, message);
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult SaveOrEdit(ApoliceModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                if (model.ID == 0)
                {
                    Model.Models.Apolice apoliceEntity = new Model.Models.Apolice
                    {
                        NumeroApolice = model.NumeroApolice,
                        CpfCnpj = model.CpfCnpj,
                        PlacaVeiculo = model.PlacaVeiculo,
                        ValorPremio = model.ValorPremio
                    };

                    apoliceService.Insert(apoliceEntity);

                    if (apoliceEntity.ID > 0)
                    {
                        return RedirectToAction("index");
                    }
                }
                else
                {
                    Model.Models.Apolice apoliceEntity = apoliceService.GetApolice((int)model.ID);

                    apoliceEntity.NumeroApolice = model.NumeroApolice;
                    apoliceEntity.CpfCnpj = model.CpfCnpj;
                    apoliceEntity.PlacaVeiculo = model.PlacaVeiculo;
                    apoliceEntity.ValorPremio = model.ValorPremio;
                    apoliceEntity.ID = model.ID;

                    apoliceService.Update(apoliceEntity);

                    if (apoliceEntity.ID > 0)
                    {
                        return RedirectToAction("index");
                    }
                }
            }
            catch (Exception ex)
            {
                string message = string.Format("<b>Atenção:</b> {0}<br /><br />", ex.Message);
                ModelState.AddModelError(string.Empty, message);
            }

            return View(model);
        }

        public ActionResult Detail(int? id)
        {
            ApoliceModel model = new ApoliceModel();
            if (id.HasValue && id != 0)
            {
                Model.Models.Apolice apoliceEntity = apoliceService.GetApolice((int)id.Value);
                // model.ID = apoliceEntity.ID;
                model.NumeroApolice = apoliceEntity.NumeroApolice;
                model.CpfCnpj = apoliceEntity.CpfCnpj;
                model.PlacaVeiculo = apoliceEntity.PlacaVeiculo;
                model.ValorPremio = apoliceEntity.ValorPremio;

            }
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            ApoliceModel model = new ApoliceModel();
            if (id != 0)
            {
                Model.Models.Apolice apoliceEntity = apoliceService.GetApolice((int)id);
                model.NumeroApolice = apoliceEntity.NumeroApolice;
                model.CpfCnpj = apoliceEntity.CpfCnpj;
                model.PlacaVeiculo = apoliceEntity.PlacaVeiculo;
                model.ValorPremio = apoliceEntity.ValorPremio;

            }
            return View(model);
        }


        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                if (id != 0)
                {
                    Model.Models.Apolice apoliceEntity = apoliceService.GetApolice((int)id);

                    apoliceService.Delete(apoliceEntity);

                    return RedirectToAction("Index");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }
    }
}
