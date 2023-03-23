using MySql.Data.MySqlClient;
using ProjetoLivraria.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;

namespace ProjetoLivraria.Dados
{
    public class AcLivro
    {
        Conexao Con = new Conexao();
        
        public void inserirLivro(ModLivro cm)
        {
            MySqlCommand cmd = new MySqlCommand("insert into tbLivro(nomeLivro,codAutor) values(@nomeLivro, @codAutor)", Con.ConectarBD());
            cmd.Parameters.Add("@nomeLivro", MySqlDbType.VarChar).Value = cm.nomeLivro;
            cmd.Parameters.Add("@codAutor", MySqlDbType.VarChar).Value = cm.codAutor;

            cmd.ExecuteNonQuery();
            Con.ConectarBD();
        }


        public List<ModLivro> mostrarLivro()
        {
            List<ModLivro> listalivros = new List<ModLivro>();
            MySqlCommand cmd = new MySqlCommand("select tbLivro.codLivro, tbLivro.nomeLivro,tbAutor.nomeAutor from tbLivro inner join tbAutor on tbLivro.codAutor = tbAutor.codAutor;", Con.ConectarBD());

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            da.Fill(dt);
            Con.DesconectarBD();

            foreach(DataRow dr in dt.Rows)
            {
                listalivros.Add(new ModLivro
                {
                    codLivro = Convert.ToString(dr["codLivro"]),
                    nomeLivro = Convert.ToString(dr["nomeLivro"]),
                   /* codAutor = Convert.ToString(dr["codAutor"]),*/
                    nomeAutor = Convert.ToString(dr["nomeAutor"])
                }
                );
            }
            return listalivros;
        }

        public DataTable selecionaLivro()
        {
            MySqlCommand cmd = new MySqlCommand("select tbLivro.codLivro,tbLivro.nomeLivro, tbAutor.nomeAutor from tbLivro inner join tbAutor on tbLivro.codAutor = tbAutor.codAutor;", Con.ConectarBD());
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable atend = new DataTable();
            da.Fill(atend);
            Con.DesconectarBD();
            return atend;
        }
    }
}