using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Curso.Domain.Entities;
using Curso.Repository.Interfaces;
using MySql.Data.MySqlClient;

namespace Curso.Repository.Repository
{
    public class VeiculoRepository : Repository, IVeiculoRepository
    {
        public bool Delete(long id)
        {
            throw new NotImplementedException();
        }

        public Veiculo Get(long id)
        {
            throw new NotImplementedException();
        }

        public Veiculo Insert(Veiculo veiculo)
        {
            try
            {
                string sqlInsert = $"insert into veiculo(marca, modelo, placa, cor,  ano, tipo)values('{veiculo.marca}', '{veiculo.modelo}', '{veiculo.placa}', '{veiculo.cor}', '{veiculo.ano}', '{veiculo.tipo}'); SELECT LAST_INSERT_ID()";
                using (MySqlConnection mySqlConnection = new MySqlConnection(_mySQLConnectionString))
                {
                    using (MySqlCommand command = new MySqlCommand(sqlInsert, mySqlConnection))
                    {
                        mySqlConnection.Open();
                        command.ExecuteNonQuery();
                        veiculo.id = command.LastInsertedId;
                        mySqlConnection.Close();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

            return veiculo;
        }

        public List<Veiculo> List()
        {
            List<Veiculo> listTipos = new List<Veiculo>();
            try
            {
                string sqlList = "SELECT * FROM veiculo ORDER BY id";
                using (MySqlConnection mySqlConnection = new MySqlConnection(_mySQLConnectionString))
                {
                    using (MySqlCommand command = new MySqlCommand(sqlList, mySqlConnection))
                    {
                        mySqlConnection.Open();
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Veiculo veiculoDB = new Veiculo();
                                veiculoDB.id = reader.GetInt32("id");
                                veiculoDB.marca = reader.GetString("marca");
                                veiculoDB.modelo = reader.GetString("modelo");
                                veiculoDB.placa = reader.GetString("placa");
                                veiculoDB.ano = reader.GetInt32("ano");
                                veiculoDB.cor = reader.GetString("cor");
                                veiculoDB.tipo = reader.GetInt32("tipo");

                                listTipos.Add(veiculoDB);
                            }
                        }
                        mySqlConnection.Close();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return listTipos;
        }

        public Veiculo Update(Veiculo veiculo)
        {
            throw new NotImplementedException();
        }
    }
}
