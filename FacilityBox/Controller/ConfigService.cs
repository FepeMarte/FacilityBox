using FacilityBox.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using FacilityBox.Model.Helpers;

namespace FacilityBox.Controller
{
    public class ConfigService
    {
        public static SqlTransaction CurrentTransaction { get; set; }
        public ConfigService()
        {
            //
        }

        public static Config GetConfigByID(int id)
        {

            using (SqlConnection cn = new SqlConnection(Utils.ConnectionString))
            {
                var config = cn.Query<Config>("Facility_Config_GetConfigByID",
                param: new
                {
                    ConfigID = id
                },
                transaction: CurrentTransaction,
                commandType: CommandType.StoredProcedure).FirstOrDefault();

                return config;
            }
        }

        public int UpdateConfig(Config config)
        {

            using (SqlConnection cn = new SqlConnection(Utils.ConnectionString))
            {
                var id = cn.ExecuteScalar<int>("Facility_Config_UpdateConfig",
                param: new
                {
                    PrimaryColor = config.PrimaryColor,
                    SecondaryColor = config.SecondaryColor
                },
                transaction: CurrentTransaction,
                commandType: CommandType.StoredProcedure);

                return id;
            }
        }

        public int GetMaxID()
        {

            using (SqlConnection cn = new SqlConnection(Utils.ConnectionString))
            {
                var id = cn.ExecuteScalar<int>("Facility_Category_GetMaxID",
                transaction: CurrentTransaction,
                commandType: CommandType.StoredProcedure);

                return id;
            }
        }
    }
}
