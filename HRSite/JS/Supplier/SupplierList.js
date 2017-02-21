$(document).ready(function () {
    var CorpUrl = "../Supplier/Suppliers";
    var CorpSource = { type: "POST", datatype: "json", datafields: [{ name: "SupId" }, { name: "SupName" }], url: CorpUrl };
    var CorpDataAdapter = new $.jqx.dataAdapter(CorpSource);
    $("#selSupId").jqxComboBox({ source: CorpDataAdapter, displayMember: "SupName", valueMember: "SupId", autoComplete: true, searchMode: "contains", height: 25 });

    var url = "../Supplier/LoadSupplierList";
    var source =
    {
        datatype: "json",
        datafields:
        [
           { name: "SupId", type: "int" },
           { name: "SupName", type: "string" },
           { name: "SupEName", type: "string" },
           { name: "SupContacts", type: "string" },
           { name: "SupTel", type: "string" },
           { name: "SupFax", type: "string" },
           { name: "SupZip", type: "string" },
           { name: "SupEmail", type: "string" },
           { name: "Bank", type: "int" },
           { name: "BankAccount", type: "string" },
           { name: "SupStatus", type: "int" },
           { name: "StatusName", type: "string" },
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
        sortcolumn: "SupId",
        sortdirection: "desc",
        formatdata: function (data) {

            var obj = {
                pageIndex: data.pagenum,
                pageSize: data.pagesize,
                orderField: data.sortdatafield,
                sortOrder: data.sortorder,
                supId: $("#selSupId").val() == "" ? 0 : $("#selSupId").val()
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
        cellHtml += "<a target=\"_self\" href=\"SupplierDetail?id=" + value + "\">明细</a>";

        cellHtml += "&nbsp;&nbsp;&nbsp<a target=\"_self\" href=\"SupplierUpdate?id=" + value + "\">修改</a>";

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
          { text: "操作", datafield: "SupId", cellsrenderer: cellsrenderer, width: 100, sortable: false, enabletooltips: false, menu: false, resizable: false, pinned: true },
          { text: "序号", cellsrenderer: numberrenderer, width: 40, sortable: false, enabletooltips: false, menu: false, resizable: false, pinned: true },
          { text: "公司名称", datafield: "SupName", pinned: true, width: 150 },
          { text: "联系人", datafield: "SupContacts", width: 90 },
          { text: "电话", datafield: "SupTel", width: 90 },
          { text: "传真", datafield: "SupFax", width: 90 },
          { text: "邮编", datafield: "SupZip", width: 90 },
          { text: "邮箱", datafield: "SupEmail", width: 90 },
          { text: "银行", datafield: "Bank", width: 90 },
          { text: "银行账号", datafield: "BankAccount", width: 90 },
          { text: "服务费", datafield: "ServiceAmount", width: 90 },
          { text: "状态", datafield: "StatusName", width: 90 }
        ]
    });
    $("#btnSearch").click(function () {
        $("#jqxListGrid").jqxGrid("gotopage", 0);
        $("#jqxListGrid").jqxGrid("updatebounddata", "rows");
    });
});