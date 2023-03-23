using MySql.Data.MySqlClient;
using ProjetoLivraria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoLivraria.Dados
{
    public class AcStatus
    {
        Conexao Con = new Conexao();

        MySqlDataReader dr;

        public void inserirStatus(ModStatus cm)
        {
            MySqlCommand cmd = new MySqlCommand("insert into tbStatus(sta) values(@status)", Con.ConectarBD());
            cmd.Parameters.Add("@status", MySqlDbType.VarChar).Value = cm.status;

            cmd.ExecuteNonQuery();
            Con.ConectarBD();
        }

        public void buscarStatus(ModStatus cm)
        {
            MySqlCommand cmd = new MySqlCommand("select * from tbStatus where codStatus=@codSta", Con.ConectarBD());
            cmd.Parameters.AddWithValue("@codSta", cm.codStatus);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                cm.status = dr[1].ToString();
            }

            Con.DesconectarBD();
        }

        public void atualizarStatus(ModStatus cm)
        {
            MySqlCommand cmd = new MySqlCommand("update tbStatus set sta=@status where codStatus=@codSta", Con.ConectarBD());

            cmd.Parameters.Add("@codSta", MySqlDbType.VarChar).Value = cm.codStatus;
            cmd.Parameters.Add("@status", MySqlDbType.VarChar).Value = cm.status;

            cmd.ExecuteNonQuery();
            Con.DesconectarBD();
        }

        public void excluirStatus(ModStatus cm)
        {
            MySqlCommand cmd = new MySqlCommand("delete from tbStatus where codStatus=@codSta", Con.ConectarBD());

            cmd.Parameters.Add("@codSta", MySqlDbType.VarChar).Value = cm.codStatus;
            cmd.ExecuteNonQuery();
            Con.DesconectarBD();
        }
    }
}