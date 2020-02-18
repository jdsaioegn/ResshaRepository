using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResshaDataBaseTools.Common
{
    /// <summary>
    /// データベース接続用文字列クラス
    /// </summary>
    public class DatabaseConnectionCommand
    {
        /// <summary>
        /// 接続用文字列（Windows認証）
        /// </summary>
        public static string CONNECTION_WINDOWS_AUTHENTICATION = "Data Source={0}; Initial Catalog={1}; Integrated Security=True;";

        /// <summary>
        /// 接続用文字列（SQL Server認証）
        /// </summary>
        public static string CONNECTION_SQL_AUTHENTICATION = "Data Source={0}; Initial Catalog={1}; User ID={2}; Password={3};";
    }
}
