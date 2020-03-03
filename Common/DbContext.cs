using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResshaDataBaseTools.Common
{
    /// =======================================================================
    /// クラス名 ： DbContext
    /// <summary>
    /// データベース接続管理クラス
    /// </summary>
    /// <remarks>
    /// □統合データベースへの接続を担うクラスである。
    /// □本クラスには以下のメソッドが存在する。
    ///     □TryConnection
    ///         □データベース接続確認
    ///     □SelectSqlCmd
    ///         □参照コマンド実効
    ///     □UpdateSqlCmd
    ///         □更新コマンド実効
    /// </remarks>
    /// <history>
    /// =======================================================================
    /// 更新履歴
    /// 項番　　　更新日付　　担当者　　更新内容
    /// 0001　　　2020/03/01  鶴　見    新規作成     
    /// =======================================================================
    /// </history>
    public class DbContext
    {
        #region グローバル変数
        /// <summary>トレースロガー</summary>
        private readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        /// <summary>SQL接続用インスタンス</summary>
        private static SqlConnection connection;

        #endregion

        #region メソッド

        #region データベース接続確認
        /// =======================================================================
        /// メソッド名 ： TryConnection
        /// <summary>
        /// データベース接続確認
        /// </summary>
        /// <remarks>
        /// □ユーザ入力統合DB接続情報を用いた接続の確認
        /// </remarks>
        /// <param name="cmd">データベース接続コマンド</param>
        /// <returns>データベース接続成否</returns>
        /// <history>
        /// =======================================================================
        /// 更新履歴
        /// 項番　　　更新日付　　担当者　　更新内容
        /// 0001　　　2020/03/01  鶴　見    新規作成     
        /// =======================================================================
        /// </history>
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
                logger.Error(ex);
                // 戻り値返却
                return false;
            }
        }

        #endregion

        #endregion
    }
}
