using Dapper;
using FacilityBox.Model;
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
    public class CategoryService
    {
        public static SqlTransaction CurrentTransaction { get; set; }

        public CategoryService()
        {
            //
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

        public int CreateCategory(Category category)
        {

            using (SqlConnection cn = new SqlConnection(Utils.ConnectionString))
            {
                var id = cn.ExecuteScalar<int>("Facility_Category_Create",
                param: new
                {
                   Name = category.Name,
                   Inactive = category.Inactive
                },
                transaction: CurrentTransaction,
                commandType: CommandType.StoredProcedure);

                return id;
            }
        }

        public List<Category> GetAllCategories()
        {

            using (SqlConnection cn = new SqlConnection(Utils.ConnectionString))
            {
                var list = cn.Query<Category>("Facility_Category_GetAllCategories",
                transaction: CurrentTransaction,
                commandType: CommandType.StoredProcedure);

                return list.ToList();
            }
        }
    }
}
