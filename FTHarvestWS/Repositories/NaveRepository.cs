using Microsoft.Extensions.Configuration;
using RendimientoPlantaWS.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace FTHarvestWS.Repositories
{
    public class NaveRepository
    {
        private readonly string _connectionString;

        public NaveRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("defaultConnection");
        }

        public async Task Insert(IEnumerable<Nave> jsonNaves)
        {
            foreach (Nave value in jsonNaves)
            {
                using (SqlConnection sql = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("PR_UPD_NAVE_INVENTARIO", sql))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@P_CODIGOBARRA", value.codigo));
                        cmd.Parameters.Add(new SqlParameter("@P_BOLETA", value.boleta));
                        cmd.Parameters.Add(new SqlParameter("@P_INVERNADERO", value.invernadero));
                        cmd.Parameters.Add(new SqlParameter("@P_CUADRILLA", value.cuadrilla));
                        cmd.Parameters.Add(new SqlParameter("@P_PlantaID", value.planta));
                        cmd.Parameters.Add(new SqlParameter("@P_BodegaID", value.bodega));
                        cmd.Parameters.Add(new SqlParameter("@P_EmpleadoID", value.empleado));
                        cmd.Parameters.Add(new SqlParameter("@P_Calidad", value.calidad));
                        cmd.Parameters.Add(new SqlParameter("@P_OP", value.op));
                        cmd.Parameters.Add(new SqlParameter("@P_NAVE", value.nave));
                        await sql.OpenAsync();
                        await cmd.ExecuteNonQueryAsync();
                    }
                }
            }
        }


        public async Task InsertV2(IEnumerable<NaveV2> jsonNaves)
        {
            foreach (NaveV2 value in jsonNaves)
            {
                using (SqlConnection sql = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("PR_UPD_NAVE_INVENTARIO_V2", sql))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@P_CODIGOBARRA", value.codigo));
                        cmd.Parameters.Add(new SqlParameter("@P_BOLETA", value.boleta));
                        cmd.Parameters.Add(new SqlParameter("@P_INVERNADERO", value.invernadero));
                        cmd.Parameters.Add(new SqlParameter("@P_CUADRILLA", value.cuadrilla));
                        cmd.Parameters.Add(new SqlParameter("@P_PlantaID", value.planta));
                        cmd.Parameters.Add(new SqlParameter("@P_BodegaID", value.bodega));
                        cmd.Parameters.Add(new SqlParameter("@P_EmpleadoID", value.empleado));
                        cmd.Parameters.Add(new SqlParameter("@P_Calidad", value.calidad));
                        cmd.Parameters.Add(new SqlParameter("@P_OP", value.op));
                        cmd.Parameters.Add(new SqlParameter("@P_NAVE", value.nave));
                        cmd.Parameters.Add(new SqlParameter("@P_SEMANA_PROGRAMADA", value.semana));
                        cmd.Parameters.Add(new SqlParameter("@P_LOTE", value.lote));
                        await sql.OpenAsync();
                        await cmd.ExecuteNonQueryAsync();
                    }
                }
            }
        }
    }
}
