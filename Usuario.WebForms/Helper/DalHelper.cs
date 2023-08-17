using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Usuario.WebForms.Model;

namespace Usuario.WebForms.Helper
{
    public class DalHelper : IDisposable
    {
        private static SqlConnection sqlConnection;        
        public DalHelper()
        { }

        private static SqlConnection DbConnection()
        {
            sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["conexao"].ToString();
            sqlConnection.Open();
            return sqlConnection;
        }
        
        public static DataTable GetAllUsuarios()
        {
            SqlDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = @"SELECT 
                                            Id 
                                            , Nome
                                            , Email 
                                            , Telefone
                                            , NomeMae
                                            , NomePai
                                            , Documento
                                            , DataNascimento 
                                        FROM 
                                            Usuarios WITH (NOLOCK)";
                    da = new SqlDataAdapter(cmd.CommandText, DbConnection());
                    da.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void Add(Usuarios usuario)
        {
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO Usuarios 
                                            (Nome
                                            , Email
                                            , Telefone
                                            , NomeMae
                                            , NomePai
                                            , Documento
                                            , DataNascimento) 
                                        VALUES 
                                            (@Nome 
                                            , @Email
                                            , @Telefone
                                            , @NomeMae
                                            , @NomePai
                                            , @Documento
                                            , @DataNascimento)";
                    cmd.Parameters.AddWithValue("@Nome", usuario.Nome);
                    cmd.Parameters.AddWithValue("@Email", usuario.Email);
                    cmd.Parameters.AddWithValue("@Telefone", usuario.Telefone);
                    cmd.Parameters.AddWithValue("@NomeMae", usuario.NomeMae);
                    cmd.Parameters.AddWithValue("@NomePai", usuario.NomePai);
                    cmd.Parameters.AddWithValue("@Documento", usuario.Documento);
                    cmd.Parameters.AddWithValue("@DataNascimento", usuario.DataNascimento);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void Update(Usuarios usuario)
        {
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    if (usuario != null)
                    {
                        cmd.CommandText = @"UPDATE 
                                                Usuarios 
                                            SET 
                                                Nome = @Nome
                                                , Email = @Email
                                                , Telefone = @Telefone
                                                , NomeMae = @NomeMae
                                                , NomePai = @NomePai
                                                , Documento = @Documento
                                                , DataNascimento = @DataNascimento 
                                            WHERE 
                                                Id = @Id";
                        cmd.Parameters.AddWithValue("@Nome", usuario.Nome);
                        cmd.Parameters.AddWithValue("@Email", usuario.Email);
                        cmd.Parameters.AddWithValue("@Telefone", usuario.Telefone);
                        cmd.Parameters.AddWithValue("@NomeMae", usuario.NomeMae);
                        cmd.Parameters.AddWithValue("@NomePai", usuario.NomePai);
                        cmd.Parameters.AddWithValue("@Documento", usuario.Documento);
                        cmd.Parameters.AddWithValue("@DataNascimento", usuario.DataNascimento);
                        cmd.Parameters.AddWithValue("@Id", usuario.Id);

                        cmd.ExecuteNonQuery();
                    }
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void Delete(int id)
        {
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = @"DELETE FROM 
                                            Usuarios 
                                        WHERE 
                                            Id = @Id";
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}