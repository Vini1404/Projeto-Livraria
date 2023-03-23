using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoLivraria.Dados
{
    public class Conexao
    {
        MySqlConnection cn = new MySqlConnection("Server=localhost; Database=bdlivraria8_3; User=root; pwd=12345678");
        public static string msg;
        public MySqlConnection ConectarBD()
        {
            try
            {
                cn.Open();
            }
            catch(Exception erro)
            {
                msg = "ocorreu um erro ao se conectar" + erro.Message;
            }
            return cn;

        }
        public MySqlConnection DesconectarBD()
        {
            try
            {
                cn.Close();
            }
            catch(Exception erro)
            {
                msg = "ocorreu um erro ao se conectar" + erro.Message;
            }
            return cn;

        }
    }
}