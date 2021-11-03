﻿using Dapper;
using FacilityBox.Model.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacilityBox.Controller
{
  
    public class PlatformService
    {
        public static SqlTransaction CurrentTransaction { get; set; }

        public PlatformService()
        {
            //
        }

        public int GetMaxID()
        {

            using (SqlConnection cn = new SqlConnection(Utils.ConnectionString))
            {
                var id = cn.ExecuteScalar<int>("Facility_Platform_GetMaxID",
                transaction: CurrentTransaction,
                commandType: CommandType.StoredProcedure);

                return id;
            }
        }
    }

  
}
