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
    /// □データベース接続コマンドのテンプレート文字列用のクラスである。
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

    /// =======================================================================
    /// クラス名 ： SqlCommandTemplate
    /// <summary>
    /// SQLコマンド文字列テンプレートクラス
    /// </summary>
    /// <remarks>
    /// □SQLコマンドのテンプレート文字列用のクラスである。
    /// </remarks>
    /// <history>
    /// =======================================================================
    /// 更新履歴
    /// 項番　　　更新日付　　担当者　　更新内容
    /// 0001　　　2020/03/01  鶴　見    新規作成     
    /// =======================================================================
    /// </history>
    public class SqlCommandTemplate
    {
        /// <summary>マスタレコード取得コマンド</summary>
        public static string SELECT_MASTER_RECORD = "SELECT * FROM TYJM0101 WHERE {0} > FromDate AND ToDate > {0};";

        /// <summary>列車営業レコード取得コマンド</summary>
        public static string SELECT_EIGYO_RECORD = "SELECT * FROM TKRT4204 WHERE ResshaSekoDate = {0};";

        /// <summary>列車運用レコード取得コマンド</summary>
        public static string SELECT_UNYO_RECORD = "SELECT * FROM TKAT4105 WHERE {0} < ResshaSekoDate AND ResshaSekoDate < {1};";

        /// <summary>実施列車レコード取得コマンド</summary>
        public static string SELECT_RESSHA_RECORD = "SELECT TKRT4101.ResshaNo, " +
                                                           "TKRT4101.KyukatsuCd, " +
                                                           "TKRT4101.SenkuCd, " +
                                                           "TKRT4101.JogeCd, " +
                                                           "TKRT4101.ShihatsuEkiCd, " +
                                                           "TKRT4101.ShuchakuEkiCd, " +
                                                           "TKRT4101.TojitsuSenkuCd, " +
                                                           "TKRT4101.AshiResshaKbn, " +
                                                           "TKRT4101.SokoJotai, " +
                                                           "TKRT4101.DiagramKanriDate, " +
                                                           "TKRT4105.EkiCd, " +
                                                           "TKRT4105.ChakuKyukatsuCd, " +
                                                           "TKRT4105.HatsuKyukatsuCd, " +
                                                           "TKRT4105.EkiTsukaTeishaCd, " +
                                                           "TKRT4105.JisshiChakuSotaiDate, " +
                                                           "TKRT4105.JisshiChakuTime, " +
                                                           "TKRT4105.JisshiHatsuSotaiDate, " +
                                                           "TKRT4105.JisshiHatsuTime, " +
                                                           "TKRT4105.JissekiChakuSotaiDate, " +
                                                           "TKRT4105.JissekiChakuTime, " +
                                                           "TKRT4105.JissekiHatsuSotaiDate, " +
                                                           "TKRT4105.JissekiHatsuTime, " +
                                                           "TKRT4105.SokoJunjo, " +
                                                           "TKRT4104.ResshaNo AS KeisoResshaNo, " +
                                                           "TKRT4108.HeigoResshaNo, " +
                                                           "TKAT4105_1.SekoDate AS ShuhenseiSekoDate, " +
                                                           "TKAT4105_1.SharyoUnyoNo AS ShuhenseiSharyoUnyoNo, " +
                                                           "TKAT4105_1.AshiResshaJunjo AS ShuhenseiAshiResshaJunjo, " +
                                                           "TKAT4105_1.ShihatsuEkiCd AS ShuhenseiShihatsuEkiCd, " +
                                                           "TKAT4105_1.ShuchakuEkiCd AS ShuhenseiShuchakuEkiCd, " +
                                                           "TKAT4105_2.SekoDate AS JuhenseiSekoDate, " +
                                                           "TKAT4105_2.SharyoUnyoNo AS JuhenseiSharyoUnyoNo, " +
                                                           "TKAT4105_2.AshiResshaJunjo AS JuhenseiAshiResshaJunjo, " +
                                                           "TKAT4105_2.ShihatsuEkiCd AS JuhenseiShihatsuEkiCd, " +
                                                           "TKAT4105_2.ShuchakuEkiCd AS JuhenseiShuchakuEkiCd, " +
                                                           "TKAT4105_3.SekoDate AS Juhensei2SekoDate, " +
                                                           "TKAT4105_3.SharyoUnyoNo AS Juhensei2SharyoUnyoNo, " +
                                                           "TKAT4105_3.AshiResshaJunjo AS Juhensei2AshiResshaJunjo, " +
                                                           "TKAT4105_3.ShihatsuEkiCd AS Juhensei2ShihatsuEkiCd, " +
                                                           "TKAT4105_3.ShuchakuEkiCd AS Juhensei2ShuchakuEkiCd " +
                                                           "FROM TKRT4101 AS TKRT4101 " +
                                                           "INNER JOIN TKRT4105 AS TKRT4105 ON TKRT4101.ResshaNo = TKRT4105.ResshaNo AND TKRT4101.ResshaSekoDate = TKRT4105.ResshaSekoDate " +
                                                           "LEFT JOIN TKRT4104 TKRT4104 ON TKRT4101.ResshaNo = TKRT4104.KeisoSakiResshaNo AND TKRT4101.ResshaSekoDate = TKRT4104.ResshaSekoDate " +
                                                           "LEFT JOIN TKRT4108 TKRT4108 ON TKRT4101.ResshaNo = TKRT4108.ResshaNo AND TKRT4101.ResshaSekoDate = TKRT4108.ResshaSekoDate " +
                                                           "LEFT JOIN TKAT4105 AS TKAT4105_1 ON TKRT4101.ResshaNo = TKAT4105_1.ResshaNo AND TKRT4101.ResshaSekoDate = TKAT4105_1.ResshaSekoDate AND TKAT4105_1.HenseiKbn = 1 and TKAT4105_1.SharyoUnyoNo IN (SELECT TKAT4101.SharyoUnyoNo FROM TKAT4101 AS TKAT4101 WHERE TKAT4105_1.SekoDate = TKAT4101.SekoDate AND TKAT4101.KyukatsuCd = 0) " +
                                                           "LEFT JOIN TKAT4105 AS TKAT4105_2 ON TKRT4101.ResshaNo = TKAT4105_2.ResshaNo AND TKRT4101.ResshaSekoDate = TKAT4105_2.ResshaSekoDate AND TKAT4105_2.HenseiKbn = 2 and TKAT4105_2.SharyoUnyoNo IN (SELECT TKAT4101.SharyoUnyoNo FROM TKAT4101 AS TKAT4101 WHERE TKAT4105_2.SekoDate = TKAT4101.SekoDate AND TKAT4101.KyukatsuCd = 0) " +
                                                           "LEFT JOIN TKAT4105 AS TKAT4105_3 ON TKRT4101.ResshaNo = TKAT4105_3.ResshaNo AND TKRT4101.ResshaSekoDate = TKAT4105_3.ResshaSekoDate AND TKAT4105_3.HenseiKbn = 3 and TKAT4105_3.SharyoUnyoNo IN (SELECT TKAT4101.SharyoUnyoNo FROM TKAT4101 AS TKAT4101 WHERE TKAT4105_3.SekoDate = TKAT4101.SekoDate AND TKAT4101.KyukatsuCd = 0) " +
                                                           "WHERE TKRT4101.ResshaSekoDate = {0}";

        /// <summary></summary>
        public static string UPDATE_TKRT4101 = "UPDATE TKRT4101 SET {1} = {2} WHERE ResshaSekoDate = {0};";

        public static string UPDATE_TKRT4105 = "UPDATE TKRT4105 SET {1} = {2} WHERE ResshaSekoDate = {0};";

        /// <summary></summary>
        public static string CASE_END = "CASE {0} {1} END";

        /// <summary></summary>
        public static string WHEN_THEN = "WHEN {0} THEN {1} ";
    }

    /// =======================================================================
    /// クラス名 ： ConstCodes
    /// <summary>
    /// 実施列車関連テーブル各種コード設定値まとめクラス
    /// </summary>
    /// <remarks>
    /// □実施列車を参照する際の各コードが表す内容をまとめたクラスである。
    /// </remarks>
    /// <history>
    /// =======================================================================
    /// 更新履歴
    /// 項番　　　更新日付　　担当者　　更新内容
    /// 0001　　　2020/03/01  鶴　見    新規作成     
    /// =======================================================================
    /// </history>
    public class ConstCode
    {
        /// <summary>マスタレコード名称種別の「駅コード」を表すコード</summary>
        public const string SHUBETSUCD_EKI = "001";
        /// <summary>マスタレコード名称種別の「営業種別コード」を表すコード</summary>
        public const string SHUBETSUCD_EIGYO = "030";
        /// <summary>実施列車レコードの上下コード「上り」を表すコード</summary>
        public const string JOGECD_NOBORI = "01";
        /// <summary>実施列車レコードの上下コード「下り」を表すコード</summary>
        public const string JOGECD_KUDARI = "02";
        /// <summary>実施列車レコードの休活コード「活」を表すコード</summary>
        public const string KYUKATSUCD_KATSU = "0";
        /// <summary>実施列車レコードの休活コード「休」を表すコード</summary>
        public const string KYUKATSUCD_KYU = "1";
        /// <summary>実施列車レコードの走行状態「未走行」を表すコード</summary>
        public const string SOKOJOTAICD_MAE = "0";
        /// <summary>実施列車レコードの走行状態「走行中」を表すコード</summary>
        public const string SOKOJOTAICD_CHU = "1";
        /// <summary>実施列車レコードの走行状態「走行済」を表すコード</summary>
        public const string SOKOJOTAICD_ATO = "2";
    }
}
