using ResshaDataBaseTools.Common;
using ResshaDataBaseTools.Common.Model;
using System.Collections.Generic;
using System.Linq;

namespace ResshaDataBaseTools
{
    /// =======================================================================
    /// クラス名 ： FormBase
    /// <summary>
    /// 試験用統合DB編集ツール各画面継承元Formクラス
    /// </summary>
    /// <remarks>
    /// □試験用統合DB編集ツールの各画面が継承する共通クラスである。
    /// □本クラスには以下のメソッドが存在する。
    ///     □GetMasterValue
    ///         □マスタレコード抽出
    ///     □GetEigyoDictionary
    ///         □営業種別抽出
    /// </remarks>
    /// <history>
    /// =======================================================================
    /// 更新履歴
    /// 項番　　　更新日付　　担当者　　更新内容
    /// 0001　　　2020/03/01  鶴　見    新規作成     
    /// =======================================================================
    /// </history>
    public class FormBase : System.Windows.Forms.Form
    {
        #region グローバル変数
        /// <summary>トレースロガー</summary>
        protected readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        /// <summary>DB接続管理クラス</summary>
        protected DbContext _DbContext = new DbContext();
        /// <summary>汎用処理クラス</summary>
        protected Utility _Utility = new Utility();
        /// <summary>対象日付</summary>
        private protected static string TARGET_DATE;
        /// <summary>実施列車レコード</summary>
        private protected static List<ResshaRecordModel> RESSHA_RECORD;
        /// <summary>マスタレコード</summary>
        private protected static List<MasterRecordModel> MASTER_RECORD;
        /// <summary>列車営業レコード</summary>
        private protected static List<EigyoRecordModel> EIGYO_RECORD;
        /// <summary>列車運用レコード</summary>
        private protected static List<UnyoRecordModel> UNYO_RECORD;

        #endregion

        #region メソッド

        #region マスタレコード抽出
        /// =======================================================================
        /// メソッド名 ： GetMasterValue
        /// <summary>
        /// マスタレコード抽出
        /// </summary>
        /// <remarks>
        /// □引数で指定された種別コードと名称コードから対象名称を抽出する。
        /// </remarks>
        /// <param name="shubetsuCd">種別コード</param>
        /// <param name="meishoCd">名称コード</param>
        /// <returns>3文字名称</returns>
        /// <history>
        /// =======================================================================
        /// 更新履歴
        /// 項番　　　更新日付　　担当者　　更新内容
        /// 0001　　　2020/03/01  鶴　見    新規作成     
        /// =======================================================================
        /// </history>
        private protected string GetMasterValue(string shubetsuCd, string meishoCd)
        {
            // 指定した種別コードと名称コードに該当するマスタ値を返却
            return MASTER_RECORD.Where(p => p.ShubetsuCd == shubetsuCd)
                                .Where(p => p.MeishoCd == meishoCd)
                                .First()
                                .SanMojiMeisho;
        }

        #endregion

        #region 営業種別抽出
        /// =======================================================================
        /// メソッド名 ： GetEigyoDictionary
        /// <summary>
        /// 営業種別抽出
        /// </summary>
        /// <remarks>
        /// □引数で取得した列車番号に関連する営業種別を全て返却する。
        /// </remarks>
        /// <param name="resshaNo">列車番号</param>
        /// <returns>営業種別</returns>
        /// <history>
        /// =======================================================================
        /// 更新履歴
        /// 項番　　　更新日付　　担当者　　更新内容
        /// 0001　　　2020/03/01  鶴　見    新規作成     
        /// =======================================================================
        /// </history>
        private protected List<Dictionary<string, string>> GetEigyoDictionary(string resshaNo)
        {
            // 返却用営業種別連想配列生成
            List<Dictionary<string, string>> dictionary = new List<Dictionary<string, string>>();

            // 営業種別レコードデータから対象列車番号に関連するレコードのみ抽出
            List<EigyoRecordModel> EIGYO_RECORD_DETAIL = EIGYO_RECORD.Where(p => p.ResshaNo == resshaNo)
                                                                     .ToList();

            // 関連レコードのうち主編成の営業種別のみを抽出
            dictionary.Add(EIGYO_RECORD_DETAIL.Where(p => p.HenseiKbn == 1).ToDictionary(p => p.HenkoFromEkiCd, p => p.EigyoShubetsuCd));

            // 関連レコード内に従編成が存在しない場合は本処理を終了する。
            if (EIGYO_RECORD_DETAIL.Where(p => p.HenseiKbn == 2).Count() == 0)
            {
                // 終了
                return dictionary;
            }
            // 関連レコードのうち従編成の営業種別のみを抽出
            dictionary.Add(EIGYO_RECORD_DETAIL.Where(p => p.HenseiKbn == 2).ToDictionary(p => p.HenkoFromEkiCd, p => p.EigyoShubetsuCd));

            // 関連レコード内に従編成②が存在しない場合は本処理を終了する。
            if (EIGYO_RECORD_DETAIL.Where(p => p.HenseiKbn == 3).Count() == 0)
            {
                // 終了
                return dictionary;
            }
            // 関連レコードのうち従編成②の営業種別のみを抽出
            dictionary.Add(EIGYO_RECORD_DETAIL.Where(p => p.HenseiKbn == 3).ToDictionary(p => p.HenkoFromEkiCd, p => p.EigyoShubetsuCd));

            // 終了
            return dictionary;
        }

        #endregion

        #endregion
    }
}
