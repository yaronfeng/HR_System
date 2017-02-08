$(document).ready(function () {
    var id = $("#hidId").val();
    //绑定
    $("#txbEmpName").jqxInput({ minLength: 1, height: 25, width: 200 ,disabled:true});
    $("#txbCardNo").jqxInput({ minLength: 1, height: 25, width: 200, disabled: true });
    $("#txbAddress").jqxInput({ minLength: 1, height: 25, width: 200, disabled: true });
    $("#txbPhone").jqxInput({ minLength: 1, height: 25, width: 200, disabled: true });
    $("#txbPhone").jqxInput({ minLength: 1, height: 25, width: 200, disabled: true });
    $("#txbJobs").jqxInput({ minLength: 1, height: 25, width: 200, disabled: true });
    $("#txbHouseAccount").jqxInput({ minLength: 1, height: 25, width: 200, disabled: true });
    $("#txbBankAccount").jqxInput({ minLength: 1, height: 25, width: 200, disabled: true });
    $("#txbContractNo").jqxInput({ minLength: 1, height: 25, width: 200, disabled: true });
    $("#txbInsCardNo").jqxInput({ minLength: 1, height: 25, width: 200, disabled: true });
    $("#txbEmpEmail").jqxInput({ minLength: 1, height: 25, width: 200, disabled: true });

    $("#tmEntryDate").jqxDateTimeInput({ formatString: "yyyy-MM-dd", disabled: true });

    $("#tmConStartDate").jqxDateTimeInput({ formatString: "yyyy-MM-dd", disabled: true });
    $("#tmConEndDate").jqxDateTimeInput({ formatString: "yyyy-MM-dd", disabled: true });
    $("#tmLeaveDate").jqxDateTimeInput({ formatString: "yyyy-MM-dd", value: new Date(1900, 0, 1), disabled: true });
    $("#tmSocialStartDate").jqxDateTimeInput({ formatString: "yyyy-MM-dd", disabled: true });
    $("#tmHouseStartDate").jqxDateTimeInput({ formatString: "yyyy-MM-dd", disabled: true });
    $("#tmEmployDate").jqxDateTimeInput({ formatString: "yyyy-MM-dd", disabled: true });
    $("#tmSocialSignDate").jqxDateTimeInput({ formatString: "yyyy-MM-dd", value: new Date(1900, 0, 1), disabled: true });

    $("#numTotalAmount").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, disabled: true });

    $("#numPISINum").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, disabled: true });
    $("#numMISINum").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, disabled: true });
    $("#numUISINum").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, disabled: true });
    $("#numIISINum").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, disabled: true });
    $("#numBISINum").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, disabled: true });
    $("#numDISINum").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, disabled: true });
    $("#numLISINum").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, disabled: true });
    $("#numHASINum").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, disabled: true });
    $("#numHFSINum").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, disabled: true });
    $("#numRISINum").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true, disabled: true });

    var SexUrl = "/CommBase/Sexs";
    var SexSource = { type: "POST", datatype: "json", datafields: [{ name: "DetailId" }, { name: "DetailName" }], url: SexUrl };
    var SexDataAdapter = new $.jqx.dataAdapter(SexSource);
    $("#selSex").jqxDropDownList({ source: SexDataAdapter, displayMember: "DetailName", valueMember: "DetailId", height: 25, selectedIndex: 0, disabled: true });

    var CorpUrl = "/CommBase/Degrees";
    var CorpSource = { type: "POST", datatype: "json", datafields: [{ name: "DetailId" }, { name: "DetailName" }], url: CorpUrl };
    var CorpDataAdapter = new $.jqx.dataAdapter(CorpSource);
    $("#selDegree").jqxDropDownList({ source: CorpDataAdapter, displayMember: "DetailName", valueMember: "DetailId", height: 25, selectedIndex: 0, disabled: true });

    var CorpUrl = "/CommBase/Banks";
    var CorpSource = { type: "POST", datatype: "json", datafields: [{ name: "DetailId" }, { name: "DetailName" }], url: CorpUrl };
    var CorpDataAdapter = new $.jqx.dataAdapter(CorpSource);
    $("#selBank").jqxDropDownList({ source: CorpDataAdapter, displayMember: "DetailName", valueMember: "DetailId", height: 25, selectedIndex: 0, disabled: true });

    var CorpUrl = "/CommBase/PayCitys";
    var CorpSource = { type: "POST", datatype: "json", datafields: [{ name: "DetailId" }, { name: "DetailName" }], url: CorpUrl };
    var CorpDataAdapter = new $.jqx.dataAdapter(CorpSource);
    $("#selPayCity").jqxDropDownList({ source: CorpDataAdapter, displayMember: "DetailName", valueMember: "DetailId", height: 25, selectedIndex: 0, disabled: true });

    var CorpUrl = "../Corporation/Corps";
    var CorpSource = { type: "POST", datatype: "json", datafields: [{ name: "CorpId" }, { name: "CorpName" }], url: CorpUrl };
    var CorpDataAdapter = new $.jqx.dataAdapter(CorpSource);
    $("#selCorpId").jqxComboBox({ source: CorpDataAdapter, displayMember: "CorpName", valueMember: "CorpId", autoComplete: true, searchMode: "contains", height: 25, disabled: true });

    var CorpUrl = "../Supplier/Suppliers";
    var CorpSource = { type: "POST", datatype: "json", datafields: [{ name: "SupId" }, { name: "SupName" }], url: CorpUrl };
    var CorpDataAdapter = new $.jqx.dataAdapter(CorpSource);
    $("#selSupId").jqxComboBox({ source: CorpDataAdapter, displayMember: "SupName", valueMember: "SupId", autoComplete: true, searchMode: "contains", height: 25, disabled: true });

    $("#chkIsHandBook").jqxCheckBox({ disabled: true });
    $("#chkIsResidentPermit").jqxCheckBox({ disabled: true });
    $("#chkIsBirthIns").jqxCheckBox({ disabled: true });

    //获取实体
    var temp = new Object();
    temp.id = id;

    $.ajax({
        type: "POST",
        contentType: "application/json",
        url: "/Employee/Get",
        data: JSON.stringify(temp),
        dataType: "json",
        success: function (result) {

            var obj = result;
            if (obj.ResultStatus == 0) {

                var rtnObj = JSON.parse(obj.ReturnValue);

                //设置原值
                $("#txbEmpName").val(rtnObj.EmpName),
                $("#selSex").val(rtnObj.Sex),
                $("#selCorpId").val(rtnObj.CorpId),
                $("#selSupId").val(rtnObj.SupId),
                $("#txbCardNo").val(rtnObj.CardNo),
                $("#txbAddress").val(rtnObj.Address),
                $("#txbPhone").val(rtnObj.Phone),
                $("#tmEntryDate").val(new Date(rtnObj.EntryDate)),
                $("#tmConStartDate").val(new Date(rtnObj.ConStartDate)),
                $("#tmConEndDate").val(new Date(rtnObj.ConEndDate)),
                $("#tmLeaveDate").val(new Date(rtnObj.LeaveDate)),
                $("#selDegree").val(rtnObj.Degree),
                $("#txbJobs").val(rtnObj.Jobs),
                $("#numTotalAmount").val(rtnObj.TotalAmount),
                $("#selPayCity").val(rtnObj.PayCity),
                $("#tmSocialStartDate").val(new Date(rtnObj.SocialStartDate)),
                $("#tmHouseStartDate").val(new Date(rtnObj.HouseStartDate)),
                $("#txbHouseAccount").val(rtnObj.HouseAccount),
                $("#chkIsHandBook").val(rtnObj.HandBook),
                $("#chkIsResidentPermit").val(rtnObj.ResidentPermit),
                $("#selBank").val(rtnObj.Bank),
                $("#txbBankAccount").val(rtnObj.BankAccount),
                $("#txbContractNo").val(rtnObj),
                $("#tmEmployDate").val(new Date(rtnObj.EmployDate)),
                $("#tmSocialSignDate").val(new Date(rtnObj.SocialSignDate)),
                $("#chkIsBirthIns").val(rtnObj.IsBirthIns),
                $("#txbInsCardNo").val(rtnObj.InsCardNo),
                $("#txbEmpEmail").val(rtnObj.EmpEmail),
                $("#numPISINum").val(rtnObj.PISINum),
                $("#numMISINum").val(rtnObj.MISINum),
                $("#numUISINum").val(rtnObj.UISINum),
                $("#numIISINum").val(rtnObj.IISINum),
                $("#numBISINum").val(rtnObj.BISINum),
                $("#numDISINum").val(rtnObj.DISINum),
                $("#numLISINum").val(rtnObj.LISINum),
                $("#numHASINum").val(rtnObj.HASINum),
                $("#numHFSINum").val(rtnObj.HFSINum),
                $("#numRISINum").val(rtnObj.RISINum),
                $("#txbMemo").val(rtnObj.Memo)
            }
            else {
                alert(obj.Message);
                document.location.href = obj.ReturnValue;
            }
        }
    });

    //开始加载
    var url = "../Employee/LoadEmployeeSalaryList";
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
        sortcolumn: "EmpSalaryId",
        sortdirection: "desc",
        formatdata: function (data) {

            var obj = {
                pageIndex: data.pagenum,
                pageSize: data.pagesize,
                orderField: data.sortdatafield,
                sortOrder: data.sortorder,
                empId: id
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
        cellHtml += "<a target=\"_self\" href=\"javascript:SendEmployeeEmail(" + value + ")\">发送</a>";
        cellHtml += "</div>";
        return cellHtml;
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
          { text: "操作", datafield: "EmpSalaryId", cellsrenderer: cellsrenderer, width: 100, sortable: false, enabletooltips: false, menu: false, resizable: false, pinned: true },
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
});

//发送邮件 操作
function SendEmployeeEmail(id) {

    if (!confirm("确定发送邮件操作吗?")) { return; }

    var temp = new Object();
    temp.id = id;

    $.ajax({
        type: "POST",
        contentType: "application/json",
        url: "/Send/SendEmployeeEmail",
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