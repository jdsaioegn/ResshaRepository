using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResshaDataBaseTools.Common
{
    /// =======================================================================
    /// クラス名 ： DatabaseConnectionCommandTemplate
    /// <summary>
    /// データベース接続用コマンド文字列テンプレートクラス
    /// </summary>
    /// <remarks>
    /// □データベース接続コマンドのテンプレート文字列を管理するクラスである。
    /// </remarks>
    /// <history>
    /// =======================================================================
    /// 更新履歴
    /// 項番　　　更新日付　　担当者　　更新内容
    /// 0001　　　2020/03/01  鶴　見    新規作成     
    /// =======================================================================
    /// </history>
    public class DatabaseConnectionCommandTemplate
    {
        /// <summary>接続用文字列（Windows認証）</summary>
        public static string CONNECTION_WINDOWS_AUTHENTICATION = "Data Source={0}; Initial Catalog={1}; Integrated Security=True;";

        /// <summary>接続用文字列（SQL Server認証）</summary>
        public static string CONNECTION_SQL_AUTHENTICATION = "Data Source={0}; Initial Catalog={1}; User ID={2}; Password={3};";
    }
}
