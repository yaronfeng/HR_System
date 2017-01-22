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
           { name: "SocialFundNum", type: "decimal" },
           { name: "HouseFundNum", type: "decimal" },
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
          { text: "社保城市", datafield: "PayCityName", pinned: true, width: 90 },
          { text: "名称", datafield: "SocName", pinned: true, width: 120 },
          { text: "社保基数", datafield: "SocialFundNum", width: 70 },
          { text: "公积金基数", datafield: "HouseFundNum", width: 70 },

          { text: "养老保险", columngroup: 'CorpDetails', datafield: "CorpPensionInsPoint", width: 70, cellsformat: "P" },
          { text: "医疗保险", columngroup: 'CorpDetails', datafield: "CorpMedicalInsPoint", width: 70, cellsformat: "P" },
          { text: "失业保险", columngroup: 'CorpDetails', datafield: "CorpUnempInsPoint", width: 70, cellsformat: "P" },
          { text: "工伤保险", columngroup: 'CorpDetails', datafield: "CorpInjuryInsPoint", width: 70, cellsformat: "P" },
          { text: "生育保险", columngroup: 'CorpDetails', datafield: "CorpBirthInsPoint", width: 70, cellsformat: "P" },
          { text: "残疾人保险", columngroup: 'CorpDetails', datafield: "CorpDisabledInsPoint", width: 70, cellsformat: "P" },
          { text: "大病保险", columngroup: 'CorpDetails', datafield: "CorpIllnessInsPoint", width: 70, cellsformat: "P" },
          { text: "取暖费", columngroup: 'CorpDetails', datafield: "CorpHeatAmountPoint", width: 70, cellsformat: "P" },
          { text: "公积金", columngroup: 'CorpDetails', datafield: "CorpHouseFundPoint", width: 70, cellsformat: "P" },
          { text: "补充工伤", columngroup: 'CorpDetails', datafield: "CorpRepInjuryInsPoint", width: 70, cellsformat: "P" },

          { text: "养老保险", columngroup: 'EmpDetails', datafield: "EmpPensionInsPoint", width: 70, cellsformat: "P" },
          { text: "医疗保险", columngroup: 'EmpDetails', datafield: "EmpMedicalInsPoint", width: 70, cellsformat: "P" },
          { text: "失业保险", columngroup: 'EmpDetails', datafield: "EmpUnempInsPoint", width: 70, cellsformat: "P" },
          { text: "工伤保险", columngroup: 'EmpDetails', datafield: "EmpInjuryInsPoint", width: 70, cellsformat: "P" },
          { text: "生育保险", columngroup: 'EmpDetails', datafield: "EmpBirthInsPoint", width: 70, cellsformat: "P" },
          { text: "残疾人保险", columngroup: 'EmpDetails', datafield: "EmpDisabledInsPoint", width: 70, cellsformat: "P" },
          { text: "大病保险", columngroup: 'EmpDetails', datafield: "EmpIllnessInsPoint", width: 70, cellsformat: "P" },
          { text: "取暖费", columngroup: 'EmpDetails', datafield: "EmpHeatAmountPoint", width: 70, cellsformat: "P" },
          { text: "公积金", columngroup: 'EmpDetails', datafield: "EmpHouseFundPoint", width: 70, cellsformat: "P" },
          { text: "补充工伤", columngroup: 'EmpDetails', datafield: "EmpRepInjuryInsPoint", width: 70, cellsformat: "P" },
        ],
        columngroups: [
            { text: '企业', align: 'center', name: 'CorpDetails' },
            { text: '个人', align: 'center', name: 'EmpDetails' }
        ]
    });
});