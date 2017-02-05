$(document).ready(function () {

    var url = "../CorpBill/LoadCorpBillList";
    var source =
    {
        datatype: "json",
        datafields:
        [
           { name: "CorpBillId", type: "int" },
           { name: "PayDate", type: "date" },
           { name: "PayCity", type: "int" },
           { name: "CorpId", type: "int" },
           { name: "CorpName", type: "string" },
           { name: "BillPensionIns", type: "decimal" },
           { name: "BillMedicalIns", type: "decimal" },
           { name: "BillUnempIns", type: "decimal" },
           { name: "BillInjuryIns", type: "decimal" },
           { name: "BillBirthIns", type: "decimal" },
           { name: "BillDisabledIns", type: "decimal" },
           { name: "BillIllnessIns", type: "decimal" },
           { name: "BillHeatAmount", type: "decimal" },
           { name: "BillHouseFund", type: "decimal" },
           { name: "BillRepInjuryIns", type: "decimal" },
           { name: "CorpOtherPay", type: "decimal" },
           { name: "EmpOtherPay", type: "decimal" },
           { name: "ServiceAmount", type: "decimal" },
           { name: "TotalAmount", type: "decimal" },
           { name: "CorpBillStatus", type: "int" },
           { name: "StatusName", type: "int" },
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
        sortcolumn: "CorpBillId",
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
        cellHtml += "<a target=\"_self\" href=\"CorpBillDetail?id=" + value + "\">明细</a>";

        cellHtml += "&nbsp;&nbsp;&nbsp<a target=\"_self\" href=\"CorpBillUpdate?id=" + value + "\">修改</a>";
        cellHtml += "&nbsp;&nbsp;&nbsp<a target=\"_self\" href=\"javascript:SendCorpBillEmail(" + value + ")\">发送</a>";

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
          { text: "操作", datafield: "CorpBillId", cellsrenderer: cellsrenderer, width: 120, sortable: false, enabletooltips: false, menu: false, resizable: false, pinned: true },
          { text: "序号", cellsrenderer: numberrenderer, width: 40, sortable: false, enabletooltips: false, menu: false, resizable: false, pinned: true },
          { text: "企业名称", datafield: "CorpName", pinned: true, width: 150 },
          { text: "账单月", datafield: "PayDate", cellsformat: "yyyy-MM", width: 120 },
          { text: "养老保险", datafield: "BillPensionIns", width: 70 },
          { text: "医疗保险", datafield: "BillMedicalIns", width: 70 },
          { text: "失业保险", datafield: "BillUnempIns", width: 70 },
          { text: "工伤保险", datafield: "BillInjuryIns", width: 70 },
          { text: "生育保险", datafield: "BillBirthIns", width: 70 },
          { text: "残疾人保险", datafield: "BillDisabledIns", width: 70 },
          { text: "大病保险", datafield: "BillIllnessIns", width: 70 },
          { text: "取暖费", datafield: "BillHeatAmount", width: 70 },
          { text: "公积金", datafield: "BillHouseFund", width: 70 },
          { text: "补充工伤", datafield: "BillRepInjuryIns", width: 70 },
          { text: "服务费", datafield: "ServiceAmount", width: 70 },
          { text: "合计", datafield: "TotalAmount", width: 70 },
          { text: "状态", datafield: "StatusName", width: 90 }
        ]
    });


});

//发送邮件 操作
function SendCorpBillEmail(id) {

    if (!confirm("确定发送邮件操作吗?")) { return; }

    var temp = new Object();
    temp.id = id;

    $.ajax({
        type: "POST",
        contentType: "application/json",
        url: "/Send/SendEmail",
        data: JSON.stringify(temp),
        dataType: "json",
        success: function (result) {
            var obj = result;
            if (obj.ResultStatus == 0) {
                alert("发送成功");
            }
        }
    });
}