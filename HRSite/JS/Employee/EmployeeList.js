$(document).ready(function () {

    var url = "../Employee/LoadEmployeeList";
    var source =
    {
        datatype: "json",
        datafields:
        [
           { name: "EmpId", type: "int" },
           { name: "EmpName", type: "string" },
           { name: "Sex", type: "string" },
           { name: "CardNo", type: "string" },
           { name: "Phone", type: "string" },
           { name: "ConStartDate", type: "date" },
           { name: "ConEndDate", type: "date" },
           { name: "TotalAmount", type: "decimal" },
           { name: "EmpStatus", type: "int" },

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
        sortcolumn: "EmpId",
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
        cellHtml += "<a target=\"_self\" href=\"EmployeeDetail?id=" + value + "\">明细</a>";

        cellHtml += "&nbsp;&nbsp;&nbsp<a target=\"_self\" href=\"EmployeeUpdate?id=" + value + "\">修改</a>";

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
          { text: "操作", datafield: "EmpId", cellsrenderer: cellsrenderer, width: 100, sortable: false, enabletooltips: false, menu: false, resizable: false, pinned: true },
          { text: "序号", cellsrenderer: numberrenderer, width: 40, sortable: false, enabletooltips: false, menu: false, resizable: false, pinned: true },
          { text: "姓名", datafield: "EmpName", pinned: true, width: 150 },
          { text: "性别", datafield: "Sex", width: 120 },
          { text: "身份证", datafield: "CardNo", width: 150 },
          { text: "手机号", datafield: "Phone", width: 90 },
          { text: "合同起始日", datafield: "ConStartDate", cellsformat: "yyyy-MM-dd", width: 150 },
          { text: "合同截止日", datafield: "ConEndDate", cellsformat: "yyyy-MM-dd", width: 90 },
          { text: "应发工资", datafield: "TotalAmount", width: 90 },
          { text: "状态", datafield: "EmpStatus", width: 90 }
        ]
    });
});