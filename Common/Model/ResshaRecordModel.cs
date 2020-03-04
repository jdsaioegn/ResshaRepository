using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResshaDataBaseTools.Common.Model
{
    /// =======================================================================
    /// クラス名 ： ResshaRecordModel
    /// <summary>
    /// 実施列車レコードのマッピングを行うためのオブジェクトクラス
    /// </summary>
    /// <history>
    /// =======================================================================
    /// 更新履歴
    /// 項番　　　更新日付　　担当者　　更新内容
    /// 0001　　　2020/03/01  鶴　見    新規作成     
    /// =======================================================================
    /// </history>
    internal class ResshaRecordModel
    {
        /// <summary>列車番号</summary>
        public string ResshaNo { get; set; }

        /// <summary>休活コード</summary>
        public string KyukatsuCd { get; set; }

        /// <summary>線区コード</summary>
        public string SenkuCd { get; set; }

        /// <summary>上下コード</summary>
        public string JogeCd { get; set; }

        /// <summary>始発駅コード</summary>
        public string ShihatsuEkiCd { get; set; }

        /// <summary>終着駅コード</summary>
        public string ShuchakuEkiCd { get; set; }

        /// <summary>当日線区コード</summary>
        public string TojitsuSenkuCd { get; set; }

        /// <summary>足列車区分</summary>
        public string AshiResshaKbn { get; set; }

        /// <summary>走行状態</summary>
        public string SokoJotai { get; set; }

        /// <summary>ダイヤ管理日</summary>
        public string DiagramKanriDate { get; set; }

        /// <summary>駅コード</summary>
        public string EkiCd { get; set; }

        /// <summary>着休活コード</summary>
        public string ChakuKyukatsuCd { get; set; }

        /// <summary>発休活コード</summary>
        public string HatsuKyukatsuCd { get; set; }

        /// <summary>駅通過停車コード</summary>
        public string EkiTsukaTeishaCd { get; set; }

        /// <summary>実施到着相対日付</summary>
        public int JisshiChakuSotaiDate { get; set; }

        /// <summary>実施到着時刻</summary>
        public int JisshiChakuTime { get; set; }

        /// <summary>実施発車相対日付</summary>
        public int JisshiHatsuSotaiDate { get; set; }

        /// <summary>実施発車時刻</summary>
        public int JisshiHatsuTime { get; set; }

        /// <summary>実績到着相対日付</summary>
        public int JissekiChakuSotaiDate { get; set; }

        /// <summary>実績到着時刻</summary>
        public int JissekiChakuTime { get; set; }

        /// <summary>実績発車相対日付</summary>
        public int JissekiHatsuSotaiDate { get; set; }

        /// <summary>実績発車時刻</summary>
        public int JissekiHatsuTime { get; set; }

        /// <summary>走行順序</summary>
        public int SokoJunjo { get; set; }

        /// <summary>継送列車</summary>
        public string KeisoResshaNo { get; set; }

        /// <summary>併合番号</summary>
        public string HeigoResshaNo { get; set; }

        /// <summary>(主)列車施工日</summary>
        public int ShuhenseiSekoDate { get; set; }

        /// <summary>(主)車両運用番号</summary>
        public int ShuhenseiSharyoUnyoNo { get; set; }

        /// <summary>(主)足列車順序</summary>
        public int ShuhenseiAshiResshaJunjo { get; set; }

        /// <summary>(従)列車施工日</summary>
        public int JuhenseiSekoDate { get; set; }

        /// <summary>(従)車両運用番号</summary>
        public int JuhenseiSharyoUnyoNo { get; set; }

        /// <summary>(従)足列車順序</summary>
        public int JuhenseiAshiResshaJunjo { get; set; }

        /// <summary>(従2)列車施工日</summary>
        public int Juhensei2SekoDate { get; set; }

        /// <summary>(従2)車両運用番号</summary>
        public int Juhensei2SharyoUnyoNo { get; set; }

        /// <summary>(従2)足列車順序</summary>
        public int Juhensei2AshiResshaJunjo { get; set; }
    }
}
