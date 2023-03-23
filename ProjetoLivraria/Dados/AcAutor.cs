using MySql.Data.MySqlClient;
using ProjetoLivraria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoLivraria.Dados
{
    public class AcAutor
    {
        Conexao Con = new Conexao();

        MySqlDataReader dr;

        public void inserirAutor(ModAutor cm)
        {
            MySqlCommand cmd = new MySqlCommand("insert into tbAutor(nomeAutor,sta) values(@nomeAutor, @sta)", Con.ConectarBD());
            cmd.Parameters.Add("@nomeAutor", MySqlDbType.VarChar).Value = cm.nomeAutor;
            cmd.Parameters.Add("@sta", MySqlDbType.VarChar).Value = cm.status;

            cmd.ExecuteNonQuery();
            Con.ConectarBD();
        }

        public void buscarAutor(ModAutor cm)
        {
            MySqlCommand cmd = new MySqlCommand("select * from tbAutor where codAutor=@codAut", Con.ConectarBD());
            cmd.Parameters.AddWithValue("@codAut", cm.codAutor);
            dr = cmd.ExecuteReader();

            while (dr.Read()) 
            {
                cm.nomeAutor = dr[1].ToString();
                cm.status = dr[2].ToString();
            }

            Con.DesconectarBD();
        }

        public void atualizarAutor(ModAutor cm)
        {
            MySqlCommand cmd = new MySqlCommand("update tbAutor set nomeAutor=@nomeAutor, sta=@status where codAutor=@codAutor", Con.ConectarBD());
            
            cmd.Parameters.Add("@codAutor", MySqlDbType.VarChar).Value=cm.codAutor;
            cmd.Parameters.Add("@nomeAutor", MySqlDbType.VarChar).Value=cm.nomeAutor;
            cmd.Parameters.Add("@status", MySqlDbType.VarChar).Value=cm.status;

            cmd.ExecuteNonQuery();
            Con.DesconectarBD();
        }

        public void excluirAutor(ModAutor cm)
        {
            MySqlCommand cmd = new MySqlCommand("delete from tbAutor where codAutor=@cod", Con.ConectarBD());
            
            cmd.Parameters.Add("@cod", MySqlDbType.VarChar).Value=cm.codAutor;
            cmd.ExecuteNonQuery();
            Con.DesconectarBD();
        }
    }
}