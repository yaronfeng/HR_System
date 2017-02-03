var optList = new Array();
$(document).ready(function () {
    //绑定
    var CorpUrl = "../Corporation/Corps";
    var CorpSource = { type: "POST", datatype: "json", datafields: [{ name: "CorpId" }, { name: "CorpName" }], url: CorpUrl };
    var CorpDataAdapter = new $.jqx.dataAdapter(CorpSource);
    $("#selCorpId").jqxComboBox({ source: CorpDataAdapter, displayMember: "CorpName", valueMember: "CorpId", autoComplete: true, searchMode: "contains", height: 25 });

    $("#tmPayDate").jqxDateTimeInput({ formatString: "yyyy-MM" });

    //校验
    $("#jqxValidator").jqxValidator({
        position: "topcenter",
        rules:
            [
                {
                    input: "#tmPayDate", message: "薪资月必填", action: "keyup, blur,valuechange", rule: function (input, commit) {
                        return $("#tmPayDate").val() != "";
                    }
                }
            ]
    });


    var url = "../Employee/LoadEmployeePayList";
    var source =
    {
        datatype: "json",
        datafields:
        [
           { name: "EmpId", type: "int" },
           { name: "EmpName", type: "string" },
           { name: "CorpName", type: "string" },
           { name: "Sex", type: "string" },
           { name: "CardNo", type: "string" },
           { name: "Phone", type: "string" },
           { name: "ConStartDate", type: "date" },
           { name: "ConEndDate", type: "date" },
           { name: "TotalAmount", type: "decimal" },
           { name: "Degree", type: "string" },
           { name: "PayCity", type: "string" },
           { name: "EmpEmail", type: "string" },
           { name: "EmpStatus", type: "int" },
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

            optList = returnValue.data;

            return returnValue;
        },
        type: "POST",
        sortcolumn: "emp.EmpId",
        sortdirection: "desc",
        formatdata: function (data) {

            var obj = {
                pageIndex: data.pagenum,
                pageSize: data.pagesize,
                orderField: data.sortdatafield,
                sortOrder: data.sortorder,
                corpId: $("#selCorpId").val() == "" ? 0: $("#selCorpId").val(),
                payDate: $("#tmPayDate").val()
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

    $("#jqxListGrid").jqxGrid(
    {
        width: "98%",
        source: dataAdapter,
        //pageable: true,
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
          { text: "序号", cellsrenderer: numberrenderer, width: 40, sortable: false, enabletooltips: false, menu: false, resizable: false, pinned: true },
          { text: "姓名", datafield: "EmpName", pinned: true, width: 90 },
          { text: "所属企业", datafield: "CorpName", pinned: true, width: 120 },
          { text: "性别", datafield: "Sex", width: 60 },
          { text: "身份证", datafield: "CardNo", width: 150 },
          { text: "手机号", datafield: "Phone", width: 90 },
          { text: "合同起始日", datafield: "ConStartDate", cellsformat: "yyyy-MM-dd", width: 90 },
          { text: "合同截止日", datafield: "ConEndDate", cellsformat: "yyyy-MM-dd", width: 90 },
          { text: "应发工资", datafield: "TotalAmount", width: 90 },
          { text: "学历", datafield: "Degree", width: 90 },
          { text: "缴费城市", datafield: "PayCity", width: 90 },
          { text: "邮箱", datafield: "EmpEmail", width: 90 },
          { text: "状态", datafield: "StatusName", width: 90 }
        ]
    });

    $("#btnSearch").click(function () {
        $("#jqxListGrid").jqxGrid("gotopage", 0);
        $("#jqxListGrid").jqxGrid("updatebounddata", "rows");
    });

    //加载列表完毕

    $("#btnCreate").click(function () {

        var isCanSubmit = $("#jqxValidator").jqxValidator("validate");
        if (!isCanSubmit) { return; }
        if (!confirm("确认发放薪资？")) { return; }

        var paras = new Object();
        paras.details = optList;

        $.ajax({
            type: "POST",
            contentType: "application/json",
            url: "/Employee/InsertEmployeeSalary",
            data: JSON.stringify(paras),
            dataType: "json",
            success: function (result) {
                var obj = result;
                alert(obj.Message);
                if (obj.ResultStatus == 0) {
                    window.document.location.href = "/Employee/CalculatePay";
                }
            }
        });
    });
});