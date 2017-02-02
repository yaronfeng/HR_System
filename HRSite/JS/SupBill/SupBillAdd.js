var optList = new Array();

$(document).ready(function () {
    var id = $("#hidId").val();
    optList = JSON.parse($("#hidJsonOpt").val());
    if (optList.length > 0) {
        for (i = 0 ; i < optList.length ; i++) {
            var item = optList[i];
            var corpTotal = Number((item.CorpPensionIns + item.CorpMedicalIns + item.CorpUnempIns + item.CorpInjuryIns + item.CorpBirthIns + item.CorpDisabledIns + item.CorpIllnessIns + item.CorpHeatAmount + item.CorpHouseFund + item.CorpRepInjuryIns).toFixed(2));
            var empTotal = Number((item.EmpPensionIns + item.EmpMedicalIns + item.EmpUnempIns + item.EmpInjuryIns + item.EmpBirthIns + item.EmpDisabledIns + item.EmpIllnessIns + item.EmpHeatAmount + item.EmpHouseFund + item.EmpRepInjuryIns).toFixed(2));
            var grossAmount = Number((item.TotalAmount - corpTotal + empTotal).toFixed(2));

            optList[i].CorpTotal = corpTotal;
            optList[i].EmpTotal = empTotal;
            optList[i].GrossAmount = grossAmount;
            optList[i].AllTotalAmount = Number((corpTotal + empTotal).toFixed(2));
        }
    }
    //绑定
    $("#tmBillDate").jqxDateTimeInput({ formatString: "yyyy-MM" });
    $("#tmPayDate").jqxDateTimeInput({ formatString: "yyyy-MM-dd" });

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

    //校验
    $("#jqxValidator").jqxValidator({
        position: "topcenter",
        rules:
            [
                {
                    input: "#selSupId", message: "供应商必选", action: "keyup, blur,change", rule: function (input, commit) {
                        return $("#selSupId").val() > 0;
                    }
                }
            ]
    });

    //获取实体
    var temp = new Object();
    temp.id = id;

    $.ajax({
        type: "POST",
        contentType: "application/json",
        url: "/Supplier/Get",
        data: JSON.stringify(temp),
        dataType: "json",
        success: function (result) {

            var obj = result;
            if (obj.ResultStatus == 0) {

                var rtnObj = JSON.parse(obj.ReturnValue);

                //设置原值
                $("#selSupId").val(rtnObj.SupId)

                var pensionIns = 0;
                var medicalIns = 0;
                var unempIns = 0;
                var injuryIns = 0;
                var birthIns = 0;
                var disabledIns = 0;
                var illnessIns = 0;
                var heatAmount = 0;
                var houseFund = 0;
                var repInjuryIns = 0;

                var serviceAmount = 0;
                var totalAmount = 0;

                if (optList.length > 0) {
                    for (i = 0 ; i < optList.length ; i++) {
                        var item = optList[i];

                        pensionIns += item.CorpPensionIns + item.EmpPensionIns;
                        medicalIns += item.CorpMedicalIns + item.CorpMedicalIns;
                        unempIns += item.CorpUnempIns + item.CorpUnempIns;
                        injuryIns += item.CorpInjuryIns + item.CorpInjuryIns;
                        birthIns += item.CorpBirthIns + item.CorpBirthIns;
                        disabledIns += item.CorpDisabledIns + item.CorpDisabledIns;
                        illnessIns += item.CorpIllnessIns + item.CorpIllnessIns;
                        heatAmount += item.CorpHeatAmount + item.CorpHeatAmount;
                        houseFund += item.CorpHouseFund + item.CorpHouseFund;
                        repInjuryIns += item.CorpRepInjuryIns + item.CorpRepInjuryIns;
                        serviceAmount += item.ServiceAmount;
                    }
                    totalAmount = pensionIns + medicalIns + unempIns + injuryIns + birthIns + disabledIns + illnessIns + heatAmount + houseFund + repInjuryIns + serviceAmount;
                }

                $("#numBillPensionIns").val(pensionIns);
                $("#numBillMedicalIns").val(medicalIns);
                $("#numBillUnempIns").val(unempIns);
                $("#numBillInjuryIns").val(injuryIns);
                $("#numBillBirthIns").val(birthIns);
                $("#numBillDisabledIns").val(disabledIns);
                $("#numBillIllnessIns").val(illnessIns);
                $("#numBillHeatAmount").val(heatAmount);
                $("#numBillHouseFund").val(houseFund);
                $("#numBillRepInjuryIns").val(repInjuryIns);
                $("#numServiceAmount").val(serviceAmount);
                $("#numTotalAmount").val(totalAmount);
            }
            else {
                alert(obj.Message);
                document.location.href = obj.ReturnValue;
            }
        }
    });

    //已选列表
    optSource =
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
        localdata: optList
    };
    var optDataAdapter = new $.jqx.dataAdapter(optSource, {
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
        source: optDataAdapter,
        autoheight: true,
        virtualmode: true,
        sorttogglestates: 1,
        columnsresize: true,
        showaggregates: true,
        editable: false,
        sortable: true,
        enabletooltips: true,
        showstatusbar: true,
        statusbarheight: 25,
        rendergridrows: function (args) {
            return args.data;
        },
        columns: [
          { text: "序号", cellsrenderer: numberrenderer, width: 40, sortable: false, enabletooltips: false, menu: false, resizable: false, editable: false, pinned: true },
          { text: "姓名", datafield: "EmpName", pinned: true, width: 90, editable: false },
          { text: "工资月", datafield: "PayDate", cellsformat: "yyyy-MM", type: "date", pinned: true, width: 70, editable: false },
          { text: "缴费区域", datafield: "PayCityName", width: 70, pinned: true, editable: false },
          { text: "养老保险", columngroup: 'CorpDetails', datafield: "CorpPensionIns", width: 70, editable: false },
          { text: "医疗保险", columngroup: 'CorpDetails', datafield: "CorpMedicalIns", width: 70, editable: false },
          { text: "失业保险", columngroup: 'CorpDetails', datafield: "CorpUnempIns", width: 70, editable: false },
          { text: "工伤保险", columngroup: 'CorpDetails', datafield: "CorpInjuryIns", width: 70, editable: false },
          { text: "生育保险", columngroup: 'CorpDetails', datafield: "CorpBirthIns", width: 70, editable: false },
          { text: "残疾人保险", columngroup: 'CorpDetails', datafield: "CorpDisabledIns", width: 70, editable: false },
          { text: "大病保险", columngroup: 'CorpDetails', datafield: "CorpIllnessIns", width: 70, editable: false },
          { text: "取暖费", columngroup: 'CorpDetails', datafield: "CorpHeatAmount", width: 70, editable: false },
          { text: "公积金", columngroup: 'CorpDetails', datafield: "CorpHouseFund", width: 70, editable: false },
          { text: "补充工伤", columngroup: 'CorpDetails', datafield: "CorpRepInjuryIns", width: 70, editable: false },
          { text: "合计", columngroup: 'CorpDetails', datafield: "CorpTotal", width: 70, editable: false },
          { text: "养老保险", columngroup: 'EmpDetails', datafield: "EmpPensionIns", width: 70, editable: false },
          { text: "医疗保险", columngroup: 'EmpDetails', datafield: "EmpMedicalIns", width: 70, editable: false },
          { text: "失业保险", columngroup: 'EmpDetails', datafield: "EmpUnempIns", width: 70, editable: false },
          { text: "工伤保险", columngroup: 'EmpDetails', datafield: "EmpInjuryIns", width: 70, editable: false },
          { text: "生育保险", columngroup: 'EmpDetails', datafield: "EmpBirthIns", width: 70, editable: false },
          { text: "残疾人保险", columngroup: 'EmpDetails', datafield: "EmpDisabledIns", width: 70, editable: false },
          { text: "大病保险", columngroup: 'EmpDetails', datafield: "EmpIllnessIns", width: 70, editable: false },
          { text: "取暖费", columngroup: 'EmpDetails', datafield: "EmpHeatAmount", width: 70, editable: false },
          { text: "公积金", columngroup: 'EmpDetails', datafield: "EmpHouseFund", width: 70, editable: false },
          { text: "补充工伤", columngroup: 'EmpDetails', datafield: "EmpRepInjuryIns", width: 70, editable: false },
          { text: "合计", columngroup: 'EmpDetails', datafield: "EmpTotal", width: 70, editable: false },
          { text: "个调税", datafield: "PersonalTax", width: 70 },
          { text: "应发工资", datafield: "TotalAmount", width: 70, editable: false },
          { text: "社保补交", datafield: "RepairAmount", width: 70 },
          { text: "税前工资", datafield: "GrossAmount", width: 70, editable: false },
          { text: "实发工资", datafield: "FinalAmount", width: 70, editable: false },
          { text: "服务费", datafield: "ServiceAmount", width: 70 },
          { text: "补收/退款", datafield: "RefundAmount", width: 70 },
          { text: "合计", datafield: "AllTotalAmount", width: 70, editable: false },
        ],
        columngroups: [
            { text: '企业', align: 'center', name: 'CorpDetails' },
            { text: '个人', align: 'center', name: 'EmpDetails' }
        ]
    });

    //加载列表完毕

    $("#btnCreate").click(function () {

        var isCanSubmit = $("#jqxValidator").jqxValidator("validate");
        if (!isCanSubmit) { return; }
        if (!confirm("确认新增账单？")) { return; }

        var supBill = {
            SupId: id,
            BillDate: $("#tmBillDate").val(),
            PayDate: $("#tmPayDate").val(),
            BillPensionIns: $("#numBillPensionIns").val(),
            BillMedicalIns: $("#numBillMedicalIns").val(),
            BillUnempIns: $("#numBillUnempIns").val(),
            BillInjuryIns: $("#numBillInjuryIns").val(),
            BillBirthIns: $("#numBillBirthIns").val(),
            BillDisabledIns: $("#numBillDisabledIns").val(),
            BillIllnessIns: $("#numBillIllnessIns").val(),
            BillHeatAmount: $("#numBillHeatAmount").val(),
            BillHouseFund: $("#numBillHouseFund").val(),
            BillRepInjuryIns: $("#numBillRepInjuryIns").val(),
            CorpOtherPay: $("#numCorpOtherPay").val(),
            EmpOtherPay: $("#numEmpOtherPay").val(),
            ServiceAmount: $("#numServiceAmount").val(),
            TotalAmount: $("#numTotalAmount").val(),
            PayCity: $("#selPayCity").val(),
            Memo: $("#txbMemo").val()
        };

        var paras = new Object();
        paras.supBill = supBill;
        paras.details = optList;

        $.ajax({
            type: "POST",
            contentType: "application/json",
            url: "/SupBill/Insert",
            data: JSON.stringify(paras),
            dataType: "json",
            success: function (result) {
                var obj = result;
                alert(obj.Message);
                if (obj.ResultStatus == 0) {
                    window.document.location.href = "/SupBill/SupBillList";
                }
            }
        });
    });
});