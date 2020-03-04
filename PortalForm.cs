using ResshaDataBaseTools.Common;
using ResshaDataBaseTools.Common.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ResshaDataBaseTools
{
    /// =======================================================================
    /// クラス名 ： PortalForm
    /// <summary>
    /// 試験用統合DB編集ツール各機能共通画面
    /// </summary>
    /// <remarks>
    /// □試験用統合DB編集ツールの共通画面である。
    ///   各機能専用の画面はタブによって表示の切り替えを行う。
    /// □本画面には以下のメソッドが存在する。
    ///     □ClickSettingDateButton
    ///         □「日付設定」ボタン押下時発生イベント
    ///     □
    ///         □【実績初期化機能】「初期化」ボタン押下時発生イベント
    ///     □
    ///         □【実績更新機能】「一括更新」ボタン押下時発生イベント
    ///     □
    ///         □【実績更新機能】「'列車番号'」ボタン押下時発生イベント
    ///     □
    ///         □実施列車一覧表示
    ///     □
    ///         □実績初期化
    ///     □
    ///         □運行管理更新再現
    /// </remarks>
    /// <history>
    /// =======================================================================
    /// 更新履歴
    /// 項番　　　更新日付　　担当者　　更新内容
    /// 0001　　　2020/03/01  鶴　見    新規作成
    /// =======================================================================
    /// </history>
    public partial class PortalForm : FormBase
    {
        #region FORM初期化
        /// =======================================================================
        /// コンストラクタ名 ： PortalForm
        /// <summary>
        /// コンポーネント初期化処理
        /// </summary>
        /// <remarks>
        /// □試験用統合DB編集ツール各機能共通画面のコントロールを初期化する。
        /// </remarks>
        /// <history>
        /// =======================================================================
        /// 更新履歴
        /// 項番　　　更新日付　　担当者　　更新内容
        /// 0001　　　2020/03/01  鶴　見    新規作成     
        /// =======================================================================
        /// </history>
        public PortalForm()
        {
            InitializeComponent();
        }

        #endregion

        #region イベント

        #region 「日付設定」ボタン押下時発生イベント
        /// =======================================================================
        /// メソッド名 ： ClickSettingDateButton
        /// <summary>
        /// 「日付設定」ボタン押下時発生イベント
        /// </summary>
        /// <remarks>
        /// □「日付設定」ボタン押下時に日付選択項目で選択されている日付を
        ///     対象日付に設定。
        /// </remarks>
        /// <param name="sender">イベント発生元オブジェクト</param>
        /// <param name="e">イベント情報</param>
        /// <history>
        /// =======================================================================
        /// 更新履歴
        /// 項番　　　更新日付　　担当者　　更新内容
        /// 0001　　　2020/03/01  鶴　見    新規作成     
        /// =======================================================================
        /// </history>
        private void ClickSettingDateButton(object sender, EventArgs e)
        {
            // 設定済日付ど同一の日付を設定しようとした場合
            if (dateTimePickerTargetDate.Text.Replace("/", "") == TARGET_DATE)
            {
                // 終了
                return;
            }

            // グローバル変数「対象日付」更新
            TARGET_DATE = dateTimePickerTargetDate.Text.Replace("/", "");

            // グローバル変数「実施列車レコード」更新
            RESSHA_RECORD = _DbContext.SelectRecord<ResshaRecordModel>(string.Format(SqlCommandTemplate.SELECT_RESSHA_RECORD, TARGET_DATE))
                                      .OrderBy(p => p.SokoJunjo)
                                      .OrderBy(p => p.ResshaNo)
                                      .ToList();

            // グローバル変数「マスタレコード」更新
            MASTER_RECORD = _DbContext.SelectRecord<MasterRecordModel>(string.Format(SqlCommandTemplate.SELECT_MASTER_RECORD, TARGET_DATE));

            // グローバル変数「列車営業レコード」更新
            EIGYO_RECORD = _DbContext.SelectRecord<EigyoRecordModel>(string.Format(SqlCommandTemplate.SELECT_EIGYO_RECORD, TARGET_DATE));

            // グローバル変数「列車運用レコード」更新
            UNYO_RECORD = _DbContext.SelectRecord<UnyoRecordModel>(string.Format(SqlCommandTemplate.SELECT_UNYO_RECORD, dateTimePickerTargetDate.Value.AddDays(-2).ToShortDateString().Replace("/", ""),
                                                                                                                        dateTimePickerTargetDate.Value.AddDays(+2).ToShortDateString().Replace("/", "")));

            // ウィンドウヘッダ表示内容更新
            this.Text = this.Text.Split('：').First() + $"：{dateTimePickerTargetDate.Text}";

            // 【実績初期化機能】初期化対象日表示内容更新
            labelInitialisation.Text = labelInitialisation.Text.Split('：').First() + $"：{dateTimePickerTargetDate.Text}";

            // 各種機能専用画面表示（対象日設定以降のみ表示化するため）
            tabControl1.Visible = true;

            // 実施列車一覧描画
            DispResshaDataGridView();

            // ウィンドウサイズをデータグリッドビューの大きさをもとに動的に変更
            _Utility.WindowsSizeAutoAdjustment(this, dataGridViewResshaList);
        }
        #endregion

        #region 【実績初期化機能】「初期化」ボタン押下時発生イベント
        /// =======================================================================
        /// メソッド名 ： ClickInitializationButton
        /// <summary>
        /// 「初期化」ボタン押下時発生イベント
        /// </summary>
        /// <remarks>
        /// □
        /// </remarks>
        /// <param name="sender">イベント発生元オブジェクト</param>
        /// <param name="e">イベント情報</param>
        /// <history>
        /// =======================================================================
        /// 更新履歴
        /// 項番　　　更新日付　　担当者　　更新内容
        /// 0001　　　2020/03/01  鶴　見    新規作成     
        /// =======================================================================
        /// </history>
        private void ClickInitializationButton(object sender, EventArgs e)
        {
            // 初期化対象日設定
            DateTime InitializationDate = DateTime.Parse(TARGET_DATE.Insert(4,"/").Insert(7, "/"));

            // 初期化対象日-1日（前日）実施列車実績初期化
            AllUpdate(InitializationDate.AddDays(-1));

            // 初期化対象日+1日（翌日）実施列車実績初期化
            AllInitialize(InitializationDate.AddDays(+1));

            // 初期化対象日（当日）実施列車実績初期化
            AllInitialize(InitializationDate);

            // 
        }
        #endregion

        #region 【実績更新機能】「一括更新」ボタン押下時発生イベント

        #endregion

        #region 【実績更新機能】「'列車番号'」ボタン押下時発生イベント

        #endregion

        #endregion

        #region メソッド

        #region 実施列車一覧表示
        private void DispResshaDataGridView()
        {
            // 実施列車一覧にソート記号が存在する場合
            if (dataGridViewResshaList.SortedColumn != null)
            {
                // ソート記号の初期化
                dataGridViewResshaList.SortedColumn.HeaderCell.SortGlyphDirection = SortOrder.None;
            }

            // 実施列車一覧表示内容初期化
            dataGridViewResshaList.Rows.Clear();

            // 実施列車レコードをもとに列車番号毎にてグルーピングを行ったレコードリストを取得
            List<IGrouping<string, ResshaRecordModel>> resshaRecords = RESSHA_RECORD.GroupBy(p => p.ResshaNo)
                                                                                 .ToList();

            // 
            foreach (IGrouping<string, ResshaRecordModel> records in resshaRecords)
            {
                // 設定用デフォルトレコードの設定
                ResshaRecordModel record = records.First();

                // 当該列車の休活コードが「休（"1"）」である場合
                if (record.KyukatsuCd == "1")
                {
                    // 次の列車へ
                    continue;
                }

                // 始発駅休活判定用添え字
                int cntshihatsu = 0;
                // 終着駅休活判定用添え字
                int cntShuchaku = records.Count() - 1;

                // 上下カラム設定値
                string joge= "";
                // 走行状態カラム設定値
                string sokoJotai = "";
                // 始発駅名カラム設定値
                string shihatsuEki = "";
                // 始発時刻カラム設定値
                string shihatsuTime = "";
                // 終着駅名カラム設定値
                string shuchakuEki = "";
                // 終着時刻カラム設定値
                string shuchakuTime = "";
                // 営業種別（主編成）カラム設定値
                string eigyoShubetsuShuhensei = "";
                // 営業種別（従編成）カラム設定値
                string eigyoShubetsuJuhensei = "";
                // 営業種別（従編成②）カラム設定値
                string eigyoShubetsuJuhensei2 = "";
                // 継送列車番号カラム設定値
                string keisoResshaNo = "";
                // 特殊併合列車番号カラム設定値
                string tokushuResshaNo = "";

                // 上下コードが上り（"01"）である場合
                if (record.JogeCd == ConstCode.JOGECD_NOBORI)
                {
                    // 該当列車上下カラム表示内容に"上"を設定
                    joge = "上";
                }
                // 上下コードが下り（"02"）である場合
                else
                {
                    // 該当列車上下カラム表示内容に"下"を設定
                    joge = "下";
                }

                // 走行状態当該列車の走行状態によって分岐
                switch (record.SokoJotai)
                {
                    // 未走行の場合
                    case ConstCode.SOKOJOTAICD_MAE:
                        // 該当列車走行状態カラム表示内容に"未"を設定
                        sokoJotai = "未";
                        break;
                    // 走行中の場合
                    case ConstCode.SOKOJOTAICD_CHU:
                        // 該当列車走行状態カラム表示内容に"中"を設定
                        sokoJotai = "中";
                        break;
                    // 走行済の場合
                    case ConstCode.SOKOJOTAICD_ATO:
                        // 該当列車走行状態カラム表示内容に"済"を設定
                        sokoJotai = "済";
                        break;
                }

                // 繰り返し
                while (true)
                {
                    // 始発駅の発休活コードが「休」である場合
                    if (records.ElementAt(cntshihatsu).HatsuKyukatsuCd == ConstCode.KYUKATSUCD_KYU)
                    {
                        // 1つ次の駅を対象に再度休活コードを確認
                        cntshihatsu++;
                    }
                    // 始発駅の休活コードが「活」である場合
                    else
                    {
                        // 当該列車始発駅名カラムを設定
                        shihatsuEki = GetMasterValue(ConstCode.SHUBETSUCD_EKI, records.ElementAt(cntshihatsu).EkiCd);
                        // 当該列車始発時刻カラムを設定
                        shihatsuTime = _Utility.DispTime(records.ElementAt(cntshihatsu).JisshiHatsuSotaiDate, records.ElementAt(cntshihatsu).JisshiHatsuTime);
                        // 抜け
                        break;
                    }
                }

                // 繰り返し（最終走行駅が「休」である場合「活」である駅まで走行駅を遡る）
                while (true)
                {
                    // 終着駅の着休活コードが「休」である場合
                    if (records.ElementAt(cntShuchaku).ChakuKyukatsuCd == ConstCode.KYUKATSUCD_KYU)
                    {
                        // 1つ前の駅を対象に再度休活コードを確認
                        cntShuchaku--;
                    }
                    // 終着駅の休活コードが「活」である場合
                    else
                    {
                        // 当該列車終着駅名カラムを設定
                        shuchakuEki = GetMasterValue(ConstCode.SHUBETSUCD_EKI, records.ElementAt(cntShuchaku).EkiCd);
                        // 当該列車終着時刻カラムを設定
                        shuchakuTime = _Utility.DispTime(records.ElementAt(cntShuchaku).JisshiChakuSotaiDate, records.ElementAt(cntShuchaku).JisshiChakuTime);
                        // 抜け
                        break;
                    }
                }

                // 当該列車の営業種別を取得（主編成・従編成（存在する場合）・従編成②（存在する場合））
                List<Dictionary<string, string>> eigyo = GetEigyoDictionary(records.Key);

                // 当該列車営業種別（主編成）カラムを設定
                eigyoShubetsuShuhensei = GetMasterValue(ConstCode.SHUBETSUCD_EIGYO, _Utility.GetDispEigyoShubetsu(eigyo[0]));

                // 従編成の営業種別が存在する場合（≒従編成が存在する場合）
                if (eigyo.Count == 2)
                {
                    // 当該列車営業種別（従編成）カラムを設定
                    eigyoShubetsuJuhensei = GetMasterValue(ConstCode.SHUBETSUCD_EIGYO, _Utility.GetDispEigyoShubetsu(eigyo[1])); ;
                }

                // 従編成②の営業種別が存在する場合（≒従編成②が存在する場合）
                if (eigyo.Count == 3)
                {
                    // 当該列車営業種別（従編成②）カラムを設定
                    eigyoShubetsuJuhensei2 = GetMasterValue(ConstCode.SHUBETSUCD_EIGYO, _Utility.GetDispEigyoShubetsu(eigyo[2]));
                }

                // 当該列車に継送列車が存在する場合は当該列車継送列車カラムを設定
                keisoResshaNo = record.KeisoResshaNo ?? "";

                // 当該列車に特殊併合列車が存在する場合は当該列車特殊併合カラムを設定
                tokushuResshaNo = record.HeigoResshaNo ?? "";

                // 上記設定内容を用いて実施列車一覧に1行追加
                dataGridViewResshaList.Rows.Add(
                    // 列車番号カラム設定
                    records.Key,
                    // 上下カラム設定
                    joge,
                    // 営業種別（主編成）カラム設定
                    eigyoShubetsuShuhensei,
                    // 走行状態カラム設定
                    sokoJotai,
                    // 始発駅名カラム設定
                    shihatsuEki,
                    // 終着駅名カラム設定
                    shuchakuEki,
                    // 始発時刻カラム設定
                    shihatsuTime,
                    // 終着時刻カラム設定
                    shuchakuTime,
                    // 営業種別（従編成）カラム設定
                    eigyoShubetsuJuhensei,
                    // 営業種別（従編成②）カラム設定
                    eigyoShubetsuJuhensei2,
                    // 継送列車番号カラム設定
                    keisoResshaNo,
                    // 特殊併合列車番号カラム設定
                    tokushuResshaNo
                    );
            }

            // 特殊併合列車存在フラグ
            bool tokushu = false;

            // 表全レコードに対して繰り返し
            foreach (DataGridViewRow row in dataGridViewResshaList.Rows)
            {
                // 「継送列車」(10列目）列と、「特殊列車」(11列目)に対してのみ実施
                for (int i = 10; i < 12; i++)
                {
                    // 当該列に値が入力されている場合
                    if (!(string.IsNullOrEmpty(dataGridViewResshaList[i, row.Index].Value.ToString())))
                    {
                        // 当該セルをボタンカラムへ変更
                        dataGridViewResshaList[i, row.Index] = new DataGridViewButtonCell() { Value = dataGridViewResshaList[i, row.Index].Value };

                        // 特殊併合列車が1列車以上存在する場合特殊併合列車存在フラグを活性化
                        if (i == 11) tokushu = true;
                    }
                }
            }

            // 特殊併合列車存在フラグが非活性である場合、特殊併合列車列を非表示化
            if (tokushu == false) dataGridViewResshaList.Columns.GetLastColumn(DataGridViewElementStates.Visible, DataGridViewElementStates.None).Visible = false;

            // 表出力スタイル（文字出力位置）調整
            dataGridViewResshaList.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // 表出力スタイル（セル幅自動調整）調整
            dataGridViewResshaList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        #endregion

        #region 全実績更新
        private void AllUpdate(DateTime date)
        {
            // 
            List<IGrouping<string, ResshaRecordModel>> resshaList = Initialization(date);

            // 
            List<string> PRCChakuSotaiDateCmd = new List<string>();
            // 
            List<string> PRCChakuTimeCmd = new List<string>();
            // 
            List<string> JissekiChakuSotaiDateCmd = new List<string>();
            // 
            List<string> JissekiChakuTimeCmd = new List<string>();
            // 
            List<string> PRCHatsuSotaiDateCmd = new List<string>();
            // 
            List<string> PRCHatsuTimeCmd = new List<string>();
            // 
            List<string> JissekiHatsuSotaiDateCmd = new List<string>();
            // 
            List<string> JissekiHatsuTimeCmd = new List<string>();

            // 
            foreach (IGrouping<string, ResshaRecordModel> records in resshaList)
            {
                // 
                List<string> PRCChakuSotaiDateDetailCmd = new List<string>();
                // 
                List<string> PRCChakuTimeDetailCmd = new List<string>();
                // 
                List<string> JissekiChakuSotaiDateDetailCmd = new List<string>();
                // 
                List<string> JissekiChakuTimeDetailCmd = new List<string>();
                // 
                List<string> PRCHatsuSotaiDateDetailCmd = new List<string>();
                // 
                List<string> PRCHatsuTimeDetailCmd = new List<string>();
                // 
                List<string> JissekiHatsuSotaiDateDetailCmd = new List<string>();
                // 
                List<string> JissekiHatsuTimeDetailCmd = new List<string>();

                // 
                foreach (ResshaRecordModel record in records)
                {
                    // 
                    PRCChakuSotaiDateDetailCmd.Add(string.Format(SqlCommandTemplate.WHEN_THEN, record.SokoJunjo, record.JisshiHatsuSotaiDate));
                    // 
                    PRCChakuTimeDetailCmd.Add(string.Format(SqlCommandTemplate.WHEN_THEN, record.SokoJunjo, record.JisshiHatsuTime));
                    // 
                    JissekiChakuSotaiDateDetailCmd.Add(string.Format(SqlCommandTemplate.WHEN_THEN, record.SokoJunjo, record.JisshiHatsuSotaiDate));
                    // 
                    JissekiChakuTimeDetailCmd.Add(string.Format(SqlCommandTemplate.WHEN_THEN, record.SokoJunjo, record.JisshiHatsuTime));
                    // 
                    PRCHatsuSotaiDateDetailCmd.Add(string.Format(SqlCommandTemplate.WHEN_THEN, record.SokoJunjo, record.JisshiHatsuSotaiDate));
                    // 
                    PRCHatsuTimeDetailCmd.Add(string.Format(SqlCommandTemplate.WHEN_THEN, record.SokoJunjo, record.JisshiHatsuTime));
                    // 
                    JissekiHatsuSotaiDateDetailCmd.Add(string.Format(SqlCommandTemplate.WHEN_THEN, record.SokoJunjo, record.JisshiHatsuSotaiDate));
                    // 
                    JissekiHatsuTimeDetailCmd.Add(string.Format(SqlCommandTemplate.WHEN_THEN, record.SokoJunjo, record.JisshiHatsuTime));
                }

                // 
                PRCChakuSotaiDateCmd.Add(string.Format(SqlCommandTemplate.WHEN_THEN, _Utility.SingleQuotation(records.Key), string.Format(SqlCommandTemplate.CASE_END, "SokoJunjo", string.Join("", PRCChakuSotaiDateDetailCmd))));
                // 
                PRCChakuTimeCmd.Add(string.Format(SqlCommandTemplate.WHEN_THEN, _Utility.SingleQuotation(records.Key), string.Format(SqlCommandTemplate.CASE_END, "SokoJunjo", string.Join("", PRCChakuTimeDetailCmd))));
                // 
                JissekiChakuSotaiDateCmd.Add(string.Format(SqlCommandTemplate.WHEN_THEN, _Utility.SingleQuotation(records.Key), string.Format(SqlCommandTemplate.CASE_END, "SokoJunjo", string.Join("", JissekiChakuSotaiDateDetailCmd))));
                // 
                JissekiChakuTimeCmd.Add(string.Format(SqlCommandTemplate.WHEN_THEN, _Utility.SingleQuotation(records.Key), string.Format(SqlCommandTemplate.CASE_END, "SokoJunjo", string.Join("", JissekiChakuTimeDetailCmd))));
                // 
                PRCHatsuSotaiDateCmd.Add(string.Format(SqlCommandTemplate.WHEN_THEN, _Utility.SingleQuotation(records.Key), string.Format(SqlCommandTemplate.CASE_END, "SokoJunjo", string.Join("", PRCHatsuSotaiDateDetailCmd))));
                // 
                PRCHatsuTimeCmd.Add(string.Format(SqlCommandTemplate.WHEN_THEN, _Utility.SingleQuotation(records.Key), string.Format(SqlCommandTemplate.CASE_END, "SokoJunjo", string.Join("", PRCHatsuTimeDetailCmd))));
                // 
                JissekiHatsuSotaiDateCmd.Add(string.Format(SqlCommandTemplate.WHEN_THEN, _Utility.SingleQuotation(records.Key), string.Format(SqlCommandTemplate.CASE_END, "SokoJunjo", string.Join("", JissekiHatsuSotaiDateDetailCmd))));
                // 
                JissekiHatsuTimeCmd.Add(string.Format(SqlCommandTemplate.WHEN_THEN, _Utility.SingleQuotation(records.Key), string.Format(SqlCommandTemplate.CASE_END, "SokoJunjo", string.Join("", JissekiHatsuTimeDetailCmd))));
            }

            // 
            _DbContext.UpdateRecord(string.Format(SqlCommandTemplate.UPDATE_TKRT4105, date.ToShortDateString().Replace("/", ""), "PRCChakuSotaiDate", string.Format(SqlCommandTemplate.CASE_END, "ResshaNo", string.Join("", PRCChakuSotaiDateCmd))));
            // 
            _DbContext.UpdateRecord(string.Format(SqlCommandTemplate.UPDATE_TKRT4105, date.ToShortDateString().Replace("/", ""), "PRCChakuTime", string.Format(SqlCommandTemplate.CASE_END, "ResshaNo", string.Join("", PRCChakuTimeCmd))));
            // 
            _DbContext.UpdateRecord(string.Format(SqlCommandTemplate.UPDATE_TKRT4105, date.ToShortDateString().Replace("/", ""), "JissekiChakuSotaiDate", string.Format(SqlCommandTemplate.CASE_END, "ResshaNo", string.Join("", JissekiChakuSotaiDateCmd))));
            // 
            _DbContext.UpdateRecord(string.Format(SqlCommandTemplate.UPDATE_TKRT4105, date.ToShortDateString().Replace("/", ""), "JissekiChakuTime", string.Format(SqlCommandTemplate.CASE_END, "ResshaNo", string.Join("", JissekiChakuTimeCmd))));
            // 
            _DbContext.UpdateRecord(string.Format(SqlCommandTemplate.UPDATE_TKRT4105, date.ToShortDateString().Replace("/", ""), "PRCHatsuSotaiDate", string.Format(SqlCommandTemplate.CASE_END, "ResshaNo", string.Join("", PRCHatsuSotaiDateCmd))));
            // 
            _DbContext.UpdateRecord(string.Format(SqlCommandTemplate.UPDATE_TKRT4105, date.ToShortDateString().Replace("/", ""), "PRCHatsuTime", string.Format(SqlCommandTemplate.CASE_END, "ResshaNo", string.Join("", PRCHatsuTimeCmd))));
            // 
            _DbContext.UpdateRecord(string.Format(SqlCommandTemplate.UPDATE_TKRT4105, date.ToShortDateString().Replace("/", ""), "JissekiHatsuSotaiDate", string.Format(SqlCommandTemplate.CASE_END, "ResshaNo", string.Join("", JissekiHatsuSotaiDateCmd))));
            // 
            _DbContext.UpdateRecord(string.Format(SqlCommandTemplate.UPDATE_TKRT4105, date.ToShortDateString().Replace("/", ""), "JissekiHatsuTime", string.Format(SqlCommandTemplate.CASE_END, "ResshaNo", string.Join("", JissekiHatsuTimeCmd))));
            // 
            _DbContext.UpdateRecord(string.Format(SqlCommandTemplate.UPDATE_TKRT4105, date.ToShortDateString().Replace("/", ""), "RinjiTeishaFlg", "'0'"));
            // 
            _DbContext.UpdateRecord(string.Format(SqlCommandTemplate.UPDATE_TKRT4105, date.ToShortDateString().Replace("/", ""), "RinjiTeishaKbn", "'0'"));
            // 
            _DbContext.UpdateRecord(string.Format(SqlCommandTemplate.UPDATE_TKRT4105, date.ToShortDateString().Replace("/", ""), "ChakuJissekiKbn", "'9'"));
            // 
            _DbContext.UpdateRecord(string.Format(SqlCommandTemplate.UPDATE_TKRT4105, date.ToShortDateString().Replace("/", ""), "HatsuJissekiKbn", "'9'"));
            // 
            _DbContext.UpdateRecord(string.Format(SqlCommandTemplate.UPDATE_TKRT4105, date.ToShortDateString().Replace("/", ""), "PRCChakuJissekiKbn", "'9'"));
            // 
            _DbContext.UpdateRecord(string.Format(SqlCommandTemplate.UPDATE_TKRT4105, date.ToShortDateString().Replace("/", ""), "PRCHatsuJissekiKn", "'9'"));
        }

        #endregion

        #region 全実績初期化
        private void AllInitialize(DateTime date)
        {
            // 
            List<IGrouping<string, ResshaRecordModel>> resshaList = Initialization(date);

            // 
            List<string> PRCChakuSotaiDateCmd = new List<string>();
            // 
            List<string> PRCChakuTimeCmd = new List<string>();
            // 
            List<string> JissekiChakuSotaiDateCmd = new List<string>();
            // 
            List<string> JissekiChakuTimeCmd = new List<string>();
            // 
            List<string> PRCHatsuSotaiDateCmd = new List<string>();
            // 
            List<string> PRCHatsuTimeCmd = new List<string>();
            // 
            List<string> JissekiHatsuSotaiDateCmd = new List<string>();
            // 
            List<string> JissekiHatsuTimeCmd = new List<string>();

            // 
            foreach (IGrouping<string, ResshaRecordModel> records in resshaList)
            {
                // 
                List<string> PRCChakuSotaiDateDetailCmd = new List<string>();
                // 
                List<string> PRCChakuTimeDetailCmd = new List<string>();
                // 
                List<string> JissekiChakuSotaiDateDetailCmd = new List<string>();
                // 
                List<string> JissekiChakuTimeDetailCmd = new List<string>();
                // 
                List<string> PRCHatsuSotaiDateDetailCmd = new List<string>();
                // 
                List<string> PRCHatsuTimeDetailCmd = new List<string>();
                // 
                List<string> JissekiHatsuSotaiDateDetailCmd = new List<string>();
                // 
                List<string> JissekiHatsuTimeDetailCmd = new List<string>();

                // 
                foreach (ResshaRecordModel record in records)
                {
                    // 
                    PRCChakuSotaiDateDetailCmd.Add(string.Format(SqlCommandTemplate.WHEN_THEN, record.SokoJunjo, 9));
                    // 
                    PRCChakuTimeDetailCmd.Add(string.Format(SqlCommandTemplate.WHEN_THEN, record.SokoJunjo, -1));
                    // 
                    JissekiChakuSotaiDateDetailCmd.Add(string.Format(SqlCommandTemplate.WHEN_THEN, record.SokoJunjo, 9));
                    // 
                    JissekiChakuTimeDetailCmd.Add(string.Format(SqlCommandTemplate.WHEN_THEN, record.SokoJunjo, -1));
                    // 
                    PRCHatsuSotaiDateDetailCmd.Add(string.Format(SqlCommandTemplate.WHEN_THEN, record.SokoJunjo, 9));
                    // 
                    PRCHatsuTimeDetailCmd.Add(string.Format(SqlCommandTemplate.WHEN_THEN, record.SokoJunjo, -1));
                    // 
                    JissekiHatsuSotaiDateDetailCmd.Add(string.Format(SqlCommandTemplate.WHEN_THEN, record.SokoJunjo, 9));
                    // 
                    JissekiHatsuTimeDetailCmd.Add(string.Format(SqlCommandTemplate.WHEN_THEN, record.SokoJunjo, -1));
                }

                // 
                PRCChakuSotaiDateCmd.Add(string.Format(SqlCommandTemplate.WHEN_THEN, _Utility.SingleQuotation(records.Key), string.Format(SqlCommandTemplate.CASE_END, "SokoJunjo", string.Join("", PRCChakuSotaiDateDetailCmd))));
                // 
                PRCChakuTimeCmd.Add(string.Format(SqlCommandTemplate.WHEN_THEN, _Utility.SingleQuotation(records.Key), string.Format(SqlCommandTemplate.CASE_END, "SokoJunjo", string.Join("", PRCChakuTimeDetailCmd))));
                // 
                JissekiChakuSotaiDateCmd.Add(string.Format(SqlCommandTemplate.WHEN_THEN, _Utility.SingleQuotation(records.Key), string.Format(SqlCommandTemplate.CASE_END, "SokoJunjo", string.Join("", JissekiChakuSotaiDateDetailCmd))));
                // 
                JissekiChakuTimeCmd.Add(string.Format(SqlCommandTemplate.WHEN_THEN, _Utility.SingleQuotation(records.Key), string.Format(SqlCommandTemplate.CASE_END, "SokoJunjo", string.Join("", JissekiChakuTimeDetailCmd))));
                // 
                PRCHatsuSotaiDateCmd.Add(string.Format(SqlCommandTemplate.WHEN_THEN, _Utility.SingleQuotation(records.Key), string.Format(SqlCommandTemplate.CASE_END, "SokoJunjo", string.Join("", PRCHatsuSotaiDateDetailCmd))));
                // 
                PRCHatsuTimeCmd.Add(string.Format(SqlCommandTemplate.WHEN_THEN, _Utility.SingleQuotation(records.Key), string.Format(SqlCommandTemplate.CASE_END, "SokoJunjo", string.Join("", PRCHatsuTimeDetailCmd))));
                // 
                JissekiHatsuSotaiDateCmd.Add(string.Format(SqlCommandTemplate.WHEN_THEN, _Utility.SingleQuotation(records.Key), string.Format(SqlCommandTemplate.CASE_END, "SokoJunjo", string.Join("", JissekiHatsuSotaiDateDetailCmd))));
                // 
                JissekiHatsuTimeCmd.Add(string.Format(SqlCommandTemplate.WHEN_THEN, _Utility.SingleQuotation(records.Key), string.Format(SqlCommandTemplate.CASE_END, "SokoJunjo", string.Join("", JissekiHatsuTimeDetailCmd))));
            }

            // 
            _DbContext.UpdateRecord(string.Format(SqlCommandTemplate.UPDATE_TKRT4105, date.ToShortDateString().Replace("/", ""), "PRCChakuSotaiDate", string.Format(SqlCommandTemplate.CASE_END, "ResshaNo", string.Join("", PRCChakuSotaiDateCmd))));
            // 
            _DbContext.UpdateRecord(string.Format(SqlCommandTemplate.UPDATE_TKRT4105, date.ToShortDateString().Replace("/", ""), "PRCChakuTime", string.Format(SqlCommandTemplate.CASE_END, "ResshaNo", string.Join("", PRCChakuTimeCmd))));
            // 
            _DbContext.UpdateRecord(string.Format(SqlCommandTemplate.UPDATE_TKRT4105, date.ToShortDateString().Replace("/", ""), "JissekiChakuSotaiDate", string.Format(SqlCommandTemplate.CASE_END, "ResshaNo", string.Join("", JissekiChakuSotaiDateCmd))));
            // 
            _DbContext.UpdateRecord(string.Format(SqlCommandTemplate.UPDATE_TKRT4105, date.ToShortDateString().Replace("/", ""), "JissekiChakuTime", string.Format(SqlCommandTemplate.CASE_END, "ResshaNo", string.Join("", JissekiChakuTimeCmd))));
            // 
            _DbContext.UpdateRecord(string.Format(SqlCommandTemplate.UPDATE_TKRT4105, date.ToShortDateString().Replace("/", ""), "PRCHatsuSotaiDate", string.Format(SqlCommandTemplate.CASE_END, "ResshaNo", string.Join("", PRCHatsuSotaiDateCmd))));
            // 
            _DbContext.UpdateRecord(string.Format(SqlCommandTemplate.UPDATE_TKRT4105, date.ToShortDateString().Replace("/", ""), "PRCHatsuTime", string.Format(SqlCommandTemplate.CASE_END, "ResshaNo", string.Join("", PRCHatsuTimeCmd))));
            // 
            _DbContext.UpdateRecord(string.Format(SqlCommandTemplate.UPDATE_TKRT4105, date.ToShortDateString().Replace("/", ""), "JissekiHatsuSotaiDate", string.Format(SqlCommandTemplate.CASE_END, "ResshaNo", string.Join("", JissekiHatsuSotaiDateCmd))));
            // 
            _DbContext.UpdateRecord(string.Format(SqlCommandTemplate.UPDATE_TKRT4105, date.ToShortDateString().Replace("/", ""), "JissekiHatsuTime", string.Format(SqlCommandTemplate.CASE_END, "ResshaNo", string.Join("", JissekiHatsuTimeCmd))));
            // 
            _DbContext.UpdateRecord(string.Format(SqlCommandTemplate.UPDATE_TKRT4105, date.ToShortDateString().Replace("/", ""), "RinjiTeishaFlg", "'0'"));
            // 
            _DbContext.UpdateRecord(string.Format(SqlCommandTemplate.UPDATE_TKRT4105, date.ToShortDateString().Replace("/", ""), "RinjiTeishaKbn", "'0'"));
            // 
            _DbContext.UpdateRecord(string.Format(SqlCommandTemplate.UPDATE_TKRT4105, date.ToShortDateString().Replace("/", ""), "ChakuJissekiKbn", "'0'"));
            // 
            _DbContext.UpdateRecord(string.Format(SqlCommandTemplate.UPDATE_TKRT4105, date.ToShortDateString().Replace("/", ""), "HatsuJissekiKbn", "'0'"));
            // 
            _DbContext.UpdateRecord(string.Format(SqlCommandTemplate.UPDATE_TKRT4105, date.ToShortDateString().Replace("/", ""), "PRCChakuJissekiKbn", "'0'"));
            // 
            _DbContext.UpdateRecord(string.Format(SqlCommandTemplate.UPDATE_TKRT4105, date.ToShortDateString().Replace("/", ""), "PRCHatsuJissekiKn", "'0'"));
        }
        #endregion

        #region 共通更新
        private List<IGrouping<string, ResshaRecordModel>> Initialization(DateTime date)
        {
            // 走行状態値設定用
            string _SokoJotai = (int)(dateTimePickerTargetDate.Value - date).TotalDays == 1 ? "2" : "0";

            // 走行状態更新コマンド設定用
            List<string> SokoJotaiCmd = new List<string>();

            // 当日線区コード更新コマンド設定用
            List<string> TojitsuSenkuCmd = new List<string>();

            // 足列車区分更新コマンド設定用
            List<string> AshiResshaKbnCmd = new List<string>();

            // ダイヤ管理日更新コマンド設定用
            List<string> DiagramKnariDate = new List<string>();

            // 運行管理による一部レコード更新処理実施後のレコードを取得
            List<IGrouping<string, ResshaRecordModel>> ResshaList = UnkoKanriUpdate(date);

            // 上記で取得した実施列車レコードの列車番号毎に繰り返し
            foreach (IGrouping<string, ResshaRecordModel> records in ResshaList)
            {
                // 走行状態更新コマンド設定①
                SokoJotaiCmd.Add(string.Format(SqlCommandTemplate.WHEN_THEN, _Utility.SingleQuotation(records.Key), _Utility.SingleQuotation(_SokoJotai == "2" ? (records.First().KyukatsuCd == "1" ? "0" : "2") : "0")));

                // 当日線区コード更新コマンド設定①
                TojitsuSenkuCmd.Add(string.Format(SqlCommandTemplate.WHEN_THEN, _Utility.SingleQuotation(records.Key), _Utility.SingleQuotation(records.First().TojitsuSenkuCd)));

                // 足列車区分更新コマンド設定①
                AshiResshaKbnCmd.Add(string.Format(SqlCommandTemplate.WHEN_THEN, _Utility.SingleQuotation(records.Key), _Utility.SingleQuotation(records.First().AshiResshaKbn)));

                // ダイヤ管理日更新コマンド設定①
                DiagramKnariDate.Add(string.Format(SqlCommandTemplate.WHEN_THEN, _Utility.SingleQuotation(records.Key), _Utility.SingleQuotation(records.First().DiagramKanriDate)));
            }

            // 走行状態更新コマンド実効（設定②）
            _DbContext.UpdateRecord(string.Format(string.Format(SqlCommandTemplate.UPDATE_TKRT4101, date.ToShortDateString().Replace("/", ""), "SokoJotai", string.Format(SqlCommandTemplate.CASE_END, "ResshaNo", string.Join("", SokoJotaiCmd)))));

            // 当日線区コード更新コマンド実効（設定②）
            _DbContext.UpdateRecord(string.Format(string.Format(SqlCommandTemplate.UPDATE_TKRT4101, date.ToShortDateString().Replace("/", ""), "TojitsuSenkuCd", string.Format(SqlCommandTemplate.CASE_END, "ResshaNo", string.Join("", TojitsuSenkuCmd)))));

            // 足列車区分更新コマンド実効（設定②）
            _DbContext.UpdateRecord(string.Format(string.Format(SqlCommandTemplate.UPDATE_TKRT4101, date.ToShortDateString().Replace("/", ""), "AshiResshaKbn", string.Format(SqlCommandTemplate.CASE_END, "ResshaNo", string.Join("", AshiResshaKbnCmd)))));

            // ダイヤ管理日更新コマンド実効（設定②）
            _DbContext.UpdateRecord(string.Format(string.Format(SqlCommandTemplate.UPDATE_TKRT4101, date.ToShortDateString().Replace("/", ""), "DiagramKanriDate", string.Format(SqlCommandTemplate.CASE_END, "ResshaNo", string.Join("", DiagramKnariDate)))));

            // 
            return ResshaList;
        }
        #endregion

        #region 

        #endregion

        #region 運行管理更新再現
        /// =======================================================================
        /// メソッド名 ： UnkoKanriUpdate
        /// <summary>
        /// 運行管理更新再現
        /// </summary>
        /// <param name="date">日付</param>
        /// <returns>運行管理更新再現反映済み実施列車レコード</returns>
        /// <history>
        /// =======================================================================
        /// 更新履歴
        /// 項番　　　更新日付　　担当者　　更新内容
        /// 0001　　　2020/03/01  鶴　見    新規作成     
        /// =======================================================================
        /// </history>
        private List<IGrouping<string, ResshaRecordModel>> UnkoKanriUpdate(DateTime date)
        {
            // 対象日付を列車施工日とする実施列車レコードを取得（統合データへ自動的にデータ格納）
            RESSHA_RECORD = _DbContext.SelectRecord<ResshaRecordModel>(string.Format(SqlCommandTemplate.SELECT_RESSHA_RECORD, date.ToShortDateString().Replace("/", "")));

            // 統合データより上記取得レコードを取得
            List<IGrouping<string, ResshaRecordModel>> ResshaList = RESSHA_RECORD.OrderBy(p => p.SokoJunjo)
                                                                                 .GroupBy(p => p.ResshaNo)
                                                                                 .OrderBy(p => p.Key)
                                                                                 .ToList();

            // 統合データより列車運用レコードを取得
            List<UnyoRecordModel> UnyoList = UNYO_RECORD;

            // 実施列車1レコード毎に繰り返し
            foreach (IGrouping<string, ResshaRecordModel> records in ResshaList)
            {
                // 当日線区コード設定用
                string _TojitsuSenkuCd = string.Empty;

                // 当該列車の始発レコードを指標として設定
                ResshaRecordModel record = records.First();

                // 実施列車の線区コードにより設定
                switch (record.SenkuCd)
                {
                    // 東北線区の場合
                    case "01":
                        // 小山運が始発or終着の場合
                        if (record.ShihatsuEkiCd == "007" || record.ShuchakuEkiCd == "007") _TojitsuSenkuCd = "17";

                        // 青幹所が始発or終着の場合
                        if (record.ShihatsuEkiCd == "031" || record.ShuchakuEkiCd == "031") _TojitsuSenkuCd = "21";

                        // 函総車が始発or終着の場合
                        if (record.ShihatsuEkiCd == "232" || record.ShuchakuEkiCd == "232") _TojitsuSenkuCd = "22";

                        // 上記に該当しない場合
                        if (string.IsNullOrEmpty(_TojitsuSenkuCd)) _TojitsuSenkuCd = "01";

                        // 抜け
                        break;

                    // 上越線区の場合
                    case "02":
                        // ガーラが始発or終着の場合
                        if (record.ShihatsuEkiCd == "037" || record.ShuchakuEkiCd == "037") _TojitsuSenkuCd = "18";

                        // 上記に該当しない場合
                        if (string.IsNullOrEmpty(_TojitsuSenkuCd)) _TojitsuSenkuCd = "02";

                        // 抜け
                        break;

                    // 上越線区の場合
                    case "05":
                        // 上越線区のみ線区そのままではなく新庄線区を選択する
                        _TojitsuSenkuCd = "19";

                        // 抜け
                        break;

                    // 上記以外の線区の場合
                    default:
                        // 計画系の線区コードを設定
                        _TojitsuSenkuCd = record.SenkuCd;

                        // 抜け
                        break;
                }

                // 当日線区コード更新
                records.ToList()
                       .ForEach(p => p.TojitsuSenkuCd = _TojitsuSenkuCd);

                // 足列車の取得
                UnyoRecordModel Unyo = UnyoList.Where(p => p.ResshaSekoDate == int.Parse(date.ToShortDateString().Replace("/", "")))
                                               .Where(p => p.ResshaNo == record.ResshaNo)
                                               .Where(p => p.HenseiKbn == 1)
                                               .FirstOrDefault();

                // 足列車が存在しない場合
                if (Unyo == null)
                {
                    // 次の列車へ
                    continue;
                }

                // 先頭足列車の取得
                UnyoRecordModel TopUnyo = UnyoList.Where(p => p.SekoDate == Unyo.SekoDate)
                                                  .Where(p => p.SharyoUnyoNo == Unyo.SharyoUnyoNo)
                                                  .Where(p => p.AshiResshaJunjo == 1)
                                                  .FirstOrDefault();

                // 先頭足列車が存在しない場合
                if (TopUnyo == null)
                {
                    // 終了
                    return null;
                }

                // 足列車区分の設定
                records.ToList()
                       .ForEach(p => p.AshiResshaKbn = _Utility.GetYoubiCd(DateTime.Parse(TopUnyo.ResshaSekoDate.ToString().Insert(4, "/").Insert(7, "/"))));

                // ダイヤ管理日の基準日
                DateTime _DiagramKanriDate = date;

                // 当日のAM5時までに始発する場合
                if (_Utility.GetTime(record.JisshiHatsuSotaiDate, record.JisshiHatsuTime) < 18000)
                {
                    // ダイヤ管理日を前日日付に設定
                    _DiagramKanriDate = _DiagramKanriDate.AddDays(-1);
                }

                // ダイヤ管理日の設定
                records.ToList()
                       .ForEach(p => p.DiagramKanriDate = _Utility.GetYoubiCd(_DiagramKanriDate));
            }

            // 終了
            return ResshaList;
        }
        #endregion

        #endregion
    }
}
