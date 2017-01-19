$(document).ready(function () {

    var url = "../CorpBill/LoadCorpBillReadyList";
    var source =
    {
        datatype: "json",
        datafields:
        [
           { name: "CorpId", type: "int" },
           { name: "CorpName", type: "string" },
           { name: "CorpAddress", type: "string" },
           { name: "CorpContacts", type: "string" },
           { name: "CorpTel", type: "string" },
           { name: "CorpEmail", type: "string" },
           { name: "PayCity", type: "int" },
           { name: "CorpStatus", type: "int" },
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
        sortcolumn: "CorpId",
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
        cellHtml += "<a target=\"_self\" href=\"CorpBillAdd?id=" + value + "\">生成</a>";
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
          { text: "操作", datafield: "CorpId", cellsrenderer: cellsrenderer, width: 100, sortable: false, enabletooltips: false, menu: false, resizable: false, pinned: true },
          { text: "序号", cellsrenderer: numberrenderer, width: 40, sortable: false, enabletooltips: false, menu: false, resizable: false, pinned: true },
          { text: "企业名称", datafield: "CorpName", pinned: true, width: 150 },
          { text: "地址", datafield: "CorpAddress", width: 120 },
          { text: "联系人", datafield: "CorpContacts", width: 150 },
          { text: "电话", datafield: "CorpTel", width: 90 },
          { text: "邮箱", datafield: "CorpEmail", width: 150 },
          { text: "缴费城市", datafield: "PayCity", width: 90 }
        ]
    });
});