var normalAttachs = new Array();

$(document).ready(function () {

    $("#txbEmpName").jqxInput({ minLength: 1, height: 25, width: 200 });

    var CorpUrl = "../Corporation/Corps";
    var CorpSource = { type: "POST", datatype: "json", datafields: [{ name: "CorpId" }, { name: "CorpName" }], url: CorpUrl };
    var CorpDataAdapter = new $.jqx.dataAdapter(CorpSource);
    $("#selCorpId").jqxComboBox({ source: CorpDataAdapter, displayMember: "CorpName", valueMember: "CorpId", autoComplete: true, searchMode: "contains", height: 25 });

    //加载列表
    var url = "../EmployeeSalary/LoadEmployeeSalaryList";
    var source =
    {
        datatype: "json",
        datafields:
        [
           { name: "EmpSalaryId", type: "int" },
           { name: "EmpId", type: "int" },
           { name: "EmpName", type: "string" },
           { name: "PayCity", type: "int" },
           { name: "PayCityName", type: "string" },
           { name: "CorpId", type: "int" },
           { name: "CorpPensionIns", type: "decimal" },
           { name: "CorpMedicalIns", type: "decimal" },
           { name: "CorpUnempIns", type: "decimal" },
           { name: "CorpInjuryIns", type: "decimal" },
           { name: "CorpBirthIns", type: "decimal" },
           { name: "CorpDisabledIns", type: "decimal" },
           { name: "CorpIllnessIns", type: "decimal" },
           { name: "CorpHeatAmount", type: "decimal" },
           { name: "CorpHouseFund", type: "decimal" },
           { name: "CorpRepInjuryIns", type: "decimal" },
           { name: "CorpTotal", type: "decimal" },
           { name: "EmpPensionIns", type: "decimal" },
           { name: "EmpMedicalIns", type: "decimal" },
           { name: "EmpUnempIns", type: "decimal" },
           { name: "EmpInjuryIns", type: "decimal" },
           { name: "EmpBirthIns", type: "decimal" },
           { name: "EmpDisabledIns", type: "decimal" },
           { name: "EmpIllnessIns", type: "decimal" },
           { name: "EmpHeatAmount", type: "decimal" },
           { name: "EmpHouseFund", type: "decimal" },
           { name: "EmpRepInjuryIns", type: "decimal" },
           { name: "EmpTotal", type: "decimal" },
           { name: "PersonalTax", type: "decimal" },
           { name: "TotalAmount", type: "decimal" },
           { name: "RepairAmount", type: "decimal" },
           { name: "GrossAmount", type: "decimal" },
           { name: "FinalAmount", type: "decimal" },
           { name: "ServiceAmount", type: "decimal" },
           { name: "RefundAmount", type: "decimal" },
           { name: "PayDate", type: "date" },
           { name: "EmpSalaryStatus", type: "int" },
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
        sortcolumn: "emps.EmpSalaryId",
        sortdirection: "desc",
        formatdata: function (data) {

            var obj = {
                pageIndex: data.pagenum,
                pageSize: data.pagesize,
                orderField: data.sortdatafield,
                sortOrder: data.sortorder,
                empName: $("#txbEmpName").val(),
                corpId: $("#selCorpId").val() == "" ? 0 : $("#selCorpId").val(),
                conStartDate: $("#tmConStartDate").val(),
                conEndDate: $("#tmConEndDate").val(),
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
          { text: "操作", datafield: "EmpSalaryId", cellsrenderer: cellsrenderer, width: 70, sortable: false, enabletooltips: false, menu: false, resizable: false, pinned: true },
          { text: "序号", cellsrenderer: numberrenderer, width: 40, sortable: false, enabletooltips: false, menu: false, resizable: false, editable: false, pinned: true },
          { text: "工资月", datafield: "PayDate", cellsformat: "yyyy-MM", pinned: true, width: 90, editable: false },
          { text: "姓名", datafield: "EmpName", pinned: true, width: 70, editable: false },
          { text: "缴费区域", datafield: "PayCityName", width: 70, editable: false },
          { text: "养老保险", columngroup: 'CorpDetails', datafield: "CorpPensionIns", width: 70 },
          { text: "医疗保险", columngroup: 'CorpDetails', datafield: "CorpMedicalIns", width: 70 },
          { text: "失业保险", columngroup: 'CorpDetails', datafield: "CorpUnempIns", width: 70 },
          { text: "工伤保险", columngroup: 'CorpDetails', datafield: "CorpInjuryIns", width: 70 },
          { text: "生育保险", columngroup: 'CorpDetails', datafield: "CorpBirthIns", width: 70 },
          { text: "残疾人保险", columngroup: 'CorpDetails', datafield: "CorpDisabledIns", width: 70 },
          { text: "大病保险", columngroup: 'CorpDetails', datafield: "CorpIllnessIns", width: 70 },
          { text: "取暖费", columngroup: 'CorpDetails', datafield: "CorpHeatAmount", width: 70 },
          { text: "公积金", columngroup: 'CorpDetails', datafield: "CorpHouseFund", width: 70 },
          { text: "补充工伤", columngroup: 'CorpDetails', datafield: "CorpRepInjuryIns", width: 70 },
          { text: "合计", columngroup: 'CorpDetails', datafield: "CorpTotal", width: 70 },
          { text: "养老保险", columngroup: 'EmpDetails', datafield: "EmpPensionIns", width: 70 },
          { text: "医疗保险", columngroup: 'EmpDetails', datafield: "EmpMedicalIns", width: 70 },
          { text: "失业保险", columngroup: 'EmpDetails', datafield: "EmpUnempIns", width: 70 },
          { text: "工伤保险", columngroup: 'EmpDetails', datafield: "EmpInjuryIns", width: 70 },
          { text: "生育保险", columngroup: 'EmpDetails', datafield: "EmpBirthIns", width: 70 },
          { text: "残疾人保险", columngroup: 'EmpDetails', datafield: "EmpDisabledIns", width: 70 },
          { text: "大病保险", columngroup: 'EmpDetails', datafield: "EmpIllnessIns", width: 70 },
          { text: "取暖费", columngroup: 'EmpDetails', datafield: "EmpHeatAmount", width: 70 },
          { text: "公积金", columngroup: 'EmpDetails', datafield: "EmpHouseFund", width: 70 },
          { text: "补充工伤", columngroup: 'EmpDetails', datafield: "EmpRepInjuryIns", width: 70 },
          { text: "合计", columngroup: 'EmpDetails', datafield: "EmpTotal", width: 70 },
          { text: "个调税", datafield: "PersonalTax", width: 70 },
          { text: "应发工资", datafield: "TotalAmount", width: 70 },
          { text: "社保补交", datafield: "RepairAmount", width: 70 },
          { text: "税前工资", datafield: "GrossAmount", width: 70 },
          { text: "实发工资", datafield: "FinalAmount", width: 70 },
          { text: "服务费", datafield: "ServiceAmount", width: 70 },
          { text: "补收/退款", datafield: "RefundAmount", width: 70 },
          { text: "合计", datafield: "AllTotalAmount", width: 70 },
        ],
        columngroups: [
            { text: '企业', align: 'center', name: 'CorpDetails' },
            { text: '个人', align: 'center', name: 'EmpDetails' }
        ]
    });

    $("#btnSearch").click(function () {
        $("#jqxListGrid").jqxGrid("gotopage", 0);
        $("#jqxListGrid").jqxGrid("updatebounddata", "rows");
    });

    $("#btnCreate").click(function () {

        if (!confirm("确认导入吗？")) { return; }

        //var formData = new FormData($("#empuploadfile"));

        //$.ajax({
        //    type: "POST",
        //    contentType: "application/json",
        //    url: "/EmployeeSalary/EmpUpLoadFile",
        //    data: formData,
        //    dataType: "json",
        //    success: function (result) {
        //        var obj = result;
        //        alert(obj.Message);
        //        if (obj.ResultStatus == 0) {
        //            //window.document.location.href = "/EmployeeSalary/CorpBillList";
        //        }
        //    }
        //});
    });

    CreateFileWindow();
});

//点击开启窗体
function OpenWindow() {
    $("#filewindow").jqxWindow("open");
};

//初始化窗体
function CreateFileWindow() {
    var jqxWidget = $('.admin-main');
    var offset = jqxWidget.offset();
    var conWith = 450;
    var conHight = 300;

    $('#filewindow').jqxWindow({
        position: { x: offset.left + jqxWidget.width() / 3, y: offset.top + jqxWidget.height() / 3 },
        height: conHight, width: conWith,
        resizable: false, isModal: true, modalOpacity: 0.3,
        initContent: function () {
            $('#filewindow').jqxWindow('close');
        }
    });
};


