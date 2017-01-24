$(document).ready(function () {
    var id = $("#hidId").val();
    //绑定
    $("#txbEmpName").jqxInput({ minLength: 1, height: 25, width: 200 });
    $("#txbCardNo").jqxInput({ minLength: 1, height: 25, width: 200 });
    $("#txbAddress").jqxInput({ minLength: 1, height: 25, width: 200 });
    $("#txbPhone").jqxInput({ minLength: 1, height: 25, width: 200 });
    $("#txbPhone").jqxInput({ minLength: 1, height: 25, width: 200 });
    $("#txbJobs").jqxInput({ minLength: 1, height: 25, width: 200 });
    $("#txbHouseAccount").jqxInput({ minLength: 1, height: 25, width: 200 });
    $("#txbBankAccount").jqxInput({ minLength: 1, height: 25, width: 200 });
    $("#txbContractNo").jqxInput({ minLength: 1, height: 25, width: 200 });
    $("#txbInsCardNo").jqxInput({ minLength: 1, height: 25, width: 200 });
    $("#txbEmpEmail").jqxInput({ minLength: 1, height: 25, width: 200 });

    $("#tmEntryDate").jqxDateTimeInput({ formatString: "yyyy-MM-dd" });

    $("#tmConStartDate").jqxDateTimeInput({ formatString: "yyyy-MM-dd" });
    $("#tmConEndDate").jqxDateTimeInput({ formatString: "yyyy-MM-dd" });
    $("#tmLeaveDate").jqxDateTimeInput({ formatString: "yyyy-MM-dd", value: new Date(1900, 0, 1) });
    $("#tmSocialStartDate").jqxDateTimeInput({ formatString: "yyyy-MM-dd" });
    $("#tmHouseStartDate").jqxDateTimeInput({ formatString: "yyyy-MM-dd" });
    $("#tmEmployDate").jqxDateTimeInput({ formatString: "yyyy-MM-dd" });
    $("#tmSocialSignDate").jqxDateTimeInput({ formatString: "yyyy-MM-dd", value: new Date(1900, 0, 1) });

    $("#numTotalAmount").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true });
    
    $("#numPISINum").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true });
    $("#numMISINum").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true });
    $("#numUISINum").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true });
    $("#numIISINum").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true });
    $("#numBISINum").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true });
    $("#numDISINum").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true });
    $("#numLISINum").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true });
    $("#numHASINum").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true });
    $("#numHFSINum").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true });
    $("#numRISINum").jqxNumberInput({ decimalDigits: 2, Digits: 6, spinButtons: true });

    var SexUrl = "/CommBase/Sexs";
    var SexSource = { type: "POST", datatype: "json", datafields: [{ name: "DetailId" }, { name: "DetailName" }], url: SexUrl };
    var SexDataAdapter = new $.jqx.dataAdapter(SexSource);
    $("#selSex").jqxDropDownList({ source: SexDataAdapter, displayMember: "DetailName", valueMember: "DetailId", height: 25, selectedIndex: 0 });

    var CorpUrl = "/CommBase/Degrees";
    var CorpSource = { type: "POST", datatype: "json", datafields: [{ name: "DetailId" }, { name: "DetailName" }], url: CorpUrl };
    var CorpDataAdapter = new $.jqx.dataAdapter(CorpSource);
    $("#selDegree").jqxDropDownList({ source: CorpDataAdapter, displayMember: "DetailName", valueMember: "DetailId", height: 25, selectedIndex: 0 });

    var CorpUrl = "/CommBase/Banks";
    var CorpSource = { type: "POST", datatype: "json", datafields: [{ name: "DetailId" }, { name: "DetailName" }], url: CorpUrl };
    var CorpDataAdapter = new $.jqx.dataAdapter(CorpSource);
    $("#selBank").jqxDropDownList({ source: CorpDataAdapter, displayMember: "DetailName", valueMember: "DetailId", height: 25, selectedIndex: 0 });

    var CorpUrl = "/CommBase/PayCitys";
    var CorpSource = { type: "POST", datatype: "json", datafields: [{ name: "DetailId" }, { name: "DetailName" }], url: CorpUrl };
    var CorpDataAdapter = new $.jqx.dataAdapter(CorpSource);
    $("#selPayCity").jqxDropDownList({ source: CorpDataAdapter, displayMember: "DetailName", valueMember: "DetailId", height: 25, selectedIndex: 0 });

    var CorpUrl = "../Corporation/Corps";
    var CorpSource = { type: "POST", datatype: "json", datafields: [{ name: "CorpId" }, { name: "CorpName" }], url: CorpUrl };
    var CorpDataAdapter = new $.jqx.dataAdapter(CorpSource);
    $("#selCorpId").jqxComboBox({ source: CorpDataAdapter, displayMember: "CorpName", valueMember: "CorpId", autoComplete: true, searchMode: "contains", height: 25 });

    var CorpUrl = "../Supplier/Suppliers";
    var CorpSource = { type: "POST", datatype: "json", datafields: [{ name: "SupId" }, { name: "SupName" }], url: CorpUrl };
    var CorpDataAdapter = new $.jqx.dataAdapter(CorpSource);
    $("#selSupId").jqxComboBox({ source: CorpDataAdapter, displayMember: "SupName", valueMember: "SupId", autoComplete: true, searchMode: "contains", height: 25 });

    $("#chkIsHandBook").jqxCheckBox();
    $("#chkIsResidentPermit").jqxCheckBox();
    $("#chkIsBirthIns").jqxCheckBox();


    //校验
    $("#jqxValidator").jqxValidator({
        position: "topcenter",
        rules:
            [
                {
                    input: "#txbEmpName", message: "员工姓名必填", action: "keyup, blur,valuechange", rule: function (input, commit) {
                        return $("#txbEmpName").val() != "";
                    }
                },
                {
                    input: "#selCorpId", message: "所属企业必填", action: "keyup, blur,valuechange", rule: function (input, commit) {
                        return $("#selCorpId").val() > 0;
                    }
                },
                {
                    input: "#selSupId", message: "供应商必填", action: "keyup, blur,valuechange", rule: function (input, commit) {
                        return $("#selSupId").val() > 0;
                    }
                },
                {
                    input: "#txbCardNo", message: "身份证必填", action: "keyup, blur,valuechange", rule: function (input, commit) {
                        return $("#txbCardNo").val() != "";
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

    $("#btnUpdate").click(function () {
        var isCanSubmit = $("#jqxValidator").jqxValidator("validate");
        if (!isCanSubmit) { return; }

        if (!confirm("确认修改员工？")) { return; }

        var employee = {
            EmpId: id,
            EmpName: $("#txbEmpName").val(),
            Sex: $("#selSex").val(),
            CorpId: $("#selCorpId").val(),
            SupId: $("#selSupId").val(),
            CardNo: $("#txbCardNo").val(),
            Address: $("#txbAddress").val(),
            Phone: $("#txbPhone").val(),
            EntryDate: $("#tmEntryDate").val(),
            ConStartDate: $("#tmConStartDate").val(),
            ConEndDate: $("#tmConEndDate").val(),
            LeaveDate: $("#tmLeaveDate").val(),
            Degree: $("#selDegree").val(),
            Jobs: $("#txbJobs").val(),
            TotalAmount: $("#numTotalAmount").val(),
            SocialFundNum: $("#numSocialFundNum").val(),
            HouseFundNum: $("#numHouseFundNum").val(),
            PayCity: $("#selPayCity").val(),
            SocialStartDate: $("#tmSocialStartDate").val(),
            HouseStartDate: $("#tmHouseStartDate").val(),
            HouseAccount: $("#txbHouseAccount").val(),
            HandBook: $("#chkIsHandBook").val(),
            ResidentPermit: $("#chkIsResidentPermit").val(),
            Bank: $("#selBank").val(),
            BankAccount: $("#txbBankAccount").val(),
            ContractNo: $("#txbContractNo").val(),
            EmployDate: $("#tmEmployDate").val(),
            SocialSignDate: $("#tmSocialSignDate").val(),
            IsBirthIns: $("#chkIsBirthIns").val(),
            InsCardNo: $("#txbInsCardNo").val(),
            EmpEmail: $("#txbEmpEmail").val(),
            PISINum: $("#numPISINum").val(),
            MISINum: $("#numMISINum").val(),
            UISINum: $("#numUISINum").val(),
            IISINum: $("#numIISINum").val(),
            BISINum: $("#numBISINum").val(),
            DISINum: $("#numDISINum").val(),
            LISINum: $("#numLISINum").val(),
            HASINum: $("#numHASINum").val(),
            HFSINum: $("#numHFSINum").val(),
            RISINum: $("#numRISINum").val(),
            Memo: $("#txbMemo").val()
        };

        $.ajax({
            type: "POST",
            contentType: "application/json",
            url: "../Employee/Update",
            data: JSON.stringify(employee),
            dataType: "json",
            success: function (result) {
                var obj = result;
                alert(obj.Message);
                if (obj.ResultStatus == 0) {
                    window.location = "/Employee/EmployeeList";
                }
            }
        });

    });
});