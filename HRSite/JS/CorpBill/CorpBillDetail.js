$(document).ready(function () {
    var id = $("#hidId").val();

    //绑定
    $("#tmBillDate").jqxDateTimeInput({ formatString: "yyyy-MM", disabled: true });
    $("#tmPayDate").jqxDateTimeInput({ formatString: "yyyy-MM-dd", disabled: true });

    $("#numBillPensionIns").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, disabled: true });
    $("#numBillMedicalIns").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, disabled: true });
    $("#numBillUnempIns").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, disabled: true });
    $("#numBillInjuryIns").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, disabled: true });
    $("#numBillBirthIns").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, disabled: true });
    $("#numBillDisabledIns").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, disabled: true });
    $("#numBillIllnessIns").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, disabled: true });
    $("#numBillHeatAmount").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, disabled: true });
    $("#numBillHouseFund").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, disabled: true });
    $("#numBillRepInjuryIns").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, disabled: true });
    $("#numCorpOtherPay").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, disabled: true });
    $("#numEmpOtherPay").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, disabled: true });
    $("#numServiceAmount").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, disabled: true });
    $("#numTotalAmount").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, disabled: true });

    var CorpUrl = "../Supplier/Suppliers";
    var CorpSource = { type: "POST", datatype: "json", datafields: [{ name: "SupId" }, { name: "SupName" }], url: CorpUrl };
    var CorpDataAdapter = new $.jqx.dataAdapter(CorpSource);
    $("#selSupId").jqxComboBox({ source: CorpDataAdapter, displayMember: "SupName", valueMember: "SupId", autoComplete: true, searchMode: "contains", height: 25, disabled: true });

    var CorpUrl = "/CommBase/PayCitys";
    var CorpSource = { type: "POST", datatype: "json", datafields: [{ name: "DetailId" }, { name: "DetailName" }], url: CorpUrl };
    var CorpDataAdapter = new $.jqx.dataAdapter(CorpSource);
    $("#selPayCity").jqxDropDownList({ source: CorpDataAdapter, displayMember: "DetailName", valueMember: "DetailId", height: 25, selectedIndex: 0,disabled:true });

    var CorpUrl = "../Corporation/Corps";
    var CorpSource = { type: "POST", datatype: "json", datafields: [{ name: "CorpId" }, { name: "CorpName" }], url: CorpUrl };
    var CorpDataAdapter = new $.jqx.dataAdapter(CorpSource);
    $("#selCorpId").jqxComboBox({ source: CorpDataAdapter, displayMember: "CorpName", valueMember: "CorpId", autoComplete: true, searchMode: "contains", height: 25, disabled: true });

    //获取实体
    var temp = new Object();
    temp.id = id;

    $.ajax({
        type: "POST",
        contentType: "application/json",
        url: "/CorpBill/Get",
        data: JSON.stringify(temp),
        dataType: "json",
        success: function (result) {

            var obj = result;
            if (obj.ResultStatus == 0) {

                var rtnObj = JSON.parse(obj.ReturnValue);

                //设置原值
                $("#selCorpId").val(rtnObj.CorpId)
                $("#numBillPensionIns").val(rtnObj.BillPensionIns);
                $("#numBillMedicalIns").val(rtnObj.BillMedicalIns);
                $("#numBillUnempIns").val(rtnObj.BillUnempIns);
                $("#numBillInjuryIns").val(rtnObj.BillInjuryIns);
                $("#numBillBirthIns").val(rtnObj.BillBirthIns);
                $("#numBillDisabledIns").val(rtnObj.BillDisabledIns);
                $("#numBillIllnessIns").val(rtnObj.BillIllnessIns);
                $("#numBillHeatAmount").val(rtnObj.BillHeatAmount);
                $("#numBillHouseFund").val(rtnObj.BillHouseFund);
                $("#numBillRepInjuryIns").val(rtnObj.BillRepInjuryIns);
                $("#numServiceAmount").val(rtnObj.ServiceAmount);
                $("#numTotalAmount").val(rtnObj.TotalAmount);

                $("#tmBillDate").val(rtnObj.BillDate);
                $("#tmPayDate").val(rtnObj.PayDate);
                $("#selSupId").val(rtnObj.SupId);
                $("#selPayCity").val(rtnObj.PayCity);

            }
            else {
                alert(obj.Message);
                document.location.href = obj.ReturnValue;
            }
        }
    });

    //开始加载
    var url = "../CorpBill/LoadEmployeeSalaryByIdList";
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
           { name: "CardNo", type: "string" },
           { name: "SocialFundNum", type: "decimal" },
           { name: "HouseFundNum", type: "decimal" },
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
        sortcolumn: "EmpSalaryId",
        sortdirection: "desc",
        formatdata: function (data) {

            var obj = {
                pageIndex: data.pagenum,
                pageSize: data.pagesize,
                orderField: data.sortdatafield,
                sortOrder: data.sortorder,
                corpBillId : id
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
          { text: "序号", cellsrenderer: numberrenderer, width: 40, sortable: false, enabletooltips: false, menu: false, resizable: false, editable: false, pinned: true },
          { text: "姓名", datafield: "EmpName", pinned: true, width: 90, editable: false },
          { text: "身份证", datafield: "CardNo", width: 150, editable: false },
          { text: "缴费区域", datafield: "PayCityName", width: 70, editable: false },
          { text: "社保基数", datafield: "SocialFundNum", width: 70, editable: false },
          { text: "公积金基数", datafield: "HouseFundNum", width: 70, editable: false },
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
});