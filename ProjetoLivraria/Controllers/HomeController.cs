using MySql.Data.MySqlClient;
using ProjetoLivraria.Dados;
using ProjetoLivraria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoLivraria.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult CadAutor()
        {
            CarregaStatus();
            return View();
        }

        ModStatus model = new ModStatus();
        AcStatus atos = new AcStatus();

        AcAutor acoes = new AcAutor();
        ModAutor modelo = new ModAutor();

        public ActionResult ConfCadAutor(FormCollection frm)
        {
            modelo.nomeAutor = frm["txtNmAutor"];
            modelo.status = Request["status"];
            acoes.inserirAutor(modelo);

            return View();
        }

        public void CarregaStatus()
        {
            List<SelectListItem> status = new List<SelectListItem>();

            using (MySqlConnection con = new MySqlConnection("Server=localhost; Database=bdlivraria8_3; User=root; pwd=12345678"))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from tbStatus", con);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    status.Add(new SelectListItem
                    {
                        Text = rdr[1].ToString(),
                        Value = rdr[0].ToString()
                    });
                }
                con.Close();
            }

            ViewBag.status = new SelectList(status, "Value", "Text");
        }

        public ActionResult CadStatus()
        {
            return View();
        }

        public ActionResult ConfCadStatus(FormCollection frm)
        {
            model.status = frm["txtNmStatus"];
            atos.inserirStatus(model);

            return View();
        }

        public ActionResult AtAutor()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AtAutor(FormCollection frm, string btn)
        {
            modelo.codAutor = frm["txtCodAutor"];

            if(btn == "Buscar")
            {
                acoes.buscarAutor(modelo);

                ViewBag.cod = modelo.codAutor;
                ViewBag.nome = modelo.nomeAutor;
                ViewBag.sta = modelo.status;

                return View();
            }
            else if (btn == "Atualizar")
            {
                modelo.nomeAutor = frm["txtNmAutor"];
                modelo.status = frm["txtSta"];

                acoes.atualizarAutor(modelo);

                ViewBag.msg = "Autor atualizado com sucesso";

                return View();
            }
            else if (btn == "Excluir")
            {
                acoes.excluirAutor(modelo);

                ViewBag.msg = "Autor excluido com sucesso";

                return View();
            }
            else 
            { 
                return View(); 
            }
        }
        
        public ActionResult AtStatus()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AtStatus(FormCollection frm, string btn)
        {
            model.codStatus = frm["txtCodStatus"];

            if(btn == "Buscar")
            {
                atos.buscarStatus(model);

                ViewBag.cod = model.codStatus;
                ViewBag.nome = model.status;

                return View();
            }
            else if (btn == "Atualizar")
            {
                model.status = frm["txtNmStatus"];

                atos.atualizarStatus(model);

                ViewBag.msg = "Status atualizado com sucesso!";

                return View();
            }
            else if (btn == "Excluir")
            {
                atos.excluirStatus(model);

                ViewBag.msg = "Status excluído com sucesso!";

                return View();
            }
            else 
            { 
                return View(); 
            }
        }

    }
}