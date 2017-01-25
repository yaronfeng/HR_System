$(document).ready(function () {
    var url = "../SocialBase/LoadSocialBaseList";
    var source =
    {
        datatype: "json",
        datafields:
        [
           { name: "SocId", type: "int" },
           { name: "CityId", type: "string" },
           { name: "PayCityName", type: "string" },

           { name: "SocName", type: "string" },
           { name: "PensionInsNum", type: "decimal" },
           { name: "MedicalInsNum", type: "decimal" },
           { name: "UnempInsNum", type: "decimal" },
           { name: "InjuryInsNum", type: "decimal" },
           { name: "BirthInsNum", type: "decimal" },
           { name: "DisabledInsNum", type: "decimal" },
           { name: "IllnessInsNum", type: "decimal" },
           { name: "HeatAmountNum", type: "decimal" },
           { name: "HouseFundNum", type: "decimal" },
           { name: "RepInjuryInsNum", type: "decimal" },

           { name: "CorpPensionInsPoint", type: "decimal" },
           { name: "CorpMedicalInsPoint", type: "decimal" },
           { name: "CorpUnempInsPoint", type: "decimal" },
           { name: "CorpInjuryInsPoint", type: "decimal" },
           { name: "CorpBirthInsPoint", type: "decimal" },
           { name: "CorpDisabledInsPoint", type: "decimal" },
           { name: "CorpIllnessInsPoint", type: "decimal" },
           { name: "CorpHeatAmountPoint", type: "decimal" },
           { name: "CorpHouseFundPoint", type: "decimal" },
           { name: "CorpRepInjuryInsPoint", type: "decimal" },

           { name: "EmpPensionInsPoint", type: "decimal" },
           { name: "EmpMedicalInsPoint", type: "decimal" },
           { name: "EmpUnempInsPoint", type: "decimal" },
           { name: "EmpInjuryInsPoint", type: "decimal" },
           { name: "EmpBirthInsPoint", type: "decimal" },
           { name: "EmpDisabledInsPoint", type: "decimal" },
           { name: "EmpIllnessInsPoint", type: "decimal" },
           { name: "EmpHeatAmountPoint", type: "decimal" },
           { name: "EmpHouseFundPoint", type: "decimal" },
           { name: "EmpRepInjuryInsPoint", type: "decimal" },

           { name: "PensionInsFix", type: "decimal" },
           { name: "MedicalInsFix", type: "decimal" },
           { name: "UnempInsFix", type: "decimal" },
           { name: "InjuryInsFix", type: "decimal" },
           { name: "BirthInsFix", type: "decimal" },
           { name: "DisabledInsFix", type: "decimal" },
           { name: "IllnessInsFix", type: "decimal" },
           { name: "HeatAmountFix", type: "decimal" },
           { name: "HouseFundFix", type: "decimal" },
           { name: "RepInjuryInsFix", type: "decimal" },
        ],
        sort: function () {
            $("#jqxListGrid").jqxGrid("updatebounddata", "sort");
        },
        beforeprocessing: function (data) {

            var returnValue = JSON.parse(data.ReturnValue);
            var returnData = {};

            if (data.ResultStatus != 0) {
                returnData.totalrecords = 0;
                returnData.records = [];
                alert(data.Message);
            }
            else {
                returnData.totalrecords = returnValue.count;
                returnData.records = returnValue.data;
            }

            return returnData;
        },
        type: "POST",
        sortcolumn: "SocId",
        sortdirection: "desc",
        formatdata: function (data) {

            var obj = {
                pageIndex: data.pagenum,
                pageSize: data.pagesize,
                orderField: data.sortdatafield,
                sortOrder: data.sortorder
            };

            var objStr = JSON.stringify(obj);
            return objStr;
        },
        url: url
    };
    var dataAdapter = new $.jqx.dataAdapter(source, {
        contentType: "application/json; charset=utf-8",
        loadError: function (xhr, status, error) {
            alert(error);
        }
    });

    var numberrenderer = function (row, column, value) {

        return "<div style=\"text-align: center; margin-top: 5px;\">" + (1 + row) + "</div>";
    }

    var cellsrenderer = function (row, columnfield, value, defaulthtml, columnproperties) {

        var item = $("#jqxListGrid").jqxGrid("getrowdata", row);
        var cellHtml = "<div style=\"overflow: hidden; text-overflow: ellipsis; padding:0px 0px 2px 10px; margin:4px 0px 0px 5px;\">";
        cellHtml += "<a target=\"_self\" href=\"SocialBaseDetail?id=" + value + "\">明细</a>";
        cellHtml += "&nbsp;&nbsp;&nbsp<a target=\"_self\" href=\"SocialBaseUpdate?id=" + value + "\">修改</a>";

        cellHtml += "</div>";
        return cellHtml;
    }

    $("#jqxListGrid").jqxGrid(
    {
        width: "98%",
        source: dataAdapter,
        pageable: true,
        autoheight: true,
        virtualmode: true,
        sorttogglestates: 1,
        columnsresize: true,
        sortable: true,
        enabletooltips: true,
        rendergridrows: function (args) {
            return args.data;
        },
        columns: [
          { text: "操作", datafield: "SocId", cellsrenderer: cellsrenderer, width: 100, sortable: false, enabletooltips: false, menu: false, resizable: false, pinned: true },
          { text: "序号", cellsrenderer: numberrenderer, width: 40, sortable: false, enabletooltips: false, menu: false, resizable: false, pinned: true },
          { text: "社保城市", datafield: "PayCityName", pinned: true, width: 70 },
          { text: "名称", datafield: "SocName", pinned: true, width: 70 },

          { text: "社保基数", columngroup: 'PensionInsDetails', datafield: "PensionInsNum", width: 70 },
          { text: "单位比例", columngroup: 'PensionInsDetails', datafield: "CorpPensionInsPoint", width: 70, cellsformat: "P" },
          { text: "个人比例", columngroup: 'PensionInsDetails', datafield: "EmpPensionInsPoint", width: 70, cellsformat: "P" },
          { text: "固定额", columngroup: 'PensionInsDetails', datafield: "PensionInsFix", width: 70 },

          { text: "社保基数", columngroup: 'MedicalInsDetails', datafield: "MedicalInsNum", width: 70 },
          { text: "单位比例", columngroup: 'MedicalInsDetails', datafield: "CorpMedicalInsPoint", width: 70, cellsformat: "P" },
          { text: "个人比例", columngroup: 'MedicalInsDetails', datafield: "EmpMedicalInsPoint", width: 70, cellsformat: "P" },
          { text: "固定额", columngroup: 'MedicalInsDetails', datafield: "MedicalInsFix", width: 70 },

          { text: "社保基数", columngroup: 'UnempInsDetails', datafield: "UnempInsNum", width: 70 },
          { text: "单位比例", columngroup: 'UnempInsDetails', datafield: "CorpUnempInsPoint", width: 70, cellsformat: "P" },
          { text: "个人比例", columngroup: 'UnempInsDetails', datafield: "EmpUnempInsPoint", width: 70, cellsformat: "P" },
          { text: "固定额", columngroup: 'UnempInsDetails', datafield: "UnempInsFix", width: 70 },

          { text: "社保基数", columngroup: 'InjuryInsDetails', datafield: "InjuryInsNum", width: 70 },
          { text: "单位比例", columngroup: 'InjuryInsDetails', datafield: "CorpInjuryInsPoint", width: 70, cellsformat: "P" },
          { text: "个人比例", columngroup: 'InjuryInsDetails', datafield: "EmpInjuryInsPoint", width: 70, cellsformat: "P" },
          { text: "固定额", columngroup: 'InjuryInsDetails', datafield: "InjuryInsFix", width: 70 },

          { text: "社保基数", columngroup: 'BirthInsDetails', datafield: "BirthInsNum", width: 70 },
          { text: "单位比例", columngroup: 'BirthInsDetails', datafield: "CorpBirthInsPoint", width: 70, cellsformat: "P" },
          { text: "个人比例", columngroup: 'BirthInsDetails', datafield: "EmpBirthInsPoint", width: 70, cellsformat: "P" },
          { text: "固定额", columngroup: 'BirthInsDetails', datafield: "BirthInsFix", width: 70 },

          { text: "社保基数", columngroup: 'DisabledInsDetails', datafield: "DisabledInsNum", width: 70 },
          { text: "单位比例", columngroup: 'DisabledInsDetails', datafield: "CorpDisabledInsPoint", width: 70, cellsformat: "P" },
          { text: "个人比例", columngroup: 'DisabledInsDetails', datafield: "EmpDisabledInsPoint", width: 70, cellsformat: "P" },
          { text: "固定额", columngroup: 'DisabledInsDetails', datafield: "DisabledInsFix", width: 70 },

          { text: "社保基数", columngroup: 'IllnessInsDetails', datafield: "IllnessInsNum", width: 70 },
          { text: "单位比例", columngroup: 'IllnessInsDetails', datafield: "CorpIllnessInsPoint", width: 70, cellsformat: "P" },
          { text: "个人比例", columngroup: 'IllnessInsDetails', datafield: "EmpIllnessInsPoint", width: 70, cellsformat: "P" },
          { text: "固定额", columngroup: 'IllnessInsDetails', datafield: "IllnessInsFix", width: 70 },

          { text: "社保基数", columngroup: 'HeatAmountDetails', datafield: "HeatAmountNum", width: 70 },
          { text: "单位比例", columngroup: 'HeatAmountDetails', datafield: "CorpHeatAmountPoint", width: 70, cellsformat: "P" },
          { text: "个人比例", columngroup: 'HeatAmountDetails', datafield: "EmpHeatAmountPoint", width: 70, cellsformat: "P" },
          { text: "固定额", columngroup: 'HeatAmountDetails', datafield: "HeatAmountFix", width: 70 },

          { text: "社保基数", columngroup: 'HouseFundDetails', datafield: "HouseFundNum", width: 70 },
          { text: "单位比例", columngroup: 'HouseFundDetails', datafield: "CorpHouseFundPoint", width: 70, cellsformat: "P" },
          { text: "个人比例", columngroup: 'HouseFundDetails', datafield: "EmpHouseFundPoint", width: 70, cellsformat: "P" },
          { text: "固定额", columngroup: 'HouseFundDetails', datafield: "HouseFundFix", width: 70 },

          { text: "社保基数", columngroup: 'RepInjuryInsDetails', datafield: "RepInjuryInsNum", width: 70 },
          { text: "单位比例", columngroup: 'RepInjuryInsDetails', datafield: "CorpRepInjuryInsPoint", width: 70, cellsformat: "P" },
          { text: "个人比例", columngroup: 'RepInjuryInsDetails', datafield: "EmpRepInjuryInsPoint", width: 70, cellsformat: "P" },
          { text: "固定额", columngroup: 'RepInjuryInsDetails', datafield: "RepInjuryInsFix", width: 70 },

        ],
        columngroups: [
            { text: '养老保险', align: 'center', name: 'PensionInsDetails' },
            { text: '医疗保险', align: 'center', name: 'MedicalInsDetails' },
            { text: '失业保险', align: 'center', name: 'UnempInsDetails' },
            { text: '工伤保险', align: 'center', name: 'InjuryInsDetails' },
            { text: '生育保险', align: 'center', name: 'BirthInsDetails' },
            { text: '残疾人保险', align: 'center', name: 'DisabledInsDetails' },
            { text: '大病保险', align: 'center', name: 'IllnessInsDetails' },
            { text: '取暖费', align: 'center', name: 'HeatAmountDetails' },
            { text: '公积金', align: 'center', name: 'HouseFundDetails' },
            { text: '补充工伤', align: 'center', name: 'RepInjuryInsDetails' }
        ]
    });
});