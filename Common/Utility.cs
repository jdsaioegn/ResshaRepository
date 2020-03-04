using ResshaDataBaseTools.Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ResshaDataBaseTools.Common
{
    /// =======================================================================
    /// クラス名 ： Utility
    /// <summary>
    /// 汎用処理（メソッド）用クラス
    /// </summary>
    /// <remarks>
    /// □試験用統合DB編集ツールの機能間に共通して汎用的な処理を扱うクラス
    /// □本画面には以下のメソッドが存在する。
    ///     □GetTime
    ///         □相対日付と時刻値が表す秒数を返却
    ///     □DispTime
    ///         □相対日付と時刻値が表す秒数を表示用時刻として返却
    ///     □GetTimeForDispTime
    ///         □表示用時刻が表す秒数を返却
    ///     □GetTimeForChienDispTime
    ///         □表示用遅延時刻が表す秒数を返却
    ///     □GetDispEigyoShubetsu
    ///         □営業種別優先表示選択
    ///     □SingleQuotation
    ///         □SQLコマンド文字列設定用シングルクォーテーション付与
    ///     □WindowSizeAutoAdjustment
    ///         □ウィンドウサイズ自動調整
    /// </remarks>
    /// <history>
    /// =======================================================================
    /// 更新履歴
    /// 項番　　　更新日付　　担当者　　更新内容
    /// 0001　　　2020/03/01  鶴　見    新規作成     
    /// =======================================================================
    /// </history>
    public class Utility
    {
        #region メソッド

        #region 相対日付と時刻値が表す秒数を返却
        /// =======================================================================
        /// メソッド名 ： GetTime
        /// <summary>
        /// 相対日付と時刻値が表す秒数を返却
        /// </summary>
        /// <remarks>
        /// □相対日付と時刻値から換算した秒数の返却を行う。
        /// </remarks>
        /// <param name="sotai">相対日付</param>
        /// <param name="time"></param>
        /// <returns>秒数</returns>
        /// <history>
        /// =======================================================================
        /// 更新履歴
        /// 項番　　　更新日付　　担当者　　更新内容
        /// 0001　　　2020/03/01  鶴　見    新規作成     
        /// =======================================================================
        /// </history>
        public int GetTime(int sotai, int time)
        {
            // 無効値以外の場合
            if (sotai != 9)
            {
                // 終了
                return (86400 * sotai) + time;
            }

            // 終了
            return time;
        }

        #endregion

        #region 相対日付と時刻値が表す秒数を表示用時刻として返却
        /// =======================================================================
        /// メソッド名 ： DispTime
        /// <summary>
        /// 相対日付と時刻値が表す秒数を表示用時刻として返却
        /// </summary>
        /// <remarks>
        /// □相対日付と時刻値から換算した時刻をもとに表示用時刻の返却を行う。
        /// </remarks>
        /// <param name="sotai">相対日付</param>
        /// <param name="time"></param>
        /// <returns>表示用時刻</returns>
        /// <history>
        /// =======================================================================
        /// 更新履歴
        /// 項番　　　更新日付　　担当者　　更新内容
        /// 0001　　　2020/03/01  鶴　見    新規作成     
        /// =======================================================================
        /// </history>
        public string DispTime(int sotai, int time)
        {
            // 秒数を用いて時間型の文字列を生成
            string dispTime = new TimeSpan(0, 0, time).ToString();

            // 相対日付が「無効値」以外の場合
            if (sotai != 9)
            {
                // 相対日付分の時刻を加算した時間（hh）の取得
                int hour = int.Parse(dispTime.Split(':').First().ToString()) + sotai * 24;

                // 24時以降の表記を文字列を直接編集することで設定
                dispTime = hour.ToString() + dispTime.Substring(2);
            }

            // 終了
            return dispTime;
        }

        #endregion

        #region 表示用時刻が表す秒数を返却
        /// =======================================================================
        /// メソッド名 ： GetTimeForDispTime
        /// <summary>
        /// 表示用時刻が表す秒数を返却
        /// </summary>
        /// <param name="dispTime">表示用時刻</param>
        /// <returns>秒数</returns>
        /// <history>
        /// =======================================================================
        /// 更新履歴
        /// 項番　　　更新日付　　担当者　　更新内容
        /// 0001　　　2020/03/01  鶴　見    新規作成     
        /// =======================================================================
        /// </history>
        public int GetTimeForDispTime(string dispTime)
        {
            return
                // 「hh:mm:ss」の「hh」に該当する値を対象に、hh時間を秒数へ換算し加算
                (int.Parse(dispTime.Split(':').ElementAt(0).ToString()) * 3600) +
                // 「hh:mm:ss」の「mm」に該当する値を対象に、mm分を秒数へ換算し加算
                (int.Parse(dispTime.Split(':').ElementAt(1).ToString()) * 60) +
                // 「hh:mm:ss」の「ss」に該当する値を対象に、ss秒を加算
                (int.Parse(dispTime.Split(':').ElementAt(2).ToString()));
        }

        #endregion

        #region 表示用遅延時刻が表す秒数を返却
        /// =======================================================================
        /// メソッド名 ： GetTimeForChienDispTime
        /// <summary>
        /// 表示用遅延時刻が表す秒数を返却
        /// </summary>
        /// <param name="dispChienTime">表示用遅延時刻</param>
        /// <returns>秒数</returns>
        /// <history>
        /// =======================================================================
        /// 更新履歴
        /// 項番　　　更新日付　　担当者　　更新内容
        /// 0001　　　2020/03/01  鶴　見    新規作成     
        /// =======================================================================
        /// </history>
        public int GetTimeForChienDispTime(string dispChienTime)
        {
            return
                // 「hh:mm:ss」の「mm」に該当する値を対象に、mm分を秒数へ換算し加算
                (int.Parse(dispChienTime.Split(':').ElementAt(0).ToString()) * 60) +
                // 「hh:mm:ss」の「ss」に該当する値を対象に、ss秒を加算
                (int.Parse(dispChienTime.Split(':').ElementAt(1).ToString()));
        }

        #endregion

        #region 営業種別優先表示選択
        /// =======================================================================
        /// メソッド名 ： GetDispEigyoShubetsu
        /// <summary>
        /// 営業種別優先表示選択
        /// </summary>
        /// <remarks>
        /// □対象編成に複数の営業種別が存在する場合は、
        ///   営業種別の表示を行う際に回送級以外を優先的に表示する。
        /// </remarks>
        /// <param name="eigyo">対象編成営業種別情報</param>
        /// <returns>表示営業種別</returns>
        /// <history>
        /// =======================================================================
        /// 更新履歴
        /// 項番　　　更新日付　　担当者　　更新内容
        /// 0001　　　2020/03/01  鶴　見    新規作成     
        /// =======================================================================
        /// </history>
        public string GetDispEigyoShubetsu(Dictionary<string, string> eigyo)
        {
            // 回送級が存在しない場合
            if (eigyo.Where(p => p.Value == "32").Count() == 0)
            {
                // 回送級以外の営業種別を返却
                return eigyo.First().Value;
            }
            // 回送級が存在する場合 かつ 1種以上の営業種別が存在する場合
            else if (eigyo.Count() > 1)
            {
                // 回送級以外の営業種別を返却
                return eigyo.Where(p => p.Value != "32").First().Value;
            }

            // 回送級を返却
            return eigyo.First().Value;
        }

        #endregion

        #region SQLコマンド文字列設定用シングルクォーテーション付与
        /// =======================================================================
        /// メソッド名 ： SingleQuotation
        /// <summary>
        /// SQLコマンド文字列設定用シングルクォーテーション付与
        /// </summary>
        /// <remarks>
        /// □コマンドの生成を行う際に文字列の設定値として設定する。
        /// </remarks>
        /// <param name="str">対象文字列</param>
        /// <returns>'対象文字列'（シングルクォーテーション付与済）</returns>
        /// <history>
        /// =======================================================================
        /// 更新履歴
        /// 項番　　　更新日付　　担当者　　更新内容
        /// 0001　　　2020/03/01  鶴　見    新規作成     
        /// =======================================================================
        /// </history>
        public string SingleQuotation(string str)
        {
            // シングルクォーテーションを付与
            return "'" + str + "'";
        }

        #endregion

        #region ウィンドウサイズ自動調整
        /// =======================================================================
        /// メソッド名 ： WindowSizeAutoAdjustment
        /// <summary>
        /// ウィンドウサイズ自動調整
        /// </summary>
        /// <param name="form">対象フォーム</param>
        /// <param name="dgv">対象データグリッドビュー</param>
        /// <history>
        /// =======================================================================
        /// 更新履歴
        /// 項番　　　更新日付　　担当者　　更新内容
        /// 0001　　　2020/03/01  鶴　見    新規作成     
        /// =======================================================================
        /// </history>
        public void WindowsSizeAutoAdjustment(Form form, DataGridView dgv)
        {
            // サイズ設定用変数
            int width = 0;

            // 全表示カラム幅計測
            foreach (DataGridViewColumn column in dgv.Columns.Cast<DataGridViewColumn>())
            {
                // 対象カラムが非表示の場合
                if (column.Visible == false)
                {
                    // 次のカラムへ
                    continue;
                }

                // カラム幅計上
                width += column.GetPreferredWidth(DataGridViewAutoSizeColumnMode.AllCells, true);
            }

            // 対象ウィンドウサイズ変更（92はカラム以外の要素の規定値）
            form.Width = width + 92;
        }

        #endregion

        #region 実施列車曜日コード取得
        /// =======================================================================
        /// メソッド名 ： GetYoubiCd
        /// <summary>
        /// 実施列車曜日コード取得
        /// </summary>
        /// <param name="date">日付</param>
        /// <returns>指定日付対応曜日コード</returns>
        /// <history>
        /// =======================================================================
        /// 更新履歴
        /// 項番　　　更新日付　　担当者　　更新内容
        /// 0001　　　2020/03/01  鶴　見    新規作成     
        /// =======================================================================
        /// </history>
        public string GetYoubiCd(DateTime date)
        {
            // 指定日付の曜日によって分岐
            switch (date.DayOfWeek)
            {
                // 指定日付が日曜の場合
                case DayOfWeek.Sunday:
                    return "01";

                // 指定日付が月曜の場合
                case DayOfWeek.Monday:
                    return "02";

                // 指定日付が火曜の場合
                case DayOfWeek.Tuesday:
                    return "03";

                // 指定日付が水曜の場合
                case DayOfWeek.Wednesday:
                    return "04";

                // 指定日付が木曜の場合
                case DayOfWeek.Thursday:
                    return "05";

                // 指定日付が金曜の場合
                case DayOfWeek.Friday:
                    return "06";

                // 指定日付が土曜の場合
                case DayOfWeek.Saturday:
                    return "07";

                // その他がある場合
                default:
                    return "";
            }
        }

        #endregion

        #endregion
    }
}
