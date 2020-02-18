using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResshaDataBaseTools.Common
{
    public class DbContext
    {
        /// <summary>
        /// トレースロガー
        /// </summary>
        private readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// SQL接続用インスタンス
        /// </summary>
        private static SqlConnection connection;

        /// <summary>
        /// データベース接続処理
        /// </summary>
        /// <param name="cmd">データベース接続コマンド</param>
        /// <returns>データベース接続成否</returns>
        public bool TryConnection(string cmd)
        {
            // 例外検知
            try
            {
                // 接続情報設定
                connection = new SqlConnection(cmd);
                // 接続開始
                connection.Open();
                // 接続終了
                connection.Close();
                // 戻り値返却
                return true;
            }
            // 例外検知時
            catch (Exception ex)
            {
                // エラートレースログ出力
                _logger.Error(ex);
                // 戻り値返却
                return false;
            }
        }
    }
}
