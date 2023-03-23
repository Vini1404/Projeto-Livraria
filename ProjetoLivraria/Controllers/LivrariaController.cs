using MySql.Data.MySqlClient;
using ProjetoLivraria.Dados;
using ProjetoLivraria.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjetoLivraria.Controllers
{
    public class LivrariaController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public void CarregaAutores()
        {
            List<SelectListItem> autores = new List<SelectListItem>();

            using (MySqlConnection con = new MySqlConnection("Server=localhost; Database=bdlivraria8_3; User=root; pwd=12345678"))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from tbAutor where sta=1", con);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    autores.Add(new SelectListItem
                    {
                        Text = rdr[1].ToString(),
                        Value = rdr[0].ToString()
                    });
                }
                con.Close();
            }

            ViewBag.autores = new SelectList(autores, "Value", "Text");
        }

        public ActionResult CadLivro() 
        { 
            CarregaAutores();
            return View();
        }

        AcLivro ac = new AcLivro();
        ModLivro mod = new ModLivro();

        public ActionResult ConfCadLivro(FormCollection frm)
        {
            mod.nomeLivro = frm["txtNmLIvro"]; 
            mod.codAutor = Request["autores"];
            ac.inserirLivro(mod);
            return View();
        }
        public void CarregaLivros()
        {
            List<SelectListItem> livros = new List<SelectListItem>();

            using (MySqlConnection con = new MySqlConnection("Server=localhost; Database=bdlivraria8_3; User=root; pwd=12345678"))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select tbLivro.codLivro,tbLivro.nomeLivro, tbAutor.nomeAutor from tbLivro inner join tbAutor on tbLivro.codAutor = tbAutor.codAutor;", con);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    livros.Add(new SelectListItem
                    {
                        Text = rdr[1].ToString(),
                        Value = rdr[0].ToString()
                    });
                }
                con.Close();
            }

            ViewBag.autores = new SelectList(livros, "Value", "Text");
        }

        public ActionResult SelLivro()
        {
            CarregaLivros();
            return View();
        }

        public ActionResult consLivro() 
        {
            GridView gvAtend = new GridView();
            gvAtend.DataSource = ac.selecionaLivro();
            gvAtend.DataBind();
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw  = new HtmlTextWriter(sw);
            gvAtend.RenderControl(htw);
            ViewBag.GridViewString = sw.ToString();
            return View();
        }

        public ActionResult ListarLivro() 
        {
            return View(ac.mostrarLivro());
        }
    }
}